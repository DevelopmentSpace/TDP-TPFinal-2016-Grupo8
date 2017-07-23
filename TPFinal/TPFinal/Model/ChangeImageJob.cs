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

            //Aca hay que agregar 
            int iActualCampaign = context.Trigger.JobDataMap.GetInt("indexCampaign");
            int iActualImage = context.Trigger.JobDataMap.GetInt("indexImage");


            //Code starts here

            context.Trigger.JobDataMap.Put("indexCampaign", iActualCampaign);
            context.Trigger.JobDataMap.Put("indexImage", iActualImage);
        }
    }
}
