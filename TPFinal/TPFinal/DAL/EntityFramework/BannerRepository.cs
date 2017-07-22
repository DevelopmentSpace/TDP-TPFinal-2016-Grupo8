using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework
{
    /// <summary>
    /// Implementacion del repositorio de Banners
    /// </summary>
    class BannerRepository : EFRepository<Banner, DigitalSignageDbContext>, IBannerRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pContext">Contexto a utilizar para el repositorio</param>
        public BannerRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
        }
    }
}
