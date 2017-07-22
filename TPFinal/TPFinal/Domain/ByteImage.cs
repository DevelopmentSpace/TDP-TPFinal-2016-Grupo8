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
    public class ByteImage
    {
        /// <summary>
        /// Clave unica de la imagen
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Array de bytes correspondientes a la imagen
        /// </summary>
        public Byte[] bytes { get; set; }
    }
}
