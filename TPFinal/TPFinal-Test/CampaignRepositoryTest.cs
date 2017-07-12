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
        /*public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }*/

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

            Assert.IsTrue(true);
        }
    }
}
