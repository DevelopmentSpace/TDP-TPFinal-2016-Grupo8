using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.Domain
{
    public class RssItem
    {
        public String description { get; set; }

        public Uri url { get; set; }

        public DateTime publishingDate { get; set; }
    }
}   
