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
            bool iUpdateAvailable = context.Trigger.JobDataMap.GetBoolean("updateAvailable");
            bool iUpdateDone = false;

            IFormatter formatter = new BinaryFormatter();
            Stream campListStream = (MemoryStream)context.Trigger.JobDataMap.Get("campList");
            campListStream.Position = 0;
            IList<Campaign> iCampaignList = (IList<Campaign>)formatter.Deserialize(campListStream);


            //Si habia una imagen y Campaña actual activa y tiene imagenes todavia
            if (iActualImage>-1 &&iActualImage < iCampaignList.ElementAt(iActualCampaign).imagesList.Count - 1
                && CampaignService.IsCampaignActive(iCampaignList.ElementAt(iActualCampaign)))
            {
                iActualImage++;
            }
            else
            {
                //Pasamos a la campaña siguiente, mientras haya otra y la actual no este activa
                do
                {
                    iActualCampaign++;
                }
                while (iActualCampaign <= iCampaignList.Count - 1 && !CampaignService.IsCampaignActive(iCampaignList.ElementAt(iActualCampaign)));

                //Si se encontro una campaña activa
                if ((iActualCampaign <= iCampaignList.Count - 1))
                {
                    iActualImage = 0;
                }
                //Si se terminaron las campañas
                else
                {
                    //Si hay nueva lista actualizamos
                    if (iUpdateAvailable)
                    {
                        iUpdateDone = true;

                        Stream newCampListStream = (MemoryStream)context.Trigger.JobDataMap.Get("newCampList");
                        newCampListStream.Position = 0;
                        IList<Campaign> iNewCampaignList = (IList<Campaign>)formatter.Deserialize(newCampListStream);


                        if (!iNewCampaignList.Any(campaign => CampaignService.IsCampaignActive(campaign)))
                            iActualImage = -1;
                        else
                        {
                            iActualImage = 0;
                            iActualCampaign = 0;
                            while (!CampaignService.IsCampaignActive(iNewCampaignList.ElementAt(iActualCampaign)))
                            {
                                iActualCampaign++;
                            }
                        }
                    }
                    //Sino hay que empezar desde el principio
                    else
                    {
                        if (!iCampaignList.Any(campaign => CampaignService.IsCampaignActive(campaign)))
                            iActualImage = -1;
                        else
                        {
                            iActualImage = 0;
                            iActualCampaign = 0;
                            while (!CampaignService.IsCampaignActive(iCampaignList.ElementAt(iActualCampaign)))
                            {
                                iActualCampaign++;
                            }
                        }
                    }
                }
            }//Fin if-else

            context.Trigger.JobDataMap.Put("indexCampaign", iActualCampaign);
            context.Trigger.JobDataMap.Put("indexImage", iActualImage);
            context.Trigger.JobDataMap.Put("updateDone", iUpdateDone);
        }
    }
}
