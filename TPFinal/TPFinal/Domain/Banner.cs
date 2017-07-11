using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    public abstract class Banner
    {
        public int id { get; set; }

        public int interval { get; set; }
    
        public DateTime initDate { get; set; }

        public DateTime endDate { get; set; }

        public DateTime initTime { get; set; }

        public DateTime endTime { get; set; }

    }

}

