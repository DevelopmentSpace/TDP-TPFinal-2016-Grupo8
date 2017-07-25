using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;
using TPFinal.DTO;
using TPFinal.DAL;
using TPFinal.Model.RssReaderModel;

namespace TPFinal.Model
{
    class RssBannerService : ITextBanner
    {
        IEnumerable<RssBanner> iRssBannerList;

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

        public void Update()
        {
            IUnitOfWork uow = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = DateTime.Now.TimeOfDay;
            TimeSpan timeTo = timeFrom.Add(new TimeSpan(0, 0, 30, 0));

            IEnumerable<RssBanner> rssBannerEnum = uow.rssBannerRepository.GetActives(date, timeFrom, timeTo);



            IEnumerator<RssBanner> e = rssBannerEnum.GetEnumerator();

            SyndicationFeedRssReader feed = new SyndicationFeedRssReader();

            while (e.MoveNext())
            {
                try
                {
                    e.Current.items = feed.Read(e.Current.url).ToList();
                }
                catch (Exception)
                {
                }
            }

            iRssBannerList = rssBannerEnum;

            uow.Complete();
        }

        public void Create(RssBannerDTO pRssBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper RssBannerMapper = new RssBannerMapper();
            RssBanner banner = new RssBanner();

            RssBannerMapper.MapToModel(pRssBannerDTO, banner);
            iUnitOfWork.rssBannerRepository.Add(banner);

            iUnitOfWork.Complete();

        }

        public void Update(RssBannerDTO pRssBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper RssBannerMapper = new RssBannerMapper();
            RssBanner banner = new RssBanner();
            RssBanner oldRssBanner = new RssBanner();

            RssBannerMapper.MapToModel(pRssBannerDTO, banner);

            oldRssBanner = iUnitOfWork.rssBannerRepository.Get(banner.id); //REVISAR SI FUNCIONA

            oldRssBanner = banner;

            iUnitOfWork.Complete();

        }

        public void Delete(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper RssBannerMapper = new RssBannerMapper();
            RssBanner oldRssBanner = new RssBanner();

            oldRssBanner = iUnitOfWork.rssBannerRepository.Get(pId);

            iUnitOfWork.rssBannerRepository.Remove(oldRssBanner);

            iUnitOfWork.Complete();
        }

        public RssBannerDTO Get(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper textRssBannerMapper = new RssBannerMapper();
            RssBanner TextBanner = new RssBanner();

            return textRssBannerMapper.SelectorExpression.Compile()(iUnitOfWork.rssBannerRepository.Get(pId));
        }
    }
}

