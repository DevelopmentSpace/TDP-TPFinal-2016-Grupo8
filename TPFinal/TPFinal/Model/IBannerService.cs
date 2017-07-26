using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Model
{
    /// <summary>
    /// Interfaz del servicio de banners
    /// </summary>
    interface IBannerService
    {
        /// <summary>
        /// Funcion que agrega servicios que brinden textos a el servicio de banner.
        /// </summary>
        /// <param name="textBanner">Servicio de textos</param>
        void AddService(ITextBanner textBanner);

        /// <summary>
        /// Funcion que otorga todos los textos activos en ese momento de todos los servicios de textos.
        /// </summary>
        /// <returns>Texto que tienen todos los banners activos</returns>
        String GetText();

        /// <summary>
        /// Funcion que realiza una actualizacion forzosa con la base de datos y actualiza los banners de los servicios.
        /// </summary>
        void ForceUpdate();
    }
}
