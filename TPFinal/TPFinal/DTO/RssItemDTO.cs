using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DTO.Infrastructure;
using TPFinal.Domain;

namespace TPFinal.DTO
{
    public class RssItemDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int id { get; set; }
        public String description { get; set; }
        public String url { get; set; }
        public DateTime publishingDate { get; set; }
    }

    public class RssItemMapper : MapperBase<RssItem, RssItemDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<RssItem, RssItemDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<RssItem, RssItemDTO>>)(p => new RssItemDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    id = p.id,
                    description = p.description,
                    url = p.url,
                    publishingDate = p.publishingDate
                }));
            }
        }

        public override void MapToModel(RssItemDTO dto, RssItem model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.id = dto.id;
            model.description = dto.description;
            model.url = dto.url;
            model.publishingDate = dto.publishingDate;

        }
    }
}
