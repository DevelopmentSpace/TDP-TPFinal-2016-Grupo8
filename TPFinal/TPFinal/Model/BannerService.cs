﻿using System;
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
        /// Lista de servicios de texto de banner
        /// </summary>
        private IList<ITextBanner> iTextBannerList = new List<ITextBanner> { };

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

        public void AddService(ITextBanner textBanner)
        {
            iTextBannerList.Add(textBanner);
        }

        /// <summary>
        /// Creador del servicio de campañas
        /// </summary>
        /// <param name="pRefreshTime">Minutos para el refresco con la base de datos</param>
        public BannerService()
        {
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

            StartUpdateBannerJob(0);
        }

        private void StartUpdateBannerJob(int minutes)
        {
            ITrigger updateBannerJobTrigger = TriggerBuilder.Create()
                .StartAt(DateTime.Now.AddSeconds(minutes))
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
            foreach (ITextBanner serviceBanner in iTextBannerList)
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
            TimeSpan time = DateTime.Now.TimeOfDay;

            return (b.initDate <= date && b.endDate >= date)
                    &&
                    (b.initTime <= time && b.endTime >= time);
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

                foreach (ITextBanner textBanner in iTextBannerList)
                {
                    textBanner.Update();
                }
                StartUpdateBannerJob(10);
            }
        }
    }
}
