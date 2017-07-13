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
    /// Servicio de banners. Se encarga de ser servicio de todos.
    /// </summary>
    class BannerService : IObservable
    {

        /// <summary>
        /// Lista de escuchadores
        /// </summary>
        private List<IObserver> iObserver;

        /// <summary>
        /// Lista de banners
        /// </summary>
        private IList<Banner> iBannerList;

        /// <summary>
        /// Timer con el tiempo de actualizacion de la base de datos
        /// </summary>
        private Timer iRefreshTimer; 

        /// <summary>
        /// Creador del servicio de campañas
        /// </summary>
        /// <param name="pRefreshTime">Minutos para el refresco con la base de datos</param>
        public BannerService(int pRefreshTime)
        {
            iRefreshTimer = new System.Timers.Timer();
            iRefreshTimer.Interval = pRefreshTime * 60000;
            iRefreshTimer.AutoReset = true;
            iRefreshTimer.Enabled = false;
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
                view.Update("Banner");
                }              
        }
        /*
        public void Create(BannerDTO pBannerDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            BannerMapper bannerMapper = new BannerMapper();
            Banner banner = new Banner();

            bannerMapper.MapToModel(pBannerDTO, banner);
            iUnitOfWork.bannerRepository.Add(banner);

            iUnitOfWork.Complete();

        }

        public void Update(CampaignDTO pCampaignDTO)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            CampaignMapper bannerMapper = new CampaignMapper();
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

        /// <summary>
        /// Obtiene el ultimo banner ingresado
        /// </summary>
        /// <returns>Ultimo banner</returns>
        public IList<String> GetBannersText()
        {
            IList<String> aux = new List<String> { };
            foreach (Banner banner in iBannerList)
            {
                if (banner.GetType == TextBanner)
                {
                    aux.Add(banner.text);
                }
            }
            return aux;
        }

        /// <summary>
        /// Empieza un servicio de campañas. Pone a correr los timers.
        /// </summary>
        public void Start()
        {
            iRefreshTimer.Start();

            //Cuando pasa el tiempo que alguno de los timers ejecuta la accion que corresponda.
            iRefreshTimer.Elapsed += OnRefreshTimer;
        }

        /// <summary>
        /// Frena ambos timers.
        /// </summary>
        public void Stop()
        {
            iRefreshTimer.Stop();
        }

        /// <summary>
        /// Cuando se llega al tiempo de cada refresco con la base de datos.
        /// </summary>
        private void OnRefreshTimer(object sender, ElapsedEventArgs e)
        {
            NotifyListeners();

            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            DateTime pDateFrom = DateTime.Now;
            DateTime pDateTo = DateTime.Now.AddMilliseconds(iRefreshTimer.Interval);

            iBannerList = iUnitOfWork.bannerRepository.GetActives(pDateFrom,pDateFrom, pDateTo);
        }
        */
    }
}
