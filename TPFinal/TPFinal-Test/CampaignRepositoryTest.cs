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
            c.initDate = DateTime.Now.Date;
            c.endDate = DateTime.Now.Date.AddDays(50);
            c.initTime = new TimeSpan(5, 0, 12);
            c.endTime = new TimeSpan(5, 5, 12);
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
                    Assert.AreEqual(e.Current.initDate, c.initDate);
                    Assert.AreEqual(e.Current.endDate, c.endDate);
                    Assert.AreEqual(e.Current.initTime, c.initTime);
                    Assert.AreEqual(e.Current.endTime, c.endTime);
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
            c.initDate = DateTime.Now.Date;
            c.endDate = DateTime.Now.Date.AddDays(50);
            c.initTime = new TimeSpan(5, 0, 12);
            c.endTime = new TimeSpan(5, 5, 12);
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
            c.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.initTime = new TimeSpan(10, 0, 0);
            c.endTime = new TimeSpan(10, 30, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empezo antes y finaliza en el intervalo
            c = new Campaign();
            c.name = "c2";
            c.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.initTime = new TimeSpan(11, 0, 0);
            c.endTime = new TimeSpan(12, 31, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empezo adentro y finaliza adentro del intervalo
            c = new Campaign();
            c.name = "c3";
            c.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.initTime = new TimeSpan(12, 45, 0);
            c.endTime = new TimeSpan(12, 50, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empezo adentro y finaliza afuera del intervalo
            c = new Campaign();
            c.name = "c4";
            c.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.initTime = new TimeSpan(12, 45, 0);
            c.endTime = new TimeSpan(16, 50, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empieza despues y finaliza despues del intervalo
            c = new Campaign();
            c.name = "c5";
            c.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            c.initTime = new TimeSpan(14, 0, 0);
            c.endTime = new TimeSpan(16, 50, 0);
            uow.campaignRepository.Add(c);

            //Campaña con fecha anterior
            c = new Campaign();
            c.name = "c6";
            c.initDate = new DateTime(2016, 06, 05, 0, 0, 0);
            c.endDate = new DateTime(2016, 06, 05, 0, 0, 0);
            c.initTime = new TimeSpan(23, 0, 0);
            c.endTime = new TimeSpan(23, 30, 0);
            uow.campaignRepository.Add(c);

            //Campañaa con fecha posterior
            c = new Campaign();
            c.name = "c7";
            c.initDate = new DateTime(2016, 06, 07, 0, 0, 0);
            c.endDate = new DateTime(2016, 06, 07, 0, 0, 0);
            c.initTime = new TimeSpan(0, 0, 0);
            c.endTime = new TimeSpan(00, 50, 0);
            uow.campaignRepository.Add(c);

            uow.Complete();

            DateTime dateFrom = new DateTime(2016, 06, 06, 12, 30, 0);
            DateTime dateTo = new DateTime(2016, 06, 06, 13, 30, 0);

            IEnumerable<Campaign> enume = uow.campaignRepository.GetActives(dateFrom, dateTo);


            try
            {
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
                Assert.IsFalse(e.MoveNext());
            }
            finally
            {
                uow.Dispose();
            }
            

            
        }

        [TestMethod]
        public void GetActivesCampaignsBetweenDays()
        {
            Campaign c;

            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

            //Campañaa que empieza y termina en el primer dia
            c = new Campaign();
            c.name = "c1";
            c.initDate = new DateTime(2017, 06, 06, 0, 0, 0);
            c.endDate = new DateTime(2017, 06, 06, 0, 0, 0);
            c.initTime = new TimeSpan(22, 0, 0);
            c.endTime = new TimeSpan(23, 50, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empieza en un dia y termina en el siguiente
            c = new Campaign();
            c.name = "c2";
            c.initDate = new DateTime(2017, 06, 06, 0, 0, 0);
            c.endDate = new DateTime(2017, 06, 07, 0, 0, 0);
            c.initTime = new TimeSpan(22, 0, 0);
            c.endTime = new TimeSpan(0, 50, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empieza en el dia siguiente y termina despues
            c = new Campaign();
            c.name = "c3";
            c.initDate = new DateTime(2017, 06, 07, 0, 0, 0);
            c.endDate = new DateTime(2017, 06, 07, 0, 0, 0);
            c.initTime = new TimeSpan(0, 10, 0);
            c.endTime = new TimeSpan(1, 50, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empieza y termina en el primer dia
            c = new Campaign();
            c.name = "c4";
            c.initDate = new DateTime(2017, 06, 06, 0, 0, 0);
            c.endDate = new DateTime(2017, 06, 06, 0, 0, 0);
            c.initTime = new TimeSpan(22, 0, 0);
            c.endTime = new TimeSpan(23, 50, 0);
            uow.campaignRepository.Add(c);

            //Campañaa que empieza y termina en el dia siguiente
            c = new Campaign();
            c.name = "c5";
            c.initDate = new DateTime(2017, 06, 07, 0, 0, 0);
            c.endDate = new DateTime(2017, 06, 07, 0, 0, 0);
            c.initTime = new TimeSpan(4, 0, 0);
            c.endTime = new TimeSpan(5, 50, 0);
            uow.campaignRepository.Add(c);

            uow.Complete();
        

            DateTime dateFrom = new DateTime(2017, 06, 06, 23, 30, 0);
            DateTime dateTo = new DateTime(2017, 06, 07, 0, 30, 0);

            IEnumerable<Campaign> enume = uow.campaignRepository.GetActives(dateFrom, dateTo);


                IEnumerator<Campaign> e = enume.GetEnumerator();
                e.MoveNext();
                Assert.IsNotNull(e.Current);
                Assert.AreEqual("c1", e.Current.name);
                e.MoveNext();
                Assert.IsNotNull(e.Current);
                Assert.AreEqual("c2", e.Current.name);
                e.MoveNext();
                Assert.IsNotNull(e.Current);
                Assert.AreEqual("c3", e.Current.name);
                Assert.IsFalse(e.MoveNext());


            
        }
    }
}
