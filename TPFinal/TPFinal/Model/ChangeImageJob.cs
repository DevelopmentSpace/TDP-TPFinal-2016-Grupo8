using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Model
{
    [PersistJobDataAfterExecutionAttribute()]
    [DisallowConcurrentExecution()]
    class ChangeImageJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            int iActualCampaign = (int)context.Trigger.JobDataMap.Get("indexCampaign");
            int iActualImage = (int)context.Trigger.JobDataMap.Get("indexImage");

            //Code starts here

            context.Trigger.JobDataMap.Put("indexCampaign", iActualCampaign);
            context.Trigger.JobDataMap.Put("indexImage", iActualImage);
        }
    }
}
