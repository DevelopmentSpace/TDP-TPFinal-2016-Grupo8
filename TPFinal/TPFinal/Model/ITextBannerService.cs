using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DTO;

namespace TPFinal.Model
{
    interface ITextBannerService
    {
        void Create(TextBannerDTO pTextBannerDTO);

        void Update(TextBannerDTO pTextBannerDTO);

        void Delete(int pId);

        TextBannerDTO Get(int pId);

        IEnumerable<TextBannerDTO> GetAll();
    }
}
