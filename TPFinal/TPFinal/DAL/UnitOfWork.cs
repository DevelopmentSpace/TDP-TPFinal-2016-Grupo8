using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DAL.EntityFramework;

namespace TPFinal.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        //Almacena el Contexto a utilizar en los repositorios
        private readonly DigitalSignageDbContext iDbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pContext">Contexto a utilizar en los repositorios</param>
        public UnitOfWork(DigitalSignageDbContext pContext)
        {
            if (pContext == null)
            {
                throw new ArgumentNullException(nameof(pContext));
            }

            this.iDbContext = pContext;
            this.campaignRepository = new CampaignRepository(this.iDbContext);
            this.bannerRepository = new BannerRepository(this.iDbContext);
            this.rssBannerRepository = new RssBannerRepository(this.iDbContext);
            this.textBannerRepository = new TextBannerRepository(this.iDbContext);
        }

        /// <summary>
        /// Repositorio de Cuentas
        /// </summary>
        public ICampaignRespository campaignRepository
        {
            get; private set;
        }

        /// <summary>
        /// Repositorio de Clientes
        /// </summary>
        public IBannerRepository bannerRepository
        {
            get; private set;
        }

        public ITextBannerRepository textBannerRepository
        {
            get; private set;
        }

        /// <summary>
        /// Repositorio de Clientes
        /// </summary>
        public IRssBannerRepository rssBannerRepository
        {
            get; private set;
        }

        /// <summary>
        /// Metodo para persistir los cambios
        /// </summary>
        public void Complete()
        {
            this.iDbContext.SaveChanges();
        }

        /// <summary>
        /// Metodo para terminar la transaccion
        /// </summary>
        public void Dispose()
        {
            this.iDbContext.Dispose();
        }
    }
}
