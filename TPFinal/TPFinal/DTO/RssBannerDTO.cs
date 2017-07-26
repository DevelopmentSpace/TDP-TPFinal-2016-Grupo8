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
    public class RssBannerDTO : BannerDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public String url { get; set; }
    }

    public class RssBannerMapper : MapperBase<RssBanner, RssBannerDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BannerMapper _bannerMapper = new BannerMapper();
        public override Expression<Func<RssBanner, RssBannerDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<RssBanner, RssBannerDTO>>)(p => new RssBannerDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    url = p.url,
                })).MergeWith(this._bannerMapper.SelectorExpression);
            }
        }

        public override void MapToModel(RssBannerDTO dto, RssBanner model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.url = dto.url;
            this._bannerMapper.MapToModel(dto, model);
        }
    }
}
