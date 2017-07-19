using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Model;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using Quartz.Spi;

namespace TPFinal.Model
{
    class JobScheduler
    {
        IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

        public void Start()
        {
           
            IJobDetail refreshCampaignJob = JobBuilder.Create<RefreshCampaignJob>().Build();
            ITrigger refreshCampaignTrigger = TriggerBuilder.Create()
                .WithIdentity("RefreshCampaignJob", "Refresh")
                .StartNow()
                .WithSimpleSchedule(s => s
                    .WithIntervalInMinutes(30) 
                    .RepeatForever())
                .WithPriority(1)
                .Build();
            scheduler.ScheduleJob(refreshCampaignJob, refreshCampaignTrigger);
            /*
            IJobDetail refreshBannerJob = JobBuilder.Create<RefreshBannerJob>().Build();
            ITrigger refreshBannerTrigger = TriggerBuilder.Create()
                .WithIdentity("RefreshBannerJob", "Refresh")
                .StartNow()
                .WithSimpleSchedule(s => s
                    .WithIntervalInMinutes(30)
                    .RepeatForever())
                    .WithPriority(2)
                    .Build();
            scheduler.ScheduleJob(refreshBannerJob, refreshBannerTrigger);*/

            IJobDetail intervalCampaignJob = JobBuilder.Create<IntervalCampaignJob>().Build();
            ITrigger intervalCampaignTrigger = TriggerBuilder.Create()
                .WithIdentity("IntervalCampaignJob", "IntervalCampaign")
                .StartNow()
                .WithSimpleSchedule(s => s
                    .WithIntervalInSeconds(30) //Hay que buscarle una forma de cambiar dinamicamente estos intervalos
                    .RepeatForever())
                .WithPriority(3)
                .Build();
            scheduler.ScheduleJob(intervalCampaignJob, intervalCampaignTrigger);

            /*IJobDetail intervalBannerJob = JobBuilder.Create<IntervalBannerJob>().Build();
            ITrigger intervalBannerTrigger = TriggerBuilder.Create()
                .WithIdentity("IntervalBannerJob", "IntervalBanner")
                .StartNow()
                .WithSimpleSchedule(s => s
                    .WithIntervalInSeconds(30) //Hay que buscarle una forma de cambiar dinamicamente estos intervalos
                    .RepeatForever())
                .WithPriority(4)
                .Build();
            scheduler.ScheduleJob(intervalBannerJob, intervalBannerTrigger);*/

            scheduler.Start();
        }

        public void Stop()
        {
            scheduler.PauseAll();
        }

        public void Resume()
        {
            scheduler.ResumeAll();
        }

    }
}
