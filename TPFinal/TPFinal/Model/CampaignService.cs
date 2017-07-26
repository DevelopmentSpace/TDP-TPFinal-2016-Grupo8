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
using log4net;

namespace TPFinal.Model
{
    class CampaignService : ICampaignService, IJobListener
    {

        private static int DEFAULT_CHANGE_IMAGE_TIME = 5;

        private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Lista de escuchadores
        /// </summary>
        private List<IObserver> iObserver = new List<IObserver> { };


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
            //new DigitalSignageDbContext() = IoCContainerLocator.Container.Resolve<TPFinal.DAL.EntityFramework.DigitalSignageDbContext>();

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

            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
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
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
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
            oldCampaign.imagesList.Clear();
            oldCampaign.imagesList = campaign.imagesList;
            oldCampaign.interval = campaign.interval;

            

            iUnitOfWork.Complete();
            cLogger.Info("Campaña actualizada");

        }

        public void Delete(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
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
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
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

        public IEnumerable<CampaignDTO> GetAll()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
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
        /*******************************UTILITIES*****************************/
        /******************************************************************/
        /// <summary>
        /// Obtiene la imagen actual de la campaña actual
        /// </summary>
        /// <returns>Imagen actual</returns>
        public ByteImageDTO GetActualImage()
        {
            cLogger.Info("Obteniendo imagen actual.");
            ByteImageDTO b = new ByteImageDTO();
            if (iActualImage > -1)
            {
                ByteImageMapper imageMapper = new ByteImageMapper();
                ByteImageDTO imageDTO = new ByteImageDTO();
                ByteImage image = new ByteImage();

                image.bytes = iCampaignList.ElementAt(iActualCampaign).imagesList.ElementAt(iActualImage).bytes;

                return imageMapper.SelectorExpression.Compile()(image);            
            }
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
            TimeSpan time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);

            return (c.initDate <= date && c.endDate >= date)
                    &&
                    (c.initTime <= time && c.endTime >= time);
        }

        /******************************************************************/
        /*******************************TIMERS*****************************/
        /******************************************************************/
        private void StartChangeImageJob(int pSeconds)
        {
            ITrigger changeImageJobTrigger = TriggerBuilder.Create()
                .StartAt(DateTime.Now.AddSeconds(pSeconds))
                .WithPriority(1)
                .Build();

            cLogger.Info("iniciando ChangeImage Job");
            iScheduler.DeleteJob(iChangeImageJobKey);
            iScheduler.ScheduleJob(iChangeImageJob, changeImageJobTrigger);
        }

        private void StartUpdateCampaignsJob(DateTime pDateTime)
        {
            //Calculo el proximo intervalo al que voy a ejectuar el timer y hasta el cual voy a traer datos
            int hours = pDateTime.Hour;
            int minutes = (pDateTime.Minute / 10 + 1) * 10;
            TimeSpan timeTo;

            if(minutes==60 && hours == 23)
            {
                timeTo = new TimeSpan(23, 59, 00);
            }
            else if (minutes == 60)
            {
                timeTo = new TimeSpan(hours + 1, 00, 00);
            }
            else
            {
                timeTo = new TimeSpan(hours, minutes, 00);
            }


            JobDataMap jobDataMap = new JobDataMap();
            jobDataMap.Put("timeTo", timeTo);

            ITrigger updateCampaignsJobTrigger = TriggerBuilder.Create()
                .StartAt(pDateTime)
                .UsingJobData(jobDataMap)
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
                //Si habia una imagen y Campaña actual activa y tiene imagenes todavia
                if (iActualImage > -1 && iActualImage < iCampaignList.ElementAt(iActualCampaign).imagesList.Count - 1
                    && CampaignService.IsCampaignActive(iCampaignList.ElementAt(iActualCampaign)))
                {
                    iActualImage++;
                }
                else
                {
                    //Pasamos a la campaña siguiente, mientras haya otra y la actual no este activa
                    do
                    {
                        iActualCampaign++;
                    }
                    while (iActualCampaign <= iCampaignList.Count - 1 && !CampaignService.IsCampaignActive(iCampaignList.ElementAt(iActualCampaign)));

                    //Si se encontro una campaña activa
                    if ((iActualCampaign <= iCampaignList.Count - 1))
                    {
                        iActualImage = 0;
                    }
                    //Si se terminaron las campañas
                    else
                    {
                        //Si hay nueva lista actualizamos
                        if (iUpdateAvailable)
                        {
                            iUpdateDone = true;
                           
                            if (!iNewCampaignList.Any(campaign => CampaignService.IsCampaignActive(campaign)))
                                iActualImage = -1;
                            else
                            {
                                iActualImage = 0;
                                iActualCampaign = 0;
                                while (!CampaignService.IsCampaignActive(iNewCampaignList.ElementAt(iActualCampaign)))
                                {
                                    iActualCampaign++;
                                }
                            }
                        }
                        //Sino hay que empezar desde el principio
                        else
                        {
                            if (!iCampaignList.Any(campaign => CampaignService.IsCampaignActive(campaign)))
                                iActualImage = -1;
                            else
                            {
                                iActualImage = 0;
                                iActualCampaign = 0;
                                while (!CampaignService.IsCampaignActive(iCampaignList.ElementAt(iActualCampaign)))
                                {
                                    iActualCampaign++;
                                }
                            }
                        }
                    }
                }//Fin if-else

                if (iUpdateDone)
                {
                    iUpdateDone = false;
                    iUpdateAvailable = false;
                    iCampaignList = CampaignService.DeepCopy(iNewCampaignList);
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
                if (s != null)
                {
                    s.Position = 0;

                    IFormatter formatter = new BinaryFormatter();
                    iNewCampaignList = (IList<Campaign>)formatter.Deserialize(s);
                    iUpdateAvailable = true;
                }

                DateTime date = context.Trigger.JobDataMap.GetDateTime("date");
                TimeSpan timeTo = context.Trigger.JobDataMap.GetTimeSpan("timeTo");
                if(timeTo.Minutes == 59)
                {
                    StartUpdateCampaignsJob(date.AddDays(1));
                }
                else
                {
                    StartUpdateCampaignsJob(date.Add(timeTo));
                }

            }

        }


        private static IList<Campaign> DeepCopy(IList<Campaign> c)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, c);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (IList<Campaign>)binaryFormatter.Deserialize(memoryStream);
            }
        }

        public void ForceUpdate()
        {
            StartUpdateCampaignsJob(DateTime.Now);
        }
    }
}
