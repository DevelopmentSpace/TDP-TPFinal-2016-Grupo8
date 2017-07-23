using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.Model
{
    class SerializableCampaign
    {

        public SerializableCampaign(Campaign pCampaign)
        {
            this.id = pCampaign.id;
            this.interval = pCampaign.interval;
            this.initDate = pCampaign.initDate;
            this.endDate = pCampaign.endDate;
            this.initTime = pCampaign.initTime;
            this.endTime = pCampaign.endTime;
        }

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
        public virtual List<ByteImage> imagesList { get; set; }
    }
}
