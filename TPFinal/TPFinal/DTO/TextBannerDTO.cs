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
    public class TextBannerDTO : BannerDTO
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public String text { get; set; }
    }

    public class TextBannerMapper : MapperBase<TextBanner, TextBannerDTO>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        private BannerMapper _bannerMapper = new BannerMapper();
        public override Expression<Func<TextBanner, TextBannerDTO>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<TextBanner, TextBannerDTO>>)(p => new TextBannerDTO()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    text = p.text
                })).MergeWith(this._bannerMapper.SelectorExpression);
            }
        }

        public override void MapToModel(TextBannerDTO dto, TextBanner model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.text = dto.text;
            this._bannerMapper.MapToModel(dto, model);
        }
    }
}
