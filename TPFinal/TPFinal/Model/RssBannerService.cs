﻿using System;
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
        IList<RssBanner> iRssBannerList;

        int iRefreshTime;

        public RssBannerService(int pRefreshTIme)
        {
            iRefreshTime = pRefreshTIme;
        }

        /// <summary>
        /// Da informacion del estado de un banner
        /// </summary>
        /// <returns>Verdadero si el banner esta activo o falso si no lo esta</returns>
        public bool IsActive(Banner pBanner)
        {
            //REEMPLAZA POR TU CODIGO AGUSTIN
            return ((pBanner.initTime <= DateTime.Now) && (pBanner.endTime>= DateTime.Now));
        }

        public String GetText()
        {
            String text = "";
            SyndicationFeedRssReader feed = new SyndicationFeedRssReader();

            foreach (RssBanner rssBanner in iRssBannerList)
            {
                if (IsActive(rssBanner))
                    { 
                IEnumerable<RssItem> rssItems;
                rssItems =  feed.Read(rssBanner.url);
                    foreach (RssItem item in rssItems)
                    {
                    text = text + " - " + item.description;
                    }
                }
            }

            return text;
        }

        public void Refresh()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            DateTime pDateFrom = DateTime.Now;
            DateTime pDateTo = DateTime.Now.AddMilliseconds(iRefreshTime);

            iRssBannerList = iUnitOfWork.rssBannerRepository.GetActives(pDateFrom, pDateFrom, pDateTo);
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

        public void Delete(RssBannerDTO pRssBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            RssBannerMapper RssBannerMapper = new RssBannerMapper();
            RssBanner oldRssBanner = new RssBanner();

            oldRssBanner = iUnitOfWork.rssBannerRepository.Get(pRssBannerDTO.id);

            iUnitOfWork.rssBannerRepository.Remove(oldRssBanner);

            iUnitOfWork.Complete();
        }
    }
}
