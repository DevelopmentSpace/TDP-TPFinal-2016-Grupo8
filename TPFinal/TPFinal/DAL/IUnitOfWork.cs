using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.DAL
{
    interface IUnitOfWork : IDisposable
    {

        IBannerRepository BannerRepository { get;}

        ICampaignRespository CampaignRepository { get; }

        IRssBannerRepository RssBannerRepository { get; }

        ITextBannerRepository TextBannerRepository { get; }

        void Complete();
    }
}
