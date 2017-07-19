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

            if (service.IsCampaignActive(service.ICampaignList.ElementAt(service.IActualCampaign)))
                {
                service.IActualImage++;

                    if (service.IActualImage > service.ICampaignList.ElementAt(service.IActualCampaign).imagesList.Count() - 1)
                    {
                    service.IActualImage = 0;
                    service.IActualCampaign++;

                        if (service.IActualCampaign > service.ICampaignList.Count() - 1)
                        {
                        service.IActualCampaign = 0;
                        }
                    }

                    if (service.IActualCampaign > service.ICampaignList.Count() - 1)
                    {
                    service.IActualImage = 0;
                    service.IActualCampaign = 0;
                    }
                }
                else
                {
                service.IActualImage = 0;
                    //Esto sirve para que no muestra campañas que no deben mostrar
                    /*
                    if (No hay ninguna campaña activa) 
                    {
                        Mostrar imagen por defecto.
                    }
                    else*/
                        //Esto adelanta hasta que encuentra la siguiente campaña activa. 
                        while (!service.IsCampaignActive(service.ICampaignList.ElementAt(service.IActualCampaign)))
                        {
                            service.IActualCampaign++;
                            if (service.IActualCampaign > service.ICampaignList.Count() - 1)
                            {
                                service.IActualCampaign = 0;
                            }
                    }
                }
            service.NotifyListeners();
        }
    }
}
