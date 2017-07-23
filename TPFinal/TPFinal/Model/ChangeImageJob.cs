using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TPFinal.Domain;

namespace TPFinal.Model
{
    [PersistJobDataAfterExecutionAttribute()]
    [DisallowConcurrentExecution()]
    class ChangeImageJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            int iActualCampaign = context.Trigger.JobDataMap.GetInt("indexCampaign");
            int iActualImage = context.Trigger.JobDataMap.GetInt("indexImage");

            MemoryStream s = (MemoryStream)context.Trigger.JobDataMap.Get("listCampaign");
            IFormatter formatter = new BinaryFormatter();
            IList<Campaign> iCampaignList = (IList<Campaign>)formatter.Deserialize(s);

            if (CampaignService.IsCampaignActive(iCampaignList.ElementAt(iActualCampaign)))
            {
                iActualImage++;

                if (iActualImage > iCampaignList.ElementAt(iActualCampaign).imagesList.Count() - 1)
                {
                    iActualImage = 0;
                    iActualCampaign++;
                    if (iActualCampaign > iCampaignList.Count() - 1)
                    {
                        iActualCampaign = 0;
                    }
                }
            }
            else
            {
                iActualImage = 0;
                //Esto sirve para que no muestra campañas que no deben mostrar
                if (iCampaignList.Any(campaign => CampaignService.IsCampaignActive(campaign)) )
                {
                    //SHOW PREDIFINITE IMAGE
                }
                else
                    while (!CampaignService.IsCampaignActive(iCampaignList.ElementAt(iActualCampaign)))
                    {
                        iActualCampaign++;
                        if (iActualCampaign > iCampaignList.Count() - 1)
                        {
                            iActualCampaign = 0;
                        }
                }
            }
            
            context.Trigger.JobDataMap.Put("indexCampaign", iActualCampaign);
            context.Trigger.JobDataMap.Put("indexImage", iActualImage);
        }
    }
}
