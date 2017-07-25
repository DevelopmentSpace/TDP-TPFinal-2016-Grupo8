using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DAL;
using TPFinal.DAL.EntityFramework;
using TPFinal.Domain;
using TPFinal.DTO;
using Microsoft.Practices.Unity;
using System.Collections;
using Common.Logging;

namespace TPFinal.Model
{
    class CampaignService : IObservable, IJobListener
    {

        private static int UPDATE_TIME = 1;
        private static int DEFAULT_CHANGE_IMAGE_TIME = 5;

        private static readonly ILog cLogger = LogManager.GetLogger<CampaignService>();

        /// <summary>
        /// Lista de escuchadores
        /// </summary>
        private List<IObserver> iObserver = new List<IObserver> { };

        /// <summary>
        /// Contexto a utilizar
        /// </summary>
        DigitalSignageDbContext iDbContext;

        /// <summary>
        /// Lista donde se almacenaran todas las campañas actuales. El tiempo de refresco de las campañas se define por iRefreshTime.
        /// </summary>
        private IList<Campaign> iCampaignList;
        private IList<Campaign> iNewCampaignList;

        /// <summary>
        /// Indice de la imagen actual de una campaña
        /// </summary>
        private int iActualImage;

        /// <summary>
        /// Indice de campaña actual
        /// </summary>
        private int iActualCampaign;

        /// <summary>
        /// JobListener Name
        /// </summary>
        public string Name => "Campaign Service";


        //Atributos para controlar los timers
        bool iUpdateAvailable, iUpdateDone;

        //Quartz Scheduler
        IScheduler iScheduler;

        //Jobs details
        IJobDetail iChangeImageJob, iUpdateCampaignsJob;
        //Jobs Keys
        JobKey iChangeImageJobKey, iUpdateCampaignsJobKey;

        /// <summary>
        /// Creador del servicio de campañas
        /// </summary>
        public CampaignService()
        {
            cLogger.Info("Iniciando CampaignService");

            iDbContext = IoCContainerLocator.Container.Resolve<TPFinal.DAL.EntityFramework.DigitalSignageDbContext>();

            iCampaignList = new List<Campaign>() { };
            iNewCampaignList = new List<Campaign>() { };

            iScheduler = StdSchedulerFactory.GetDefaultScheduler();

            iChangeImageJobKey = new JobKey("CIJK");
            iUpdateCampaignsJobKey = new JobKey("UCJK");

            iChangeImageJob = JobBuilder.Create<ChangeImageJob>()
                .WithIdentity(iChangeImageJobKey)
                .Build();

            iUpdateCampaignsJob = JobBuilder.Create<UpdateCampaignsJob>()
                .WithIdentity(iUpdateCampaignsJobKey)
                .Build();

            iScheduler.Start();
            iScheduler.ListenerManager.AddJobListener(this, OrMatcher<JobKey>.Or(KeyMatcher<JobKey>.KeyEquals<JobKey>(iChangeImageJobKey), KeyMatcher<JobKey>.KeyEquals<JobKey>(iUpdateCampaignsJobKey)));

            iUpdateAvailable = false;
            iUpdateDone = false;

            iActualImage = -1;
            iActualCampaign = 0;

            cLogger.Info("Iniciando CampaignService Jobs");

            StartUpdateCampaignsJob(DateTime.Now);
            StartChangeImageJob(CampaignService.DEFAULT_CHANGE_IMAGE_TIME);
        }


        /******************************************************************/
        /**************************PATRON OBSERVER*************************/
        /******************************************************************/

        public void AddListener(IObserver pListener)
        {
            iObserver.Add(pListener);
            cLogger.Info("Nuevo listener agregado");
        }

        public void RemoveListener(IObserver pListener)
        {
            iObserver.Remove(pListener);
            cLogger.Info("Listener quitado");
        }

