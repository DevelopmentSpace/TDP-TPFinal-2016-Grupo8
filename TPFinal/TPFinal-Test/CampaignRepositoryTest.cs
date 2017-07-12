using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal;
using TPFinal.DAL;
using TPFinal.Domain;
using System.Collections.Generic;
using System.Collections;

namespace TPFinal_Test
{
    [TestClass]
    public class CampaignRepositoryTest
    {
        [TestMethod]
        public void AddCampaign()
        {
            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext());

            Campaign c = new Campaign();
            c.name = "Mi campañaaaaa";
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
                if (e.Current.name == c.name) {
                    uow.campaignRepository.Remove(c);
                    uow.Complete();
                    Assert.AreEqual(e.Current.interval, c.interval);
                    Assert.AreEqual(e.Current.initDateTime, c.initDateTime);
                    Assert.AreEqual(e.Current.endDateTime, c.endDateTime);
                    CollectionAssert.AreEquivalent((ICollection)e.Current.imagesList, (ICollection)c.imagesList);
                    x = true;
                }
            }

            Assert.IsTrue(x);
        }

        [TestMethod]
        public void getCampaign()
        {
            byte[] b= { 0x44, 0x55 };

            ByteImage i = new ByteImage();
            i.bytes = b;

            Campaign c = new Campaign();
            c.name = "Una campañaa re linda";
            c.imagesList = new List<ByteImage> {i};
            c.initDateTime = DateTime.Now;
            c.endDateTime = DateTime.Now.AddDays(50);
            c.interval = 4;

            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext());
            uow.campaignRepository.Add(c);

            uow.Complete();

            IEnumerator<Campaign> e = uow.campaignRepository.GetAll().GetEnumerator();
            e.MoveNext();

            Assert.IsNotNull(e.Current);

            Campaign get = uow.campaignRepository.Get(e.Current.id);
            uow.Complete();


            Assert.AreEqual(e.Current.id, get.id);
            Assert.AreEqual(e.Current.name, get.name);
            Assert.AreEqual(e.Current.interval, get.interval);
            Assert.AreEqual(e.Current.initDateTime, get.initDateTime);
            Assert.AreEqual(e.Current.endDateTime, get.endDateTime);
            CollectionAssert.AreEquivalent((ICollection)e.Current.imagesList, (ICollection)get.imagesList);

            uow.campaignRepository.Remove(e.Current);
            uow.Complete();

        }
    }
}
