using System;
using System.Collections.Generic;
using System.Linq;
using TPFinal.DAL;
using System.Timers;
using Quartz;
using TPFinal.DAL.EntityFramework;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System.IO;
using TPFinal.Domain;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Practices.Unity;

namespace TPFinal.Model
{
    /// <summary>
    /// Servicio de banners. Se encarga de ser servicio de todos.
    /// </summary>
    class BannerService : IObservable, IJobListener
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
        /// Lista de servicios de texto de banner
        /// </summary>
        private IList<ITextBanner> iTextBannerList = new List<ITextBanner> { };

        internal IList<ITextBanner> ITextBannerList
        {
            get
            {
                return iTextBannerList;
            }

            set
            {
                iTextBannerList = value;
            }
        }

        /// <summary>
        /// JobListener Name
        /// </summary>
        public string Name => "Banner Service";

        //Atributos para controlar los timers
        bool iUpdateAvailable, iUpdateDone;

        //Quartz Scheduler
        IScheduler iScheduler;

        //Jobs details
        IJobDetail iChangeBannerJob, iUpdateBannerJob;
        //Jobs Keys
        JobKey iChangeBannerJobKey, iUpdateBannerJobKey;

        /// <summary>
        /// Creador del servicio de campañas
        /// </summary>
        /// <param name="pRefreshTime">Minutos para el refresco con la base de datos</param>
        public BannerService()
        {
            iDbContext = IoCContainerLocator.Container.Resolve<TPFinal.DAL.EntityFramework.DigitalSignageDbContext>();

            ITextBanner rssBannerService = new RssBannerService();
            ITextBanner textBannerService = new TextBannerService();

            ITextBannerList.Add(textBannerService);
            ITextBannerList.Add(rssBannerService);

            iScheduler = StdSchedulerFactory.GetDefaultScheduler();

            iChangeBannerJobKey = new JobKey("BIJK");
            iUpdateBannerJobKey = new JobKey("UBJK");

            iChangeBannerJob = JobBuilder.Create<ChangeBannerJob>()
                .WithIdentity(iChangeBannerJobKey)
                 .Build();

            iUpdateBannerJob = JobBuilder.Create<UpdateBannerJob>()
                .WithIdentity(iUpdateBannerJobKey)
                .Build();


            iScheduler.Start();
            iScheduler.ListenerManager.AddJobListener(this, OrMatcher<JobKey>.Or(KeyMatcher<JobKey>.KeyEquals<JobKey>(iChangeBannerJobKey), KeyMatcher<JobKey>.KeyEquals<JobKey>(iUpdateBannerJobKey)));

            iUpdateAvailable = false;
            iUpdateDone = false;

            //StartUpdateBannerJob(0);
        }

        private void StartUpdateBannerJob(int minutes)
        {
            ITrigger updateBannerJobTrigger = TriggerBuilder.Create()
                .StartAt(DateTime.Now.AddMinutes(minutes))
                .WithPriority(1)
                .Build();

            iScheduler.DeleteJob(iUpdateBannerJobKey);
            iScheduler.ScheduleJob(iUpdateBannerJob, updateBannerJobTrigger);
        }

        private void StartChangeBannerJob(int seconds)
        {
            ITrigger changeBannerJobTrigger = TriggerBuilder.Create()
                .StartAt(DateTime.Now.AddSeconds(seconds))
                .WithPriority(1)
                .Build();

            iScheduler.DeleteJob(iChangeBannerJobKey);
            iScheduler.ScheduleJob(iChangeBannerJob, changeBannerJobTrigger);
        }

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
                view.Update("Banner");
                }              
        }
        /// <summary>
        /// Obtiene las cadenas de caracteres de todos los banners activos. 
        /// </summary>
        /// <returns>Cadena de caracteres con todo el texto de los banners</returns>
        public String GetText()
        {
            string text = "";
            foreach (ITextBanner serviceBanner in ITextBannerList)
            {
                text = text + " - " + serviceBanner.GetText();
            }
            return text;
        }

        /// <summary>
        /// Da informacion del estado de un banner
        /// </summary>
        /// <returns>Verdadero si el banner esta activo o falso si no lo esta</returns>
        public static bool IsBannerActive(Banner b)
        {
            DateTime date = DateTime.Now.Date;
            TimeSpan time = date.TimeOfDay;

            return (b.initDate <= date && b.endDate >= date)
                    &&
                    (b.initTime <= time && b.endTime >= time);
        }


        /// <summary>
        /// Empieza un servicio de banners.
        /// </summary>
        public void Start()
        {

        }

        /// <summary>
        /// Frena 
        /// </summary>
        public void Stop()
        {

        }

        public void JobToBeExecuted(IJobExecutionContext context)
        {

        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {

            if (context.JobDetail.Key == iChangeBannerJobKey)
            {
                this.NotifyListeners();
            }
            else if (context.JobDetail.Key == iUpdateBannerJobKey)
            {

                IFormatter formatter = new BinaryFormatter();

                MemoryStream s = (MemoryStream)context.Trigger.JobDataMap.Get("listTextBanner");
                s.Position = 0;
                IList<TextBanner> l;
                l = (IList<TextBanner>)formatter.Deserialize(s);
                s.Dispose();

                MemoryStream d = (MemoryStream)context.Trigger.JobDataMap.Get("listRssBanner");
                s.Position = 0;
                IList<RssBanner> e;
                e = (IList<RssBanner>)formatter.Deserialize(d);
                d.Dispose();

                //Esta horrible pero es la idea
                foreach (ITextBanner textBanner in ITextBannerList)
                {
                    switch (textBanner.GetType().ToString())
                    {
                        case "RssService":
                        {
                                RssBannerService rssService = (RssBannerService)textBanner;
                                rssService.ChangeList(e);
                                break;
                        }
                        case "TextBannerService":
                        {
                                TextBannerService textService = (TextBannerService)textBanner;
                                textService.ChangeList(l);
                                break;
                        }
                    }
                };
            }
        }
    }
}
