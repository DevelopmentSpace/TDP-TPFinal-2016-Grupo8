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
            
        }
    }
}
