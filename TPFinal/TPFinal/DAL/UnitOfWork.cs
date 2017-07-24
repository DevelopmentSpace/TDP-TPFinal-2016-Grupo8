using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DAL.EntityFramework;

namespace TPFinal.DAL
{
    /// <summary>
    /// Implementacion de la interfaz IUnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ILog cLogger = LogManager.GetLogger<CampaignRepository>();

        //Almacena el Contexto a utilizar en los repositorios
        private readonly DigitalSignageDbContext iDbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pContext">Contexto a utilizar para los repositorios</param>
        public UnitOfWork(DigitalSignageDbContext pContext)
        {
            if (pContext == null)
            {
                cLogger.Error("Intento crear UnitOfWork con contexto nulo");
                throw new ArgumentNullException(nameof(pContext));
            }

            cLogger.Info("Creando instancia de UnitOfWork");

            this.iDbContext = pContext;
            this.campaignRepository = new CampaignRepository(this.iDbContext);
            this.bannerRepository = new BannerRepository(this.iDbContext);
            this.rssBannerRepository = new RssBannerRepository(this.iDbContext);
            this.textBannerRepository = new TextBannerRepository(this.iDbContext);
        }

        /// <summary>
        /// Repositorio de Campañas
        /// </summary>
        public ICampaignRespository campaignRepository
        {
            get; private set;
        }

        /// <summary>
        /// Repositorio de Banners
        /// </summary>
        public IBannerRepository bannerRepository
        {
            get; private set;
        }

        /// <summary>
        /// Repositorios de Banners estaticos.
        /// </summary>
        public ITextBannerRepository textBannerRepository
        {
            get; private set;
        }

        /// <summary>
        /// Repositorio de Banners RSS
        /// </summary>
        public IRssBannerRepository rssBannerRepository
        {
            get; private set;
        }

        /// <summary>
        /// Confirma los cambios
        /// </summary>
        public void Complete()
        {
            cLogger.Info("Confirmando cambios realizados");
            this.iDbContext.SaveChanges();
        }

        /// <summary>
        /// Descarta los cambios
        /// </summary>
        public void Dispose()
        {
            cLogger.Info("Descartando cambios realizados (disposing context)");
            this.iDbContext.Dispose();
        }
    }
}