        public void NotifyListeners()
        {
            cLogger.Info("Notificando Listeners");
            foreach (IObserver view in iObserver)
            {
                view.Update("Campaign");
            }
        }

        /******************************************************************/
        /********************************CRUD******************************/
        /******************************************************************/

        public void Create(CampaignDTO pCampaignDTO)
        {

            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            CampaignMapper campaignMapper = new CampaignMapper();
            Campaign campaign = new Campaign();

            try
            {
                campaignMapper.MapToModel(pCampaignDTO, campaign);

                iUnitOfWork.campaignRepository.Add(campaign);

                iUnitOfWork.Complete();
                cLogger.Info("Nueva campaña agregada");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }


        }

        public void Update(CampaignDTO pCampaignDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            CampaignMapper campaignMapper = new CampaignMapper();
            Campaign campaign = new Campaign();
            Campaign oldCampaign = new Campaign();

            campaignMapper.MapToModel(pCampaignDTO, campaign);

            oldCampaign = iUnitOfWork.campaignRepository.Get(pCampaignDTO.id);

            oldCampaign.name = campaign.name;
            oldCampaign.initTime = campaign.initTime;
            oldCampaign.endTime = campaign.endTime;
            oldCampaign.initDate = campaign.initDate;
            oldCampaign.endDate = campaign.endDate;
            oldCampaign.imagesList = campaign.imagesList;
            oldCampaign.interval = campaign.interval;

            iUnitOfWork.Complete();
            cLogger.Info("Campaña actualizada");

        }

        public void Delete(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            CampaignMapper campaignMapper = new CampaignMapper();
            Campaign oldCampaign = new Campaign();

            try
            {
                oldCampaign = iUnitOfWork.campaignRepository.Get(pId);
                iUnitOfWork.campaignRepository.Remove(oldCampaign);
                iUnitOfWork.Complete();
                cLogger.Info("Campaña eliminada");
            }
            catch (NullReferenceException)
            {
                throw new IndexOutOfRangeException();
            }         
        }

        public CampaignDTO GetCampaign(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            CampaignMapper campaignMapper = new CampaignMapper();
            try
            {
                cLogger.Info("Obteniendo campaña por id");
                return campaignMapper.SelectorExpression.Compile()(iUnitOfWork.campaignRepository.Get(pId));
            }
            catch (NullReferenceException)
            {
                throw new IndexOutOfRangeException();
            }


        }

        public IEnumerable<CampaignDTO> GetAllCampaigns()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            IList<CampaignDTO> campaignAux = new List<CampaignDTO>();
            CampaignMapper campaignMapper = new CampaignMapper();
            IEnumerable<Campaign> campaignEnum = iUnitOfWork.campaignRepository.GetAll();

            cLogger.Info("Obteniendo todas las campañas.");

            IEnumerator e = campaignEnum.GetEnumerator();
            while (e.MoveNext())
            {
                campaignAux.Add((campaignMapper.SelectorExpression.Compile()((Campaign)e.Current)));
            }
            return campaignAux;
        }

        /******************************************************************/
        /*******************************TIMERS*****************************/
        /******************************************************************/
        /// <summary>
        /// Obtiene la imagen actual de la campaña actual
        /// </summary>
        /// <returns>Imagen actual</returns>
        public byte[] GetActualImage()
        {
            cLogger.Info("Obteniendo imagen actual.");
            byte[] b = { };
            if (iActualImage > -1)
                return iCampaignList.ElementAt(iActualCampaign).imagesList.ElementAt(iActualImage).bytes;
            else
                return b;
        }


        /// <summary>
        /// Permite saber si una campaña esta activa actualmente
        /// </summary>
        /// <returns>Verdadero si la campaña esta activa o falso si no lo esta</returns>
        public static bool IsCampaignActive(Campaign c)
        {
            DateTime date = DateTime.Now.Date;
            TimeSpan time = DateTime.Now.TimeOfDay;

            return (c.initDate <= date && c.endDate >= date)
                    &&
                    (c.initTime <= time && c.endTime >= time);
        }

