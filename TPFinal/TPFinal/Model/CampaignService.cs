using System;
using System.Collections.Generic;
using System.Linq;
using TPFinal.DAL;
using TPFinal.Domain;
using TPFinal.DTO;
using System.Timers;

namespace TPFinal.Model
{
    /// <summary>
    /// Servicio de campañas. Se encarga de ser servicio de todos.
    /// </summary>
    public class CampaignService : IObservable
    {
        /// <summary>
        /// Lista donde se almacenaran todas las campañas actuales. El tiempo de refresco de las campañas se define por iRefreshTime.
        /// </summary>
        private IEnumerable<Campaign> iCampaignList;

        /// <summary>
        /// Lista de escuchadores
        /// </summary>
        private List<IObserver> iObserver = new List<IObserver> { };

        /// <summary>
        /// Indice de la imagen actual de una campaña
        /// </summary>
        private int iActualImage;

        /// <summary>
        /// Indice de campaña actual
        /// </summary>
        private int iActualCampaign;

        //Esto no deberia estar aca.
        private JobScheduler jobScheduler;

        /// <summary>
        /// Creador del servicio de campañas
        /// </summary>
        public CampaignService()
        {
            JobScheduler job = new JobScheduler(this);

            jobScheduler = job;

            iActualCampaign = 0;
            iActualImage = 0;
        }

        public void AddListener(IObserver pListener)
        {
            iObserver.Add(pListener);
        }

        public void RemoveListener(IObserver pListener)
        {
            iObserver.Remove(pListener);
        }

        public void NotifyListeners()
        {
            foreach (IObserver view in iObserver)
                {
                view.Update("Campaign");
                }              
        }

        public void Create(CampaignDTO pCampaignDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            CampaignMapper campaignMapper = new CampaignMapper();
            Campaign campaign = new Campaign();

            campaignMapper.MapToModel(pCampaignDTO, campaign);

            iUnitOfWork.campaignRepository.Add(campaign);

            iUnitOfWork.Complete();

        }

        public void Update(CampaignDTO pCampaignDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            CampaignMapper campaignMapper = new CampaignMapper();
            Campaign campaign = new Campaign();
            Campaign oldCampaign = new Campaign();

            campaignMapper.MapToModel(pCampaignDTO, campaign);

            oldCampaign = iUnitOfWork.campaignRepository.Get(pCampaignDTO.id); //REVISAR SI FUNCIONA

            oldCampaign = campaign;

            iUnitOfWork.Complete();

        }

        public void Delete(CampaignDTO pCampaignDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            CampaignMapper campaignMapper = new CampaignMapper();
            Campaign oldCampaign = new Campaign();

            oldCampaign = iUnitOfWork.campaignRepository.Get(pCampaignDTO.id);

            iUnitOfWork.campaignRepository.Remove(oldCampaign);

            iUnitOfWork.Complete();
        }

        public CampaignDTO GetCampaign(int pId)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            CampaignMapper campaignMapper = new CampaignMapper();

            return campaignMapper.SelectorExpression.Compile()(iUnitOfWork.campaignRepository.Get(pId));

        }

        public IEnumerable<CampaignDTO> GetAllCampaigns()
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            IList<CampaignDTO> campaignAux = new List<CampaignDTO> { };
            CampaignMapper campaignMapper = new CampaignMapper();

            foreach (Campaign campaign in iUnitOfWork.campaignRepository.GetAll().ToList())
            {
                campaignAux.Add(campaignMapper.SelectorExpression.Compile()(iUnitOfWork.campaignRepository.Get(campaign.id)));
            }

            return campaignAux;

        }

        /// <summary>
        /// Obtiene la imagen actual de la campaña actual
        /// </summary>
        /// <returns>Imagen actual</returns>
        public byte[] GetActualImage()
        {
            return iCampaignList.ElementAt(iActualCampaign).imagesList.ElementAt(iActualImage).bytes;
        }

        /// <summary>
        /// Empieza un servicio de campañas. Pone a correr los timers.
        /// </summary>
        public void Start()
        {                       
            jobScheduler.Start();
        }

        /// <summary>
        /// Frena ambos timers.
        /// </summary>
        public void Stop()
        {
            jobScheduler.Stop();
        }

        /// <summary>
        /// Cuando se llega al tiempo de cada intervalo (segun la campaña).
        /// </summary>

        private void OnIntervalTimer(object sender, EventArgs e)
     
        {

           if (IsCampaignActive(this.iCampaignList.ElementAt(this.iActualCampaign)))
            {
                this.iActualImage++;

                if (iActualImage > this.iCampaignList.ElementAt(iActualCampaign).imagesList.Count()-1)
                {
                    iActualImage = 0;
                    iActualCampaign++;

                    if (iActualCampaign > iCampaignList.Count()-1)
                    {
                        iActualCampaign = 0;
                    }
                }

                if (iActualCampaign > iCampaignList.Count()-1)
                {
                    iActualImage = 0;
                    iActualCampaign = 0;
                }
            }
            else
            {
                iActualImage = 0;

                while (!IsCampaignActive(this.iCampaignList.ElementAt(this.iActualCampaign)))
                {
                    iActualCampaign++;

                    if (iActualCampaign > iCampaignList.Count() - 1)
                    {
                        iActualCampaign = 0;
                    }
                }
            }
            NotifyListeners();
        }

        /// <summary>
        /// Cuando se llega al tiempo de cada refresco con la base de datos.
        /// </summary>
        private void OnRefreshTimer(object sender, EventArgs e)
        {

            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            DateTime date = DateTime.Now.Date;
            TimeSpan timeFrom = DateTime.Now.TimeOfDay;
            TimeSpan timeTo = timeFrom.Add(new TimeSpan(0, 0, 0, 0, 30)); //(int)iRefreshTimer.Interval)

            iActualCampaign = 0;
            iActualImage = 0;
            iCampaignList = iUnitOfWork.campaignRepository.GetActives(date, timeFrom, timeTo).ToList();

            //iIntervalTimer.Interval = iCampaignList.ElementAt(iActualCampaign).interval *1000;

            NotifyListeners();
        }


        /// <summary>
        /// Permite saber si una campaña esta activa actualmente
        /// </summary>
        /// <returns>Verdadero si la campaña esta activa o falso si no lo esta</returns>
        public bool IsCampaignActive(Campaign c)
        {
            DateTime date = DateTime.Now.Date;
            TimeSpan time = date.TimeOfDay;

            return (c.initDate <= date && c.endDate >= date)
                    &&
                    (c.initTime <= time && c.endTime >= time);
        }
    }
}
