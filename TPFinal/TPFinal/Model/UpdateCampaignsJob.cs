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
	/// <summary>
	/// Trabajo a realizar para actualizar las campañas
	/// </summary>
    [PersistJobDataAfterExecutionAttribute()]
    [DisallowConcurrentExecution()]
    class UpdateCampaignsJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            DigitalSignageDbContext dbContext = new DigitalSignageDbContext();// IoCContainerLocator.Container.Resolve<DigitalSignageDbContext>();

            IUnitOfWork uow = new UnitOfWork(dbContext);
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute,0);
            TimeSpan timeTo = context.Trigger.JobDataMap.GetTimeSpan("timeTo");

            context.Trigger.JobDataMap.Put("date",date);


            //Obtiene las campañas
            IEnumerable<Campaign> enume = uow.campaignRepository.GetActives(date, timeFrom, timeTo);
            List<Campaign> x = enume.ToList<Campaign>();

			//Si no hay envia null
            if (x.Count == 0)
            {
                context.Trigger.JobDataMap.Put("listCampaign", null);
            }
			//Sino envia la lista serializada
            else
            {
                IFormatter formatter = new BinaryFormatter();
                var s = new MemoryStream();
                formatter.Serialize(s, x);

                context.Trigger.JobDataMap.Put("listCampaign", s);
            }

        }
    }
}
