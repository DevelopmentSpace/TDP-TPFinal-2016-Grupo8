using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    /// <summary>
    /// Representa una campaña de imagenes.
    /// </summary>
    public class Campaign
    {
        public int id { get; set; }
        
        public int interval { get; set; }

        public DateTime initDateTime { get; set; }

        public DateTime endDateTime { get; set; }



        public virtual IList<ByteImage> imagesList { get; set; }

    }
}