        public int GetLastCampaignId()
        {
            cLogger.Info("Obteniendo id de la ultima campaña");
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            IEnumerable<Campaign> allCampaigns = iUnitOfWork.campaignRepository.GetAll();
            if (!allCampaigns.Any())
            {
                return (int)1;
            }
            else
            {
                return (allCampaigns.Last().id + 1);
            }
                

        }

        /******************************************************************/
        /*******************************TIMERS*****************************/
        /******************************************************************/
        private void StartChangeImageJob(int seconds)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream campList = new MemoryStream();
            formatter.Serialize(campList, iCampaignList);

            Stream newCampList = new MemoryStream();
            formatter.Serialize(newCampList, iNewCampaignList);


            JobDataMap jobDataMap = new JobDataMap();
            jobDataMap.Put("indexCampaign", iActualCampaign);
            jobDataMap.Put("indexImage", iActualImage);
            jobDataMap.Put("campList", campList);
            jobDataMap.Put("newCampList", newCampList);
            jobDataMap.Put("updateAvailable", iUpdateAvailable);

            ITrigger changeImageJobTrigger = TriggerBuilder.Create()
                .StartAt(DateTime.Now.AddSeconds(seconds))
                .UsingJobData(jobDataMap)
                .WithPriority(1)
                .Build();

            cLogger.Info("iniciando ChangeImage Job");
            iScheduler.DeleteJob(iChangeImageJobKey);
            iScheduler.ScheduleJob(iChangeImageJob, changeImageJobTrigger);
        }

        private void StartUpdateCampaignsJob(DateTime pDateTime)
        {
            ITrigger updateCampaignsJobTrigger = TriggerBuilder.Create()
                .StartAt(pDateTime)
                .WithPriority(1)
                .Build();

            iScheduler.DeleteJob(iUpdateCampaignsJobKey);
            iScheduler.ScheduleJob(iUpdateCampaignsJob, updateCampaignsJobTrigger);
        }


        /******************************************************************/
        /**************************TIMERS LISTENER*************************/
        /******************************************************************/

        public void JobToBeExecuted(IJobExecutionContext context)
        {         
        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            if(context.JobDetail.Key == iChangeImageJobKey)
            {
                cLogger.Info("ChangeImageJob Done");
                iActualCampaign = context.Trigger.JobDataMap.GetInt("indexCampaign");
                iActualImage = context.Trigger.JobDataMap.GetInt("indexImage");
                iUpdateDone = context.Trigger.JobDataMap.GetBoolean("updateDone");
                if (iUpdateDone)
                {
                    iUpdateDone = false;
                    iUpdateAvailable = false;
                    iCampaignList = this.DeepCopy(iNewCampaignList);
                    iNewCampaignList.Clear();
                }

                this.NotifyListeners();

                if (iActualImage > -1)
                    StartChangeImageJob(iCampaignList.ElementAt(iActualCampaign).interval);
                else
                    StartChangeImageJob(CampaignService.DEFAULT_CHANGE_IMAGE_TIME);


            }
            else if(context.JobDetail.Key == iUpdateCampaignsJobKey)
            {
                cLogger.Info("UpdateCampaignsJob Done");
                //Obtengo la lista nueva
                MemoryStream s = (MemoryStream)context.Trigger.JobDataMap.Get("listCampaign");
                s.Position = 0;

                IFormatter formatter = new BinaryFormatter();
                iNewCampaignList = (IList<Campaign>)formatter.Deserialize(s);
                iUpdateAvailable = true;

                StartUpdateCampaignsJob(DateTime.Now.AddMinutes(CampaignService.UPDATE_TIME));

            }

        }


        private IList<Campaign> DeepCopy(object objectToCopy)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, objectToCopy);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (IList<Campaign>)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
