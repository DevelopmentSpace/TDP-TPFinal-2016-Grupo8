using System;
using System.Collections.Generic;
using System.Linq;
using TPFinal.DAL;
using TPFinal.Domain;
using System.Timers;

namespace TPFinal.Model
{
    /// <summary>
    /// Servicio de campañas. Se encarga de ser servicio de todos.
    /// </summary>
    class CampaignService
    {
        /// <summary>
        /// Lista donde se almacenaran todas las campañas actuales (1 hora)
        /// </summary>
        private IEnumerable<Campaign> iCampaignList;

        /// <summary>
        /// Indice de la imagen actual de una campaña
        /// </summary>
        private int iActualImage;

        /// <summary>
        /// Indice de campaña actual
        /// </summary>
        private int iActualCampaign;

        /// <summary>
        /// Reloj de tiempo para controlar los intervalos. Los intervalos de los timers estan en milisegundos.
        /// </summary>
        private Timer iIntervalTimer;

        /// <summary>
        /// Reloj de tiempo para controlar el tiempo de refresco con la base de datos. Los intervalos de los timers estan en milisegundos.
        /// </summary>
        private Timer iRefreshTimer;

        /// <summary>
        /// Creador del servicio de campañas
        /// </summary>
        /// <param name="pRefreshTime">Minutos para el refresco con la base de datos</param>
        public CampaignService(int pRefreshTime)
        {
            iIntervalTimer = new System.Timers.Timer();
            iIntervalTimer.Interval = 1000;
            iIntervalTimer.AutoReset = true;
            iIntervalTimer.Enabled = false;

            iRefreshTimer = new System.Timers.Timer();
            iRefreshTimer.Interval = pRefreshTime * 60000;
            iRefreshTimer.AutoReset = true;
            iRefreshTimer.Enabled = false;

            iActualCampaign = 0;
            iActualImage = 0;
        }


        public void Create(CampaignDTO pCampaignDTO)
        {


        }

        public void Update(CampaignDTO pCampaignDTO)
        {


        }

        public void Delete(CampaignDTO pCampaignDTO)
        {


        }

        /// <summary>
        /// Obtiene la imagen actual de la campaña actual
        /// </summary>
        /// <returns>Imagen actual</returns>
        public byte[] GetActualImage()
        {
            return iCampaignList.ElementAt(iActualCampaign).imagesList.ElementAt(iActualImage);
        }

        /// <summary>
        /// Empieza un servicio de campañas. Pone a correr los timers.
        /// </summary>
        public void Start()
        {
            
            iIntervalTimer.Start();
            iRefreshTimer.Start();

            //Cuando pasa el tiempo que alguno de los timers ejecuta la accion que corresponda.
            iIntervalTimer.Elapsed += OnIntervalTimer;
            iRefreshTimer.Elapsed += OnRefreshTimer;
        }

        /// <summary>
        /// Frena ambos timers.
        /// </summary>
        public void Stop()
        {
            iIntervalTimer.Stop();
            iRefreshTimer.Stop();
        }

        /// <summary>
        /// Cuando se llega al tiempo de cada intervalo (segun la campaña).
        /// </summary>

        private void OnIntervalTimer(object sender, ElapsedEventArgs e)
     
        {
            if (ActiveCampaign())
            {
                iActualImage++;

                if (iActualImage > iCampaignList.ElementAt(iActualCampaign).imagesList.Count)
                {
                    iActualImage = 0;
                    iActualCampaign++;
                }

                if (iActualCampaign > iCampaignList.Count())
                {
                    iActualImage = 0;
                    iActualCampaign = 0;
                }
            }
            else
            {
                iActualImage = 0;
                iActualCampaign++;

                if (iActualCampaign > iCampaignList.Count())
                {
                    iActualImage = 0;
                    iActualCampaign = 0;
                }
            }
        }

        /// <summary>
        /// Cuando se llega al tiempo de cada refresco con la base de datos.
        /// </summary>
        private void OnRefreshTimer(object sender, ElapsedEventArgs e)
        {
            IUnitOfWork iUnitOfWork = new UnitOfWork(new DAL.EntityFramework.DigitalSignageDbContext());
            DateTime pDateFrom = DateTime.Now;
            DateTime pDateTo = DateTime.Now.AddMilliseconds(iRefreshTimer.Interval);

            iIntervalTimer.Interval = iCampaignList.ElementAt(iActualCampaign).interval;

            iActualCampaign = 0;
            iActualImage = 0;
            iCampaignList = iUnitOfWork.CampaignRepository.GetActives(pDateFrom, pDateTo);
        }

        /// <summary>
        /// Da informacion del estado de la campaña
        /// </summary>
        /// <returns>Verdadero si la campaña estaba activa o falso si no lo estaba</returns>
        private bool ActiveCampaign()
        {
            return ((iCampaignList.ElementAt(iActualCampaign).initDateTime <= DateTime.Now) && (iCampaignList.ElementAt(iActualCampaign).endDateTime >= DateTime.Now));
        }
    }
}
