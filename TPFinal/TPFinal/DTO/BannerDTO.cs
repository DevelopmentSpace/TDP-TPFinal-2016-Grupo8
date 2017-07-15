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
    public class BannerDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int id { get; set; }
        public String name { get; set; }
        public int interval { get; set; }
        public DateTime initDate { get; set; }
        public DateTime endDate { get; set; }
        public TimeSpan initTime { get; set; }
        public TimeSpan endTime { get; set; }
    }

    public class BannerMapper : MapperBase<Banner, BannerDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public override Expression<Func<Banner, BannerDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Banner, BannerDTO>>)(p => new BannerDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    id = p.id,
                    name = p.name,
                    interval = p.interval,
                    initDate = p.initDate,
                    endDate = p.endDate,
                    initTime = p.initTime,
                    endTime = p.endTime
                }));
            }
        }

        public override void MapToModel(BannerDTO dto, Banner model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.id = dto.id;
            model.name = dto.name;
            model.interval = dto.interval;
            model.initDate = dto.initDate;
            model.endDate = dto.endDate;
            model.initTime = dto.initTime;
            model.endTime = dto.endTime;

        }
    }
}
