using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL
{
    interface ICampaignRespository: IRepository<Campaign>
    {

        IEnumerable<Campaign> GetActives(DateTime pDateFrom, DateTime pDateTo);
        
    }
}
