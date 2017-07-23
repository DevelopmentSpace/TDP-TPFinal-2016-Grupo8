using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal;
using TPFinal.DAL;
using TPFinal.Domain;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TPFinal_Test
{
    [TestClass]
    public class CampaignRepositoryTest
    {
        [TestMethod]
        public void AddCampaign()
        {
            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

            byte[] bytes = { 0x00, 0x22, 0x11 };

            ByteImage b = new ByteImage();
            b.bytes = bytes;

            Campaign c = new Campaign();
            c.name = "Mi campañaaaaa";
            c.imagesList = new List<ByteImage> {b};
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
        public void serializeCampaign()
        {
            byte[] bytes = { 0x00, 0x22, 0x11 };

            ByteImage b = new ByteImage();
            b.bytes = bytes;

            Campaign c = new Campaign();
            c.name = "Mi campañaaaaa";
            c.imagesList = new List<ByteImage> { b };
            c.initDate = DateTime.Now.Date;
            c.endDate = DateTime.Now.Date.AddDays(50);
            c.initTime = new TimeSpan(5, 0, 12);
            c.endTime = new TimeSpan(5, 5, 12);
            c.interval = 10;

            IFormatter formatter = new BinaryFormatter();

            FileStream s = new FileStream("PruenaSerializar", FileMode.Create);
            formatter.Serialize(s, c);
            s.Flush();
            s.Position = 0;
            Campaign x = (Campaign) formatter.Deserialize(s);
            s.Close();

            Assert.AreEqual(x.name, c.name);
            Assert.AreEqual(x.interval, c.interval);
            Assert.AreEqual(x.initDate, c.initDate);
            Assert.AreEqual(x.endDate, c.endDate);
            Assert.AreEqual(x.initTime, c.initTime);
            Assert.AreEqual(x.endTime, c.endTime);
            Assert.AreEqual(x.imagesList.Count, c.imagesList.Count);

        }

        [TestMethod]
        public void removeTextBanner()
        {

            Campaign c = new Campaign();
            c.name = "Mi campañaaaaa";
            c.imagesList = new List<ByteImage> { };
            c.initDate = DateTime.Now.Date;
            c.endDate = DateTime.Now.Date.AddDays(50);
            c.initTime = new TimeSpan(5, 0, 12);
            c.endTime = new TimeSpan(5, 5, 12);
            c.interval = 10;

            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));
            uow.campaignRepository.Add(c);

            uow.Complete();

            IEnumerator<Campaign> e = uow.campaignRepository.GetAll().GetEnumerator();

            e.MoveNext();

            Campaign get = e.Current;

            uow.campaignRepository.Remove(get);
            uow.Complete();
            Assert.IsNull(uow.textBannerRepository.Get(get.id));

        }


        [TestMethod]
        public void GetActivesCampaigns()
        {
            Campaign c;

            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

            byte[] bytes = { 0x00, 0x11, 0xFF };
            ByteImage b = new ByteImage();
            b.bytes = bytes;

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
            c.imagesList = new List<ByteImage>() { b };
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

            DateTime date = new DateTime(2016, 06, 06, 0,0, 0);
            TimeSpan timeFrom = new TimeSpan(12, 30, 0);
            TimeSpan timeTo = new TimeSpan(13, 30, 0);


            IEnumerable<Campaign> enume = uow.campaignRepository.GetActives(date,timeFrom,timeTo);

            uow.Complete();

            IEnumerator<Campaign> e = enume.GetEnumerator();
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("c2", e.Current.name);
            Assert.AreEqual(e.Current.imagesList.Count, 1);
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("c3", e.Current.name);
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("c4", e.Current.name);
            Assert.IsFalse(e.MoveNext());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void invalidTimeGetActiveCampaigns()
        {
            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

            DateTime date = new DateTime(2016, 06, 06, 0, 0, 0);
            TimeSpan timeFrom = new TimeSpan(12, 30, 0);
            TimeSpan timeTo = new TimeSpan(10, 30, 0);

            uow.campaignRepository.GetActives(date, timeFrom, timeTo);
        }

    }
}
