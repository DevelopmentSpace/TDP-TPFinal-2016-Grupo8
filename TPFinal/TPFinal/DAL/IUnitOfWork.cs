using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.DAL
{
    /// <summary>
    /// Representa una transaccion con la base de datos
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Brinda acceso al repositorio de banners
        /// </summary>
        IBannerRepository bannerRepository { get;}

        /// <summary>
        /// Brinda acceso al repositorio de campañas
        /// </summary>
        ICampaignRespository campaignRepository { get; }

        /// <summary>
        /// Brinda acceso al repositorio de banners RSS
        /// </summary>
        IRssBannerRepository rssBannerRepository { get; }

        /// <summary>
        /// Brinda acceso al repositorio de banners estáticos
        /// </summary>
        ITextBannerRepository textBannerRepository { get; }

        /// <summary>
        /// Confirma la transaccion
        /// </summary>
        void Complete();
    }
}
