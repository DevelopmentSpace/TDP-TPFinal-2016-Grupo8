using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;
using TPFinal.DTO;
using TPFinal.DAL;
using Common.Logging;
using TPFinal.DAL.EntityFramework;
using Microsoft.Practices.Unity;

namespace TPFinal.Model
{
    class TextBannerService : ITextBannerService, ITextBanner
    {
        private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IEnumerable<TextBanner> iTextBannerList = new List<TextBanner> { };

        public TextBannerService()
        {
        }

        public String GetText()
        {
            String text = "";
            foreach (TextBanner textBanner in iTextBannerList)
            {
                if (BannerService.IsBannerActive(textBanner))
                { 
                    text = text + " - " + textBanner.text;
                }
            }
            return text;
        }

        public void UpdateBanners(DateTime pDate,TimeSpan pTimeFrom,TimeSpan pTimeTo)
        {
            IUnitOfWork uow = new UnitOfWork(new DigitalSignageDbContext());

            IEnumerable<TextBanner> textBannerEnum = uow.textBannerRepository.GetActives(pDate, pTimeFrom, pTimeTo);
            if (textBannerEnum == null)
                return;

            iTextBannerList = textBannerEnum;

            uow.Complete();

        }

        public void Create(TextBannerDTO pTextBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner banner = new TextBanner();

            try
            {
                textBannerMapper.MapToModel(pTextBannerDTO, banner);
                iUnitOfWork.textBannerRepository.Add(banner);
                iUnitOfWork.Complete();
            }
            catch (ArgumentException)
            {

                throw new ArgumentException();
            }
        }

        public void Update(TextBannerDTO pTextBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner banner = new TextBanner();
            TextBanner oldTextBanner = new TextBanner();

            textBannerMapper.MapToModel(pTextBannerDTO, banner);

            oldTextBanner = iUnitOfWork.textBannerRepository.Get(banner.id);

            oldTextBanner.name = banner.name;
            oldTextBanner.initTime = banner.initTime;
            oldTextBanner.endTime = banner.endTime;
            oldTextBanner.initDate = banner.initDate;
            oldTextBanner.endDate = banner.endDate;
            oldTextBanner.text = banner.text;

            iUnitOfWork.Complete();

        }

        public void Delete(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner oldTextBanner = new TextBanner();
            try
            {
                oldTextBanner = iUnitOfWork.textBannerRepository.Get(pId);
                iUnitOfWork.textBannerRepository.Remove(oldTextBanner);
                iUnitOfWork.Complete();
            }
            catch (ArgumentException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public TextBannerDTO Get(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner TextBanner = new TextBanner();

            try
            {
                return textBannerMapper.SelectorExpression.Compile()(iUnitOfWork.textBannerRepository.Get(pId));
            }
            catch (ArgumentException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerable<TextBannerDTO> GetAll()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            IEnumerator<TextBanner> textBanners = iUnitOfWork.textBannerRepository.GetAll().GetEnumerator();
            IList<TextBannerDTO> textBannersDTO = new List<TextBannerDTO> { };

            while (textBanners.MoveNext())
            {
                textBannersDTO.Add(textBannerMapper.SelectorExpression.Compile()(textBanners.Current));
            }

            return textBannersDTO;   
        }
    }
}
