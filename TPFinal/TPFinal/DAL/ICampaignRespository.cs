using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Domain;

namespace TPFinal.DAL
{
    public interface ICampaignRespository : IRepository<Campaign>
    {

        IEnumerable<Campaign> GetActives(DateTime pDate, TimeSpan pTimeFrom, TimeSpan pTimeTo);
        
    }
}
