using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL.EntityFramework
{
    class CampaignRepository : EFRepository<Campaign, DigitalSignageDbContext>, ICampaignRespository
    {

        DbContext iDbContext;

        public CampaignRepository(DigitalSignageDbContext pContext) : base(pContext)
        {
            this.iDbContext = pContext;
        }

        public IList<Campaign> GetActives(DateTime pDateFrom, DateTime pDateTo)
        {
            return from campaign in this.iDbContext.Set<Campaign>()
                   where  ()  || () 
                   select campaign;

            /*return from campaign in this.iDbContext.Set<Campaign>()
                   select new { Campaign = campaign, InitDate = campaign.Movements.Sum(pMovement => pMovement.Amount) } into accountWithBalance
                   where accountWithBalance.Balance < 0 && Math.Abs(accountWithBalance.Balance) > accountWithBalance.Account.OverdraftLimit
                   select accountWithBalance.Account;*/
        }
    }
}
