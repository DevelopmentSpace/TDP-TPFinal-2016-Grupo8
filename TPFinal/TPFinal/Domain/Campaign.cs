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

        public DateTime initDate { get; set; }

        public DateTime endDate { get; set; }

        public DateTime initTime { get; set; }

        public DateTime endTime { get; set; }

        public virtual IList<Byte[]> imagesList { get; set; }

    }
}
