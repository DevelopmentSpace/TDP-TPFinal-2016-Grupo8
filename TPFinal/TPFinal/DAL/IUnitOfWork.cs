using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal.DAL
{
    public interface IUnitOfWork : IDisposable
    {

        IBannerRepository bannerRepository { get;}

        ICampaignRespository campaignRepository { get; }

        IRssBannerRepository rssBannerRepository { get; }

        ITextBannerRepository textBannerRepository { get; }

        void Complete();
    }
}
