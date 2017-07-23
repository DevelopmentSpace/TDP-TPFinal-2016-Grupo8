﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    /// <summary>
    /// Representa una campaña de imagenes con restriccion de fecha y hora de exposicion.
    /// </summary>
    [Serializable]
    public class Campaign //: ISerializable
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
        public IList<ByteImage> imagesList { get; set; }
        /*

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("interval", interval);
            info.AddValue("initDate", initDate);
            info.AddValue("endDate", endDate);
            info.AddValue("initTime", endTime);
            info.AddValue("endTime", endTime);
            info.AddValue("imageList", imagesList, typeof(List<ByteImage>));
        }*/
    }
}
