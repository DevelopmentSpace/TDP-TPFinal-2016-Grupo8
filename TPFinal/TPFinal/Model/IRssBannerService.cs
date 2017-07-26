using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DTO;

namespace TPFinal.Model
{
    interface IRssBannerService
    {
        void Create(RssBannerDTO pRssBannerDTO);

        void Update(RssBannerDTO pRssBannerDTO);

        void Delete(int pId);

        RssBannerDTO Get(int pId);

        IEnumerable<RssBannerDTO> GetAll();
    }
}
