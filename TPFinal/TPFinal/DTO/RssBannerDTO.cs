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
        public String description { get; set; }
        public IEnumerable<RssItemDTO> items { get; set; }
    }

    public class RssBannerMapper : MapperBase<RssBanner, RssBannerDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private RssItemMapper _rssItemMapper = new RssItemMapper();
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
                    description = p.description,
                    items = p.items.AsQueryable().Select(this._rssItemMapper.SelectorExpression)
                })).MergeWith(this._bannerMapper.SelectorExpression);
            }
        }

        public override void MapToModel(RssBannerDTO dto, RssBanner model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.url = dto.url;
            model.description = dto.description;
            this._bannerMapper.MapToModel(dto, model);
        }
    }
}
