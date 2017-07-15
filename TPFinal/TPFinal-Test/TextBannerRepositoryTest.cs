using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal;
using TPFinal.DAL;
using TPFinal.Domain;
using System.Collections.Generic;
using System.Collections;

namespace TPFinal_Test
{
    class TextBannerRepositoryTest
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
    }
}
