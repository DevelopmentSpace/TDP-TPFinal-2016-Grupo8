using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.Model
{
    /// <summary>
    /// Interfaz de servicios de banner de texto
    /// </summary>
    interface ITextBanner
    {
        /// <summary>
        /// Funcion que se encarga de obtener todos los textos activos de la fuente correspondiente
        /// </summary>
        /// <returns>Cadena de caracteres de todos los textos activos</returns>
        String GetText();

        /// <summary>
        /// Funcion que se encarga de actualizar todos los textos de los banners de la lista de banners teniendo en cuenta que esten activos
        /// </summary>
        /// <param name="pDate">Fecha desde donde se lo quiere obtener</param>
        /// <param name="pTimeFrom">Tiempo desde</param>
        /// <param name="pTimeTo">Tiempo hasta</param>
        void UpdateBanners(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo);
    }
}
