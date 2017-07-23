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

namespace TPFinal.Model
{
    class CampaignService : IObservable, IJobListener
    {

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
        private IEnumerable<Campaign> iCampaignList;
        private IEnumerable<Campaign> iNewCampaignList;

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

        public CampaignService()
        {
            iDbContext = IoCContainerLocator.Container.Resolve<TPFinal.DAL.EntityFramework.DigitalSignageDbContext>();

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

            iActualImage = 0;
            iActualCampaign = 0;
            
            StartUpdateCampaignsJob(0);
        }


        /******************************************************************/
        /**************************PATRON OBSERVER*************************/
        /******************************************************************/

        public void AddListener(IObserver pListener)
        {
            iObserver.Add(pListener);
        }

        public void RemoveListener(IObserver pListener)
        {
            iObserver.Remove(pListener);
        }

        public void NotifyListeners()
        {
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

            campaignMapper.MapToModel(pCampaignDTO, campaign);

            iUnitOfWork.campaignRepository.Add(campaign);

            iUnitOfWork.Complete();

        }

        public void Update(CampaignDTO pCampaignDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            CampaignMapper campaignMapper = new CampaignMapper();
            Campaign campaign = new Campaign();
            Campaign oldCampaign = new Campaign();

            campaignMapper.MapToModel(pCampaignDTO, campaign);

            oldCampaign = iUnitOfWork.campaignRepository.Get(pCampaignDTO.id); //REVISAR SI FUNCIONA

            oldCampaign = campaign;

            iUnitOfWork.Complete();

        }

        public void Delete(CampaignDTO pCampaignDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            CampaignMapper campaignMapper = new CampaignMapper();
            Campaign oldCampaign = new Campaign();

            oldCampaign = iUnitOfWork.campaignRepository.Get(pCampaignDTO.id);

            iUnitOfWork.campaignRepository.Remove(oldCampaign);

            iUnitOfWork.Complete();
        }

        public CampaignDTO GetCampaign(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            CampaignMapper campaignMapper = new CampaignMapper();

            return campaignMapper.SelectorExpression.Compile()(iUnitOfWork.campaignRepository.Get(pId));

        }

        public IEnumerable<CampaignDTO> GetAllCampaigns()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            IList<CampaignDTO> campaignAux = new List<CampaignDTO> { };
            CampaignMapper campaignMapper = new CampaignMapper();

            foreach (Campaign campaign in iUnitOfWork.campaignRepository.GetAll().ToList())
            {
                campaignAux.Add(campaignMapper.SelectorExpression.Compile()(iUnitOfWork.campaignRepository.Get(campaign.id)));
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
            return iCampaignList.ElementAt(iActualCampaign).imagesList.ElementAt(iActualImage).bytes;
        }

        /// <summary>
        /// Empieza un servicio de campañas. Pone a correr los timers.
        /// </summary>
        public void Start()
        {
           // jobScheduler.Start();
        }

        /// <summary>
        /// Frena ambos timers.
        /// </summary>
        public void Stop()
        {
           // jobScheduler.Stop();
        }

        /// <summary>
        /// Permite saber si una campaña esta activa actualmente
        /// </summary>
        /// <returns>Verdadero si la campaña esta activa o falso si no lo esta</returns>
        public static bool IsCampaignActive(Campaign c)
        {
            DateTime date = DateTime.Now.Date;
            TimeSpan time = date.TimeOfDay;

            return (c.initDate <= date && c.endDate >= date)
                    &&
                    (c.initTime <= time && c.endTime >= time);
        }

        public int GetLastCampaignId()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            IEnumerable<Campaign> allCampaigns = iUnitOfWork.campaignRepository.GetAll();
            if (!allCampaigns.Any())
            {
                return (int)1;
            }
            else
                return (allCampaigns.Last().id + 1);
        }

        /******************************************************************/
        /*******************************TIMERS*****************************/
        /******************************************************************/
        private void StartChangeImageJob(int seconds)
        {
            ITrigger changeImageJobTrigger = TriggerBuilder.Create()
                .StartAt(DateTime.Now.AddSeconds(seconds))
                .WithPriority(1)
                .Build();

            iScheduler.DeleteJob(iChangeImageJobKey);
            iScheduler.ScheduleJob(iChangeImageJob, changeImageJobTrigger);
        }

        private void StartUpdateCampaignsJob(int minutes)
        {
            ITrigger updateCampaignsJobTrigger = TriggerBuilder.Create()
            .StartAt(DateTime.Now.AddMinutes(minutes))
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
            context.Trigger.JobDataMap.Put("indexCampaign", iActualCampaign);
            context.Trigger.JobDataMap.Put("indexImage", iActualImage);

            IFormatter formatter = new BinaryFormatter();
            var s = new MemoryStream();
            formatter.Serialize(s, iCampaignList);

            context.Trigger.JobDataMap.Put("listCampaign", s);
           
        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            MemoryStream s = (MemoryStream) context.Trigger.JobDataMap.Get("listCampaign");
            s.Position = 0;

            IList<Campaign> l;

            IFormatter formatter = new BinaryFormatter();
            l = (IList<Campaign>) formatter.Deserialize(s);

            //Cuando el trabajo se termina de ejecutar notifica a las pantallas
            NotifyListeners();

        }
    }
}
