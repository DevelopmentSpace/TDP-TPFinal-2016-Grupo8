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
    public class CampaignDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int id { get; set; }
        public String name { get; set; }
        public int interval { get; set; }
        public DateTime initDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public IEnumerable<ByteImageDTO> imagesList { get; set; }
    }

    public class CampaignMapper : MapperBase<Campaign, CampaignDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private ByteImageMapper _byteImageMapper = new ByteImageMapper();
        public override Expression<Func<Campaign, CampaignDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Campaign, CampaignDTO>>)(p => new CampaignDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    id = p.id,
                    name = p.name,
                    interval = p.interval,
                    initDateTime = p.initDateTime,
                    endDateTime = p.endDateTime,
                    imagesList = p.imagesList.AsQueryable().Select(this._byteImageMapper.SelectorExpression)
                }));
            }
        }

        public override void MapToModel(CampaignDTO dto, Campaign model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.id = dto.id;
            model.name = dto.name;
            model.interval = dto.interval;
            model.initDateTime = dto.initDateTime;
            model.endDateTime = dto.endDateTime;

        }
    }
}
