using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.DTO;

namespace TPFinal.Model
{
    interface ICampaignService : IObservable
    {
        void Create(CampaignDTO pCampaignDTO);

        void Update(CampaignDTO pCampaignDTO);

        void Delete(int pId);

        CampaignDTO GetCampaign(int pId);

        IEnumerable<CampaignDTO> GetAll();

        byte[] GetActualImage();
    }
}
