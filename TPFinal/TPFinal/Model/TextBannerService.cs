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
    class TextBannerService : ITextBanner
    {
        private static readonly ILog cLogger = LogManager.GetLogger<TextBannerService>();

        private IEnumerable<TextBanner> iTextBannerList = new List<TextBanner> { };

        /// <summary>
        /// Contexto a utilizar
        /// </summary>
        DigitalSignageDbContext iDbContext;

        public TextBannerService()
        {
            iDbContext = IoCContainerLocator.Container.Resolve<TPFinal.DAL.EntityFramework.DigitalSignageDbContext>();
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

        public void Update()
        {
            IUnitOfWork uow = new UnitOfWork(iDbContext);
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = DateTime.Now.TimeOfDay;
            TimeSpan timeTo = timeFrom.Add(new TimeSpan(0, 0, 30, 0));

            IEnumerable<TextBanner> textBannerEnum = uow.textBannerRepository.GetActives(date, timeFrom, timeTo);

            iTextBannerList = textBannerEnum;

            uow.Complete();

        }

        public void Create(TextBannerDTO pTextBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner banner = new TextBanner();

            textBannerMapper.MapToModel(pTextBannerDTO, banner);
            iUnitOfWork.textBannerRepository.Add(banner);

            iUnitOfWork.Complete();

        }

        public void Update(TextBannerDTO pTextBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
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
           IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner oldTextBanner = new TextBanner();

            oldTextBanner = iUnitOfWork.textBannerRepository.Get(pId);

            iUnitOfWork.textBannerRepository.Remove(oldTextBanner);

            iUnitOfWork.Complete();
        }

        public TextBannerDTO Get(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner TextBanner = new TextBanner();

            return textBannerMapper.SelectorExpression.Compile()(iUnitOfWork.textBannerRepository.Get(pId));
        }

        public IEnumerable<TextBannerDTO> GetAll()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            IEnumerator<TextBanner> textBanners = iUnitOfWork.textBannerRepository.GetAll().GetEnumerator();
            IList<TextBannerDTO> textBannersDTO = new List<TextBannerDTO> { };

            while (textBanners.MoveNext())
            {
                textBannersDTO.Add(textBannerMapper.SelectorExpression.Compile()(textBanners.Current));
            }

            return textBannersDTO;   
        }

        public int GetLastTextBannerId()
        {
            cLogger.Info("Obteniendo id de el ultimo banner de texto");
            IUnitOfWork iUnitOfWork = new UnitOfWork(iDbContext);
            IEnumerable<TextBanner> allTextBanner = iUnitOfWork.textBannerRepository.GetAll();
            if (!allTextBanner.Any())
            {
                return (int)1;
            }
            else
            {
                return (allTextBanner.Last().id + 1);
            }
        }

    }
}
