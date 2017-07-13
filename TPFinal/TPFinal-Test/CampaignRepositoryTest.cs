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
            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

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
                if (e.Current.name == c.name)
                {
                    x = true;
                    Assert.AreEqual(e.Current.interval, c.interval);
                    Assert.AreEqual(e.Current.initDateTime, c.initDateTime);
                    Assert.AreEqual(e.Current.endDateTime, c.endDateTime);
                    CollectionAssert.AreEquivalent((ICollection)e.Current.imagesList, (ICollection)c.imagesList);
                    uow.campaignRepository.Remove(e.Current);
                    uow.Complete();
                    break;
                }

            }
            Assert.IsTrue(x);
        }


        [TestMethod]
        public void removeCampaign()
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

            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));
            uow.campaignRepository.Add(c);

            uow.Complete();

            IEnumerator<Campaign> e = uow.campaignRepository.GetAll().GetEnumerator();

            e.MoveNext();

            Campaign get = e.Current;

            uow.campaignRepository.Remove(get);
            uow.Complete();
            Assert.IsNull(uow.campaignRepository.Get(get.id));

        }

        [TestMethod]
        public void GetActivesCampaigns()
        {
            Campaign c;

            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

            //Campañaa que finalizo antes
            c = new Campaign();
            c.name = "c1";
            c.initDateTime = new DateTime(2017, 06, 06, 10, 0, 0);
            c.endDateTime = new DateTime(2017, 06, 06, 10, 30, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empezo antes y finaliza en el intervalo
            c = new Campaign();
            c.name = "c2";
            c.initDateTime = new DateTime(2017, 06, 06, 11, 0, 0);
            c.endDateTime = new DateTime(2017, 06, 06, 12, 31, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empezo adentro y finaliza adentro del intervalo
            c = new Campaign();
            c.name = "c3";
            c.initDateTime = new DateTime(2017, 06, 06, 12, 45, 0);
            c.endDateTime = new DateTime(2017, 06, 06, 12, 50, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empezo adentro y finaliza afuera del intervalo
            c = new Campaign();
            c.name = "c4";
            c.initDateTime = new DateTime(2017, 06, 06, 12, 45, 0);
            c.endDateTime = new DateTime(2017, 06, 06, 16, 50, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empieza despues y finaliza despues del intervalo
            c = new Campaign();
            c.name = "c5";
            c.initDateTime = new DateTime(2017, 06, 06, 14, 00, 0);
            c.endDateTime = new DateTime(2017, 06, 06, 16, 50, 0);
            uow.campaignRepository.Add(c);


            uow.Complete();


            DateTime dateFrom = new DateTime(2017, 06, 06, 12, 30, 0);
            DateTime dateTo = new DateTime(2017, 06, 06, 13, 30, 0);

            IEnumerable<Campaign> enume = uow.campaignRepository.GetActives(dateFrom, dateTo);



            IEnumerator<Campaign> e = enume.GetEnumerator();
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("c2", e.Current.name);
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("c3", e.Current.name);
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("c4", e.Current.name);



            

        }
    }
}
