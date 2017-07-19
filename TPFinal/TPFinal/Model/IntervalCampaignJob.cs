using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using TPFinal.Model;

namespace TPFinal.Model
{
    class IntervalCampaignJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;

            CampaignService service = (CampaignService)dataMap.Get("service");

                if (service.IsCampaignActive(service.iCampaignList.ElementAt(service.iActualCampaign)))
                {
                service.iActualImage++;

                    if (service.iActualImage > service.iCampaignList.ElementAt(service.iActualCampaign).imagesList.Count() - 1)
                    {
                    service.iActualImage = 0;
                    service.iActualCampaign++;

                        if (service.iActualCampaign > service.iCampaignList.Count() - 1)
                        {
                        service.iActualCampaign = 0;
                        }
                    }

                    if (service.iActualCampaign > service.iCampaignList.Count() - 1)
                    {
                    service.iActualImage = 0;
                    service.iActualCampaign = 0;
                    }
                }
                else
                {
                service.iActualImage = 0;

                    while (!service.IsCampaignActive(service.iCampaignList.ElementAt(service.iActualCampaign)))
                    {
                    service.iActualCampaign++;

                        if (service.iActualCampaign > service.iCampaignList.Count() - 1)
                        {
                        service.iActualCampaign = 0;
                        }
                    }
                }
            service.NotifyListeners();
            }
        }
    }
