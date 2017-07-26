using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;
using TPFinal.DTO;
using TPFinal.DAL;
using TPFinal.Model.RssReaderModel;
using log4net;

namespace TPFinal.Model
{
    class RssBannerService : IRssBannerService, ITextBanner
    {

        private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        IEnumerable<RssBanner> iRssBannerList = new List<RssBanner>() { };

        public String GetText()
        {
            String text = "";

            if (iRssBannerList == null)
                return text;

            foreach (RssBanner rssBanner in iRssBannerList)
            {
                if (BannerService.IsBannerActive(rssBanner))
                    { 
                        foreach (RssItem item in rssBanner.items)
                        {
                            text = text + " - " + item.description;
                        }
                }
            }
            return text;
        }

        public void UpdateBanners(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo)
        {
            IUnitOfWork uow = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());


            IEnumerable<RssBanner> rssBannerEnum = uow.rssBannerRepository.GetActives(pDate,pTimeFrom,pTimeTo);
            if (rssBannerEnum == null)
            {
                return;
            }
            IEnumerator<RssBanner> e = rssBannerEnum.GetEnumerator();

            SyndicationFeedRssReader feed = new SyndicationFeedRssReader();

            while (e.MoveNext())
            {
                try
                {
                    IEnumerable<RssItem> items = feed.Read(e.Current.url);
                    e.Current.items = items.ToList();
                    uow.Complete();
                }
                catch (Exception)
                {
                }
            }

            iRssBannerList = rssBannerEnum;
        }

        public void Create(RssBannerDTO pRssBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper RssBannerMapper = new RssBannerMapper();
            RssBanner banner = new RssBanner();

            try
            {
                RssBannerMapper.MapToModel(pRssBannerDTO, banner);
                iUnitOfWork.rssBannerRepository.Add(banner);
                iUnitOfWork.Complete();
            }
            catch (ArgumentException)
            {

                throw new ArgumentException();
            }
        }

        public void Update(RssBannerDTO pRssBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper RssBannerMapper = new RssBannerMapper();
            RssBanner banner = new RssBanner();
            RssBanner oldRssBanner = new RssBanner();

            RssBannerMapper.MapToModel(pRssBannerDTO, banner);

            oldRssBanner = iUnitOfWork.rssBannerRepository.Get(banner.id);

            oldRssBanner.name = banner.name;
            oldRssBanner.initTime = banner.initTime;
            oldRssBanner.endTime = banner.endTime;
            oldRssBanner.initDate = banner.initDate;
            oldRssBanner.endDate = banner.endDate;
            oldRssBanner.items = banner.items;
            oldRssBanner.url = banner.url;
           
            iUnitOfWork.Complete();

        }

        public void Delete(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper RssBannerMapper = new RssBannerMapper();
            RssBanner oldRssBanner = new RssBanner();
            try
            {
                oldRssBanner = iUnitOfWork.rssBannerRepository.Get(pId);
                iUnitOfWork.rssBannerRepository.Remove(oldRssBanner);
                iUnitOfWork.Complete();
                cLogger.Info("RssBanner eliminado");
            }
            catch (ArgumentException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public RssBannerDTO Get(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper textRssBannerMapper = new RssBannerMapper();
            RssBanner TextBanner = new RssBanner();

            try
            {
                return textRssBannerMapper.SelectorExpression.Compile()(iUnitOfWork.rssBannerRepository.Get(pId));
            }
            catch (ArgumentException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerable<RssBannerDTO> GetAll()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper textRssBannerMapper = new RssBannerMapper();
            IEnumerator<RssBanner> rssBanners = iUnitOfWork.rssBannerRepository.GetAll().GetEnumerator();
            IList<RssBannerDTO> rssBannersDTO = new List<RssBannerDTO> { };

            while (rssBanners.MoveNext())
            {
                rssBannersDTO.Add(textRssBannerMapper.SelectorExpression.Compile()(rssBanners.Current));
            }

            return rssBannersDTO;
        }

        public int GetLastRssTextId()
        {
            cLogger.Info("Obteniendo id de el ultimo banner de Rss");
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            IEnumerable<RssBanner> allRssBanner = iUnitOfWork.rssBannerRepository.GetAll();
            if (!allRssBanner.Any())
            {
                return (int)1;
            }
            else
            {
                return (allRssBanner.Last().id + 1);
            }
        }
    }
}

