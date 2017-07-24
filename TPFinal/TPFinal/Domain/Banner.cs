using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    /// <summary>
    /// Representa un Banner genérico con restriccion de tiempo para mostrarlo
    /// </summary>
    [Serializable]
    public class Banner
    {
        /// <summary>
        /// Clave unica del banner
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Nombre del banner
        /// </summary>
        public String name { get; set; }

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


    }

}

