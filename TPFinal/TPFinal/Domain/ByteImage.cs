using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    /// <summary>
    /// Representa una imagen
    /// </summary>
    [Serializable]
    public class ByteImage
    {
        /// <summary>
        /// Clave unica de la imagen
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// ForeignKey de la imagen en relacion con la campaña
        /// </summary>
        public virtual int campaignId { get; set; }

        /// <summary>
        /// Array de bytes correspondientes a la imagen
        /// </summary>
        public Byte[] bytes { get; set; }
    }
}
