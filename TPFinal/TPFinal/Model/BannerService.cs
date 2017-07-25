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
using Common.Logging;

namespace TPFinal.Model
{
    /// <summary>
    /// Servicio de banners. Se encarga de ser servicio de todos.
    /// </summary>
    class BannerService : IObservable, IJobListener
    {

        private static readonly ILog cLogger = LogManager.GetLogger<CampaignService>();

        /// <summary>
        /// Lista de escuchadores
        /// </summary>
        private List<IObserver> iObserver = new List<IObserver> { };

        /// <summary>
        /// Lista de servicios de texto de banner
        /// </summary>
        private IList<ITextBanner> iTextBannerList = new List<ITextBanner> { };

        /// <summary>
        /// JobListener Name
        /// </summary>
        public string Name => "Banner Service";

        //Quartz Scheduler
        IScheduler iScheduler;

        //Jobs details
        IJobDetail iUpdateBannerJob;
        //Jobs Keys
        JobKey iUpdateBannerJobKey;


        /// <summary>
        /// Creador del servicio de Banners
        /// </summary>
        public BannerService()
        {
            cLogger.Info("Iniciando BannerService");

            iScheduler = StdSchedulerFactory.GetDefaultScheduler();

            iUpdateBannerJobKey = new JobKey("UBJK");

            iUpdateBannerJob = JobBuilder.Create<UpdateBannerJob>()
                .WithIdentity(iUpdateBannerJobKey)
                .Build();


            iScheduler.Start();
            iScheduler.ListenerManager.AddJobListener(this, (KeyMatcher<JobKey>.KeyEquals<JobKey>(iUpdateBannerJobKey)));

            cLogger.Info("Iniciando UpdateBanner Job");

            StartUpdateBannerJob(0);
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
                view.Update("Banner");
                }              
        }

        /// <summary>
        /// Agregar un servicio de texto a la lista de servicio de textos
        /// </summary>
        /// <param name="textBanner">Servicio de textos</param>
        public void AddService(ITextBanner textBanner)
        {
            iTextBannerList.Add(textBanner);
        }

        /// <summary>
        /// Obtiene las cadenas de caracteres de todos los banners activos. 
        /// </summary>
        /// <returns>Cadena de caracteres con todo el texto de los banners</returns>
        public String GetText()
        {
            string text = "";
            foreach (ITextBanner serviceBanner in iTextBannerList)
            {
                text = text + serviceBanner.GetText();
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
            TimeSpan time = DateTime.Now.TimeOfDay;

            return (b.initDate <= date && b.endDate >= date)
                    &&
                    (b.initTime <= time && b.endTime >= time);
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
                foreach (ITextBanner textBanner in iTextBannerList)
                {
                    textBanner.Update();
                }
                StartUpdateBannerJob(1);
        }
    }
}
