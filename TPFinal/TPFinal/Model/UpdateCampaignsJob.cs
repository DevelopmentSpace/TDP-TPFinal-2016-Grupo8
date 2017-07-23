using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DAL;
using TPFinal.Domain;

namespace TPFinal.Model
{
    [PersistJobDataAfterExecutionAttribute()]
    [DisallowConcurrentExecution()]
    class UpdateCampaignsJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            IUnitOfWork uow = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext("DigitalSignage"));
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = DateTime.Now.TimeOfDay;
            TimeSpan timeTo = timeFrom.Add(new TimeSpan(0,30,0));

            IEnumerable<Campaign> enume = uow.campaignRepository.GetActives(date, timeFrom, timeTo);
            
            uow.Complete();
        
            IEnumerator<Campaign> e = enume.GetEnumerator();
            e.MoveNext();


            List<Campaign> x = enume.ToList<Campaign>();
            IFormatter formatter = new BinaryFormatter();
            var s = new MemoryStream();
            formatter.Serialize(s,enume);

            context.Trigger.JobDataMap.Put("List", s);
        }
    }
}
