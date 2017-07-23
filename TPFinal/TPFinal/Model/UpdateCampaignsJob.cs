using Quartz;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DAL;
using TPFinal.DAL.EntityFramework;
using TPFinal.Domain;
using Microsoft.Practices.Unity;

namespace TPFinal.Model
{
    [PersistJobDataAfterExecutionAttribute()]
    [DisallowConcurrentExecution()]
    class UpdateCampaignsJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            
            IUnitOfWork uow = new UnitOfWork(IoCContainerLocator.Container.Resolve<DigitalSignageDbContext>());
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = DateTime.Now.TimeOfDay;
            TimeSpan timeTo = timeFrom.Add(new TimeSpan(0,30,0));

            IEnumerable<Campaign> enume = uow.campaignRepository.GetActives(date, timeFrom, timeTo);
            
            uow.Complete();
       
            List<Campaign> x = enume.ToList<Campaign>();
            IFormatter formatter = new BinaryFormatter();
            var s = new MemoryStream();
            formatter.Serialize(s,x);

            context.Trigger.JobDataMap.Put("listCampaign", s);
        }
    }
}
