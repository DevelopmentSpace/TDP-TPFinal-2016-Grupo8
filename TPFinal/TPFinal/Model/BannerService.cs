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
using log4net;

namespace TPFinal.Model
{
    /// <summary>
    /// Servicio de banners. Se encarga de ser servicio de todos.
    /// </summary>
    class BannerService : IBannerService, IJobListener
    {

        private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

            StartUpdateBannerJob(DateTime.Now);
        }

        private void StartUpdateBannerJob(DateTime pDateTime)
        {
            //Calculo el proximo intervalo al que voy a ejectuar el timer y hasta el cual voy a traer datos
            int hours = pDateTime.Hour;
            int minutes = (pDateTime.Minute / 10 + 1) * 10;
            TimeSpan timeTo;

            if (minutes == 60 && hours == 23)
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

            ITrigger updateBannerJobTrigger = TriggerBuilder.Create()
                .StartAt(pDateTime)
                .UsingJobData(jobDataMap)
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
            TimeSpan time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);

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
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0);
            TimeSpan timeTo = context.Trigger.JobDataMap.GetTimeSpan("timeTo");
            foreach (ITextBanner textBanner in iTextBannerList)
                {
                    textBanner.UpdateBanners(date,timeFrom,timeTo);
                }

            if (timeTo.Minutes == 59)
            {
                StartUpdateBannerJob(date.AddDays(1));
            }
            else
            {
                StartUpdateBannerJob(date.Add(timeTo));
            }
        }
    }
}
