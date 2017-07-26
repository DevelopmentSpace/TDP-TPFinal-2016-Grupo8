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
	/// <summary>
	/// Servicio encargado de administrar banners RSS
	/// </summary>
    class RssBannerService : IRssBannerService, ITextBanner
    {
		/// <summary>
		/// Logger
		/// </summary>
        private static readonly ILog cLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Lista de banners RSS
		/// </summary>
        IEnumerable<RssBanner> iRssBannerList = new List<RssBanner>() { };


        /******************************************************************/
        /***********************TEXT BANNER INTERFACE***********************/
        /******************************************************************/

        /// <summary>
        /// Obtiene el texto actual a mostrar
        /// </summary>
        /// <returns>String de texto</returns>
        public String GetText()
        {
            String text = "";

            if (iRssBannerList == null)
                return text;

            //por cada banner
            foreach (RssBanner rssBanner in iRssBannerList)
            {
                //activo..
                if (BannerService.IsBannerActive(rssBanner))
                {
                    //concatena la descripcion del los items
                    foreach (RssItem item in rssBanner.items)
                    {
                        text = text + " - " + item.description;
                    }
                }
            }
            return text;
        }

        /// <summary>
        /// Actualiza los banners con la base de datos
        /// </summary>
        /// <param name="pDate">Fecha a considerar</param>
        /// <param name="pTimeFrom">Hora de inicio</param>
        /// <param name="pTimeTo">Hora de fin</param>
        public void UpdateBanners(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo)
        {
            IUnitOfWork uow = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());

            cLogger.Info("Actualizando rss Banner desde la base de datos");
            IEnumerable<RssBanner> rssBannerEnum = uow.rssBannerRepository.GetActives(pDate, pTimeFrom, pTimeTo);
            if (rssBannerEnum == null)
            {
                return;
            }
            IEnumerator<RssBanner> e = rssBannerEnum.GetEnumerator();

            SyndicationFeedRssReader feed = new SyndicationFeedRssReader();

            //Por cada elemento
            while (e.MoveNext())
            {
                //Intenta obtener nuevos feeds
                try
                {
                    IEnumerable<RssItem> items = feed.Read(e.Current.url);
                    e.Current.items.Clear();
                    e.Current.items = items.ToList();
                    uow.Complete();
                }
                catch (Exception)
                {
                }
            }

            iRssBannerList = rssBannerEnum;
        }

        /******************************************************************/
        /********************************CRUD******************************/
        /******************************************************************/

        /// <summary>
        /// Agrega un banner
        /// </summary>
        /// <param name="pRssBannerDTO">Banner a agregar</param>
        public void Create(RssBannerDTO pRssBannerDTO)
		{
			IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
			RssBannerMapper RssBannerMapper = new RssBannerMapper();
			RssBanner banner = new RssBanner();

			cLogger.Info("Creando RssBanner");
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

		/// <summary>
		/// Actualiza un banner
		/// </summary>
		/// <param name="pRssBannerDTO">Banner a actualizar</param>
		public void Update(RssBannerDTO pRssBannerDTO)
		{
			IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
			RssBannerMapper RssBannerMapper = new RssBannerMapper();
			RssBanner banner = new RssBanner();
			RssBanner oldRssBanner = new RssBanner();

			RssBannerMapper.MapToModel(pRssBannerDTO, banner);

			cLogger.Info("Actualizando rss Banner");

			oldRssBanner = iUnitOfWork.rssBannerRepository.Get(banner.id);

			oldRssBanner.name = banner.name;
			oldRssBanner.initTime = banner.initTime;
			oldRssBanner.endTime = banner.endTime;
			oldRssBanner.initDate = banner.initDate;
			oldRssBanner.endDate = banner.endDate;
			oldRssBanner.items.Clear();
			oldRssBanner.url = banner.url;

			iUnitOfWork.Complete();

		}

		/// <summary>
		/// Eliminar un banner
		/// </summary>
		/// <param name="pId">Banner a eliminar</param>
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
        /// <summary>
		/// Obtiene un banner
		/// </summary>
		/// <param name="pId">Id del banner a obtener</param>
		/// <returns>Banner con Id dado</returns>
		public RssBannerDTO Get(int pId)
		{
			IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
			RssBannerMapper textRssBannerMapper = new RssBannerMapper();
			RssBanner TextBanner = new RssBanner();

			cLogger.Info("Obteniendo rss Banner por id");
			try
			{
				return textRssBannerMapper.SelectorExpression.Compile()(iUnitOfWork.rssBannerRepository.Get(pId));
			}
			catch (ArgumentException)
			{
				throw new IndexOutOfRangeException();
			}
		}

		/// <summary>
		/// Obtiene todos los banners
		/// </summary>
		/// <returns>Enumerable con banners</returns>
		public IEnumerable<RssBannerDTO> GetAll()
		{
			IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
			RssBannerMapper textRssBannerMapper = new RssBannerMapper();
			IEnumerator<RssBanner> rssBanners = iUnitOfWork.rssBannerRepository.GetAll().GetEnumerator();
			IList<RssBannerDTO> rssBannersDTO = new List<RssBannerDTO> { };

			cLogger.Info("Obteniendo todos los rss Banner");

			while (rssBanners.MoveNext())
			{
				rssBannersDTO.Add(textRssBannerMapper.SelectorExpression.Compile()(rssBanners.Current));
			}

			return rssBannersDTO;
		}        
    }
}

