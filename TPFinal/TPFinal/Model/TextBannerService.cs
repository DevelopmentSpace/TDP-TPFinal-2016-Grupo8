using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;
using TPFinal.DTO;
using TPFinal.DAL;

namespace TPFinal.Model
{
    class TextBannerService : ITextBanner
    {
        int iRefreshTime;

        IEnumerable<TextBanner> iTextBannerList;

        public TextBannerService(int pRefreshTIme)
        {
            iRefreshTime = pRefreshTIme;
        }

        /// <summary>
        /// Da informacion del estado de un banner
        /// </summary>
        /// <returns>Verdadero si el banner esta activo o falso si no lo esta</returns>
        public bool IsBannerActive(Banner pBanner)
        {
            DateTime date = DateTime.Now.Date;
            TimeSpan time = date.TimeOfDay;

            return (pBanner.initDate <= date && pBanner.endDate >= date)
                    &&
                    (pBanner.initTime <= time && pBanner.endTime >= time);
        }

        public String GetText()
        {
            String text = "";
            foreach (TextBanner textBanner in iTextBannerList)
            {
                if (IsBannerActive(textBanner))
                { 
                    text = text + " - " + textBanner.text;
                }
            }

            return text;
        }

        public void Refresh()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = DateTime.Now.TimeOfDay;
            TimeSpan timeTo = timeFrom.Add(new TimeSpan(0, 0, 0, 0, (int)iRefreshTime));

            iTextBannerList = iUnitOfWork.textBannerRepository.GetActives(date,timeFrom,timeTo);
        }

        public void Create(TextBannerDTO pTextBannerDTO)
{
    IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
    TextBannerMapper textBannerMapper = new TextBannerMapper();
    TextBanner banner = new TextBanner();

    textBannerMapper.MapToModel(pTextBannerDTO, banner);
    iUnitOfWork.textBannerRepository.Add(banner);

    iUnitOfWork.Complete();

}

public void Update(TextBannerDTO pTextBannerDTO)
{
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner banner = new TextBanner();
            TextBanner oldTextBanner = new TextBanner();

    textBannerMapper.MapToModel(pTextBannerDTO, banner);

    oldTextBanner = iUnitOfWork.textBannerRepository.Get(banner.id); //REVISAR SI FUNCIONA

    oldTextBanner = banner;

    iUnitOfWork.Complete();

}

public void Delete(TextBannerDTO pTextBannerDTO)
    {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner oldTextBanner = new TextBanner();

            oldTextBanner = iUnitOfWork.textBannerRepository.Get(pTextBannerDTO.id);

    iUnitOfWork.textBannerRepository.Remove(oldTextBanner);

    iUnitOfWork.Complete();
    }
    }
}
