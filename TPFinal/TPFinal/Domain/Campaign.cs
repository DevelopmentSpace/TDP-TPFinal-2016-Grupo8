using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    /// <summary>
    /// Representa una campaña de imagenes con restriccion de fecha y hora de exposicion.
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// Clave unica de la campaña
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre de la campaña
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Intervalo de cambio de imagenes de la campaña.
        /// </summary>
        public int interval { get; set; }

        /// <summary>
        /// Fecha de inicio de exposicion
        /// </summary>
        public DateTime initDate { get; set; }

        /// <summary>
        /// Fecha de fin de exposicion
        /// </summary>
        public DateTime endDate { get; set; }

        /// <summary>
        /// Hora de inicio de exposicion
        /// </summary>
        public TimeSpan initTime { get; set; }

        /// <summary>
        /// Hora de fin de exposicion
        /// </summary>
        public TimeSpan endTime { get; set; }

        /// <summary>
        /// Lista de imagenes de la campaña
        /// </summary>
        public virtual IList<ByteImage> imagesList { get; set; }

    }
}
