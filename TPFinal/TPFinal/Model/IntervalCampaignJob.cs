using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using TPFinal.Model;
using Microsoft.Practices.Unity;

namespace TPFinal.Model
{
    class IntervalCampaignJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CampaignService service = IoCContainerLocator.Container.Resolve<CampaignService>();

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
                    //Esto sirve para que no muestra campañas que no deben mostrar
                    if (No hay ninguna campaña activa) 
                    {
                        Mostrar imagen por defecto.
                    }
                    else
                        //Esto adelanta hasta que encuentra la siguiente campaña activa. 
                        while (!service.IsCampaignActive(service.iCampaignList.ElementAt(service.iActualCampaign)))
                        {
                            service.iActualCampaign++;
                            if (service.iActualCampaign > service.iCampaignList.Count() - 1)
                            {
                                service.iActualCampaign = 0;
                            }
                    }
                }
            service.NotifyListeners();*/
        }
    }
    }
