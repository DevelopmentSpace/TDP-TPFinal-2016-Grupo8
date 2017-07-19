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

        JobDataMap services;
        
        public JobScheduler(CampaignService pCampaign)
        {
            JobDataMap dataMap = new JobDataMap();
            dataMap.Add("service", pCampaign);
            services = dataMap;
        }

        public void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();


            IJobDetail job = JobBuilder.Create<RefreshJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("RefreshJob", "Refresh")
                .StartNow()
                .UsingJobData(services)
                .WithSimpleSchedule(s => s
                    .WithIntervalInSeconds(30)
                    .RepeatForever())
                .WithPriority(1)
                .Build();
            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();
        }

    }
}
