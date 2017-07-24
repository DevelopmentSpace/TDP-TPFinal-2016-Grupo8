using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    /// <summary>
    /// Representa un item RSS de un banner RSS
    /// </summary>
    [Serializable]
    public class RssItem
    {
        /// <summary>
        /// Clave unica del item RSS
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Descripcion del Item RSS
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// URL asociada al item
        /// </summary>
        public String url { get; set; }

        /// <summary>
        /// Fecha de publicacion
        /// </summary>
        public DateTime publishingDate { get; set; }
    }
}   
