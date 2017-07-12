using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal;
using TPFinal.DAL;
using TPFinal.Domain;
using System.Collections.Generic;

namespace TPFinal_Test
{
    [TestClass]
    public class CampaignRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext());

            Campaign c = new Campaign();
            c.imagesList = new List<ByteImage> { };
            c.initDateTime = DateTime.Now;
            c.endDateTime = DateTime.Now.AddDays(5);
            c.interval = 10;


            uow.campaignRepository.Add(c);
            uow.Complete();

            IEnumerator<Campaign> e = uow.campaignRepository.GetAll().GetEnumerator();

            bool x = false;
            while (e.MoveNext())
            {
                if(e.Current.initDateTime==c.initDateTime 
                    && e.Current.endDateTime==c.endDateTime
                    && e.Current.interval==c.interval
                    && e.Current.imagesList==c.imagesList)
                {
                    x = true;
                }
            }

            
            Assert.IsTrue(x);
        }
    }
}
