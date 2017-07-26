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
    /// <summary>
    /// Servicio encargado de administrar banners de texto
    /// </summary>
    class TextBannerService : ITextBannerService, ITextBanner
    {
        private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Enumerable que contiene todos los textos activos en ese momento.
        /// </summary>
        private IEnumerable<TextBanner> iTextBannerList = new List<TextBanner> { };

        /******************************************************************/
        /***********************TEXT BANNER INTERFACE**********************/
        /******************************************************************/

        /// <summary>
        /// Funcion que se encarga de obtener todos los textos activos de la lista de textos
        /// </summary>
        /// <returns>Cadena de caracteres de todos los TextBanners activos</returns>
        public String GetText()
        {
            String text = "";
            cLogger.Info("Comenzando pedido de texto");
            foreach (TextBanner textBanner in iTextBannerList)
            {
                if (BannerService.IsBannerActive(textBanner))
                { 
                    text = text + " - " + textBanner.text;
                }
            }
            cLogger.Info("Enviando texto solicitado");
            return text;
        }

        /// <summary>
        /// Funcion que se encarga de actualizar todos los textos de los banners de la lista de banners teniendo en cuenta que esten activos
        /// </summary>
        /// <param name="pDate">Fecha desde donde se lo quiere obtener</param>
        /// <param name="pTimeFrom">Tiempo desde</param>
        /// <param name="pTimeTo">Tiempo hasta</param>
        public void UpdateBanners(DateTime pDate,TimeSpan pTimeFrom,TimeSpan pTimeTo)
        {
            cLogger.Info("Actualizando banners");
            IUnitOfWork uow = new UnitOfWork(new DigitalSignageDbContext());

            IEnumerable<TextBanner> textBannerEnum = uow.textBannerRepository.GetActives(pDate, pTimeFrom, pTimeTo);
            if (textBannerEnum == null)
                return;

            iTextBannerList = textBannerEnum;
            uow.Complete();

            cLogger.Info("Banners actualizados");

        }

        /******************************************************************/
        /********************************CRUD******************************/
        /******************************************************************/


        /// <summary>
        /// Añade un banner de texto
        /// </summary>
        /// <param name="pTextBannerDTO">Banner de texto a agregar</param>
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
                cLogger.Info("Nuevo banner de texto agregado");
            }
            catch (ArgumentException)
            {

                throw new ArgumentException();
            }
        }


        /// <summary>
        /// Actualiza un banner de texto
        /// </summary>
        /// <param name="pTextBannerDTO">Banner de texto a actualizar</param>
        public void Update(TextBannerDTO pTextBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner banner = new TextBanner();
            TextBanner oldTextBanner = new TextBanner();

            textBannerMapper.MapToModel(pTextBannerDTO, banner);

            oldTextBanner = iUnitOfWork.textBannerRepository.Get(banner.id);
            
            //Actualiza el banner de texto
            oldTextBanner.name = banner.name;
            oldTextBanner.initTime = banner.initTime;
            oldTextBanner.endTime = banner.endTime;
            oldTextBanner.initDate = banner.initDate;
            oldTextBanner.endDate = banner.endDate;
            oldTextBanner.text = banner.text;

            iUnitOfWork.Complete();
            cLogger.Info("Banner de texto actualizado");

        }
        
        /// <summary>
        /// Elimina banner de texto
        /// </summary>
        /// <param name="pId">Id del banner de texto a eliminar</param>
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
                cLogger.Info("Banner de texto eliminado");
            }
            catch (ArgumentException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Obtiene un banner de texto por su ID
        /// </summary>
        /// <param name="pId">Id del banner de texto</param>
        /// <returns>Banner de texto con el Id dado</returns>
        public TextBannerDTO Get(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            TextBanner TextBanner = new TextBanner();

            try
            {
                cLogger.Info("Obteniendo banner de texto por id");
                return textBannerMapper.SelectorExpression.Compile()(iUnitOfWork.textBannerRepository.Get(pId));
            }
            catch (ArgumentException)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Obtiene todos los texto de banner
        /// </summary>
        /// <returns>Enumerable con todos los banner de texto</returns>
        public IEnumerable<TextBannerDTO> GetAll()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DigitalSignageDbContext());
            TextBannerMapper textBannerMapper = new TextBannerMapper();
            IEnumerator<TextBanner> textBanners = iUnitOfWork.textBannerRepository.GetAll().GetEnumerator();
            IList<TextBannerDTO> textBannersDTO = new List<TextBannerDTO> { };

            cLogger.Info("Obteniendo todos los banners de texto.");


            //Transforma a DTO
            while (textBanners.MoveNext())
            {
                textBannersDTO.Add(textBannerMapper.SelectorExpression.Compile()(textBanners.Current));
            }

            return textBannersDTO;   
        }
    }
}
