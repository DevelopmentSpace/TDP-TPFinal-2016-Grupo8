using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal.DAL;
using TPFinal.Domain;
using System.Collections;

namespace TPFinal_Test
{
    /// <summary>
    /// Descripción resumida de TextBannerRepository
    /// </summary>
    [TestClass]
    public class TextBannerRepositoryTest
    {
        [TestMethod]
        public void AddTextBannerTest()
        {
            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

            TextBanner t = new TextBanner();
            t.name = "Mi banner de prueba";
            t.text = "Mi texto de prueba de banner";
            t.initDate = DateTime.Now.Date;
            t.endDate = DateTime.Now.Date.AddDays(50);
            t.initTime = new TimeSpan(5, 0, 12);
            t.endTime = new TimeSpan(5, 5, 12);

            uow.textBannerRepository.Add(t);
            uow.Complete();

            IEnumerator<TextBanner> e = uow.textBannerRepository.GetAll().GetEnumerator();
            bool x = false;
            while (e.MoveNext())
            {
                if (e.Current.name == t.name)
                {
                    x = true;
                    Assert.AreEqual(e.Current.initDate, t.initDate);
                    Assert.AreEqual(e.Current.endDate, t.endDate);
                    Assert.AreEqual(e.Current.initTime, t.initTime);
                    Assert.AreEqual(e.Current.endTime, t.endTime);
                    Assert.AreEqual(e.Current.text, t.text);
                    uow.textBannerRepository.Remove(e.Current);
                    uow.Complete();
                    break;
                }

            }
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void removeTextBanner()
        {

            TextBanner t = new TextBanner();
            t.name = "Banner a borrar";
            t.text = "Mi texto de prueba de banner";
            t.initDate = DateTime.Now.Date;
            t.endDate = DateTime.Now.Date.AddDays(50);
            t.initTime = new TimeSpan(5, 0, 12);
            t.endTime = new TimeSpan(5, 5, 12);

            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));
            uow.textBannerRepository.Add(t);

            uow.Complete();

            IEnumerator<TextBanner> e = uow.textBannerRepository.GetAll().GetEnumerator();

            e.MoveNext();

            TextBanner get = e.Current;

            uow.textBannerRepository.Remove(get);
            uow.Complete();
            Assert.IsNull(uow.textBannerRepository.Get(get.id));

        }

        [TestMethod]
        public void GetActivesTextBanners()
        {
            TextBanner t;

            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

			//Banner que finalizo antes
			t = new TextBanner();
            t.name = "t1";
            t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.initTime = new TimeSpan(10, 0, 0);
            t.endTime = new TimeSpan(10, 30, 0);
            uow.textBannerRepository.Add(t);

			//Banner que empezo antes y finaliza en el intervalo
			t = new TextBanner();
            t.name = "t2";
            t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.initTime = new TimeSpan(11, 0, 0);
            t.endTime = new TimeSpan(12, 31, 0);
            uow.textBannerRepository.Add(t);

			//Banner que empezo adentro y finaliza adentro del intervalo
			t = new TextBanner();
            t.name = "t3";
            t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.initTime = new TimeSpan(12, 45, 0);
            t.endTime = new TimeSpan(12, 50, 0);
            uow.textBannerRepository.Add(t);

			//Banner que empezo adentro y finaliza afuera del intervalo
			t = new TextBanner();
            t.name = "t4";
            t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.initTime = new TimeSpan(12, 45, 0);
            t.endTime = new TimeSpan(16, 50, 0);
            uow.textBannerRepository.Add(t);

			//Banner que empieza despues y finaliza despues del intervalo
			t = new TextBanner();
            t.name = "t5";
            t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
            t.initTime = new TimeSpan(14, 0, 0);
            t.endTime = new TimeSpan(16, 50, 0);
            uow.textBannerRepository.Add(t);

			//Banner con fecha anterior
			t = new TextBanner();
            t.name = "t6";
            t.initDate = new DateTime(2016, 06, 05, 0, 0, 0);
            t.endDate = new DateTime(2016, 06, 05, 0, 0, 0);
            t.initTime = new TimeSpan(23, 0, 0);
            t.endTime = new TimeSpan(23, 30, 0);
            uow.textBannerRepository.Add(t);

            //Banner con fecha posterior
            t = new TextBanner();
            t.name = "t7";
            t.initDate = new DateTime(2016, 06, 07, 0, 0, 0);
            t.endDate = new DateTime(2016, 06, 07, 0, 0, 0);
            t.initTime = new TimeSpan(0, 0, 0);
            t.endTime = new TimeSpan(00, 50, 0);
            uow.textBannerRepository.Add(t);

            uow.Complete();

            DateTime date = new DateTime(2016, 06, 06, 0, 0, 0);
            TimeSpan timeFrom = new TimeSpan(12, 30, 0);
            TimeSpan timeTo = new TimeSpan(13, 30, 0);

            IEnumerable<TextBanner> enume = uow.textBannerRepository.GetActives(date, timeFrom, timeTo);

            uow.Complete();

            IEnumerator<TextBanner> e = enume.GetEnumerator();
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("t2", e.Current.name);
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("t3", e.Current.name);
            e.MoveNext();
            Assert.IsNotNull(e.Current);
            Assert.AreEqual("t4", e.Current.name);
            Assert.IsFalse(e.MoveNext());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void invalidTimeGetActiveTextBanners()
        {
            IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

            DateTime date = new DateTime(2016, 06, 06, 0, 0, 0);
            TimeSpan timeFrom = new TimeSpan(12, 30, 0);
            TimeSpan timeTo = new TimeSpan(10, 30, 0);

            uow.textBannerRepository.GetActives(date, timeFrom, timeTo);
        }
    }
}
