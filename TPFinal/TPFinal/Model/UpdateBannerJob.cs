using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using TPFinal.DAL;
using TPFinal.Domain;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TPFinal.Model
{
    class UpdateBannerJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {



            IUnitOfWork uow = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = DateTime.Now.TimeOfDay;
            TimeSpan timeTo = timeFrom.Add(new TimeSpan(0, 0, 30, 0));

            IEnumerable<RssBanner> rssBannerEnum = uow.rssBannerRepository.GetActives(date, timeFrom, timeTo);
            IEnumerable<TextBanner> textBannerEnum = uow.textBannerRepository.GetActives(date, timeFrom, timeTo);

            uow.Complete();


            List<RssBanner> x = rssBannerEnum.ToList<RssBanner>();
            List<TextBanner> y = textBannerEnum.ToList<TextBanner>();
            IFormatter formatter = new BinaryFormatter();

            var s = new MemoryStream();
            formatter.Serialize(s, x);
            context.Trigger.JobDataMap.Put("listRssBanner", s);
            s.Dispose();

            var d = new MemoryStream();
            formatter.Serialize(d, y);
            context.Trigger.JobDataMap.Put("listTextBanner", d);
            d.Dispose();

            
        }
    }
}
