using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal.DAL;
using TPFinal.Domain;

namespace TPFinal_Test
{
	/// <summary>
	/// Summary description for RssBannerServiceTest
	/// </summary>
	[TestClass]
	public class RssBannerRepositoryTest
	{
		[TestMethod]
		public void AddRssBannerTest()
		{
			IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

			RssBanner t = new RssBanner();
			t.name = "Mi banner de prueba";
			t.url = "www.google.com";
			t.initDate = DateTime.Now.Date;
			t.endDate = DateTime.Now.Date.AddDays(50);
			t.initTime = new TimeSpan(5, 0, 12);
			t.endTime = new TimeSpan(5, 5, 12);

			uow.rssBannerRepository.Add(t);
			uow.Complete();

			IEnumerator<RssBanner> e = uow.rssBannerRepository.GetAll().GetEnumerator();
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
					Assert.AreEqual(e.Current.url, t.url);
					uow.rssBannerRepository.Remove(e.Current);
					uow.Complete();
					break;
				}

			}
			Assert.IsTrue(x);
		}

		[TestMethod]
		public void removeRssBanner()
		{

			RssBanner t = new RssBanner();
			t.name = "Banner a borrar";
			t.url = "http://www.google.com.ar";
			t.initDate = DateTime.Now.Date;
			t.endDate = DateTime.Now.Date.AddDays(50);
			t.initTime = new TimeSpan(5, 0, 12);
			t.endTime = new TimeSpan(5, 5, 12);

			IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));
			uow.rssBannerRepository.Add(t);

			uow.Complete();

			IEnumerator<RssBanner> e = uow.rssBannerRepository.GetAll().GetEnumerator();

			e.MoveNext();

			RssBanner get = e.Current;

			uow.rssBannerRepository.Remove(get);
			uow.Complete();
			Assert.IsNull(uow.rssBannerRepository.Get(get.id));

		}

		[TestMethod]
		public void GetActivesRssBanners()
		{
			RssBanner t;

			IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

			//Banner que finalizo antes
			t = new RssBanner();
			t.name = "t1";
			t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.initTime = new TimeSpan(10, 0, 0);
			t.endTime = new TimeSpan(10, 30, 0);
			uow.rssBannerRepository.Add(t);

			//Banner que empezo antes y finaliza en el intervalo
			t = new RssBanner();
			t.name = "t2";
			t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.initTime = new TimeSpan(11, 0, 0);
			t.endTime = new TimeSpan(12, 31, 0);
			uow.rssBannerRepository.Add(t);

			//Banner que empezo adentro y finaliza adentro del intervalo
			t = new RssBanner();
			t.name = "t3";
			t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.initTime = new TimeSpan(12, 45, 0);
			t.endTime = new TimeSpan(12, 50, 0);
			uow.rssBannerRepository.Add(t);

			//Banner que empezo adentro y finaliza afuera del intervalo
			t = new RssBanner();
			t.name = "t4";
			t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.initTime = new TimeSpan(12, 45, 0);
			t.endTime = new TimeSpan(16, 50, 0);
			uow.rssBannerRepository.Add(t);

			//Banner que empieza despues y finaliza despues del intervalo
			t = new RssBanner();
			t.name = "t5";
			t.initDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.endDate = new DateTime(2016, 06, 06, 0, 0, 0);
			t.initTime = new TimeSpan(14, 0, 0);
			t.endTime = new TimeSpan(16, 50, 0);
			uow.rssBannerRepository.Add(t);

			//Banner con fecha anterior
			t = new RssBanner();
			t.name = "t6";
			t.initDate = new DateTime(2016, 06, 05, 0, 0, 0);
			t.endDate = new DateTime(2016, 06, 05, 0, 0, 0);
			t.initTime = new TimeSpan(23, 0, 0);
			t.endTime = new TimeSpan(23, 30, 0);
			uow.rssBannerRepository.Add(t);

			//Banner con fecha posterior
			t = new RssBanner();
			t.name = "t7";
			t.initDate = new DateTime(2016, 06, 07, 0, 0, 0);
			t.endDate = new DateTime(2016, 06, 07, 0, 0, 0);
			t.initTime = new TimeSpan(0, 0, 0);
			t.endTime = new TimeSpan(00, 50, 0);
			uow.rssBannerRepository.Add(t);

			uow.Complete();

			DateTime date = new DateTime(2016, 06, 06, 0, 0, 0);
			TimeSpan timeFrom = new TimeSpan(12, 30, 0);
			TimeSpan timeTo = new TimeSpan(13, 30, 0);

			IEnumerable<RssBanner> enume = uow.rssBannerRepository.GetActives(date, timeFrom, timeTo);

			uow.Complete();

			IEnumerator<RssBanner> e = enume.GetEnumerator();
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
		public void invalidTimeGetActiveRssBanners()
		{
			IUnitOfWork uow = new UnitOfWork(new TPFinal.DAL.EntityFramework.DigitalSignageDbContext("DigitalSignageTest"));

			DateTime date = new DateTime(2016, 06, 06, 0, 0, 0);
			TimeSpan timeFrom = new TimeSpan(12, 30, 0);
			TimeSpan timeTo = new TimeSpan(10, 30, 0);

			uow.rssBannerRepository.GetActives(date, timeFrom, timeTo);
		}
	}
}
