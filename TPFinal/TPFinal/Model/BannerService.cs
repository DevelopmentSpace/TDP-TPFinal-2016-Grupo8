using System;
using System.Collections.Generic;
using System.Linq;
using TPFinal.DAL;
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
        /// Lista de servicios de texto de banner
        /// </summary>
        private IList<ITextBanner> iTextBannerList;

        /// <summary>
        /// Timer con el tiempo de actualizacion de la base de datos
        /// </summary>
        private Timer iRefreshTimer;

        /// <summary>
        /// Timer con el tiempo de actualizacion de los textos
        /// </summary>
        private Timer iIntervalTimer;

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

            iIntervalTimer = new System.Timers.Timer();
            iIntervalTimer.Interval = pRefreshTime * 15000;
            iIntervalTimer.AutoReset = true;
            iIntervalTimer.Enabled = false;

            ITextBanner rssBannerService = new RssBannerService(pRefreshTime);
            ITextBanner textBannerService = new TextBannerService(pRefreshTime);

            iTextBannerList = new List<ITextBanner> { };
            iObserver = new List<IObserver> { };

            iTextBannerList.Add(textBannerService);
            iTextBannerList.Add(rssBannerService);

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
        /// <summary>
        /// Obtiene las cadenas de caracteres de todos los banners activos. 
        /// </summary>
        /// <returns>Cadena de caracteres con todo el texto de los banners</returns>
        public String GetText()
        {
            string text = "";
            foreach (ITextBanner serviceBanner in iTextBannerList)
            {
                text = text + " - " + serviceBanner.GetText();
            }
            return text;
        }

       
        /// <summary>
        /// Empieza un servicio de banners. Pone a correr los timers.
        /// </summary>
        public void Start()
        {
            iRefreshTimer.Start();

            //Cuando pasa el tiempo que alguno de los timers ejecuta la accion que corresponda.
           iRefreshTimer.Elapsed += OnRefreshTimer;
           iIntervalTimer.Elapsed += OnIntervalTimer;
        }

        /// <summary>
        /// Frena 
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
            foreach (ITextBanner textBanner in iTextBannerList)
            {
                textBanner.Refresh();
            }

            NotifyListeners();
        }

        private void OnIntervalTimer(object sender, ElapsedEventArgs e)
        {
            //ACA HAY UN TEMA. PUEDE QUE SER QUE LOS BANNER ACTIVOS NO SE MUESTREN
            NotifyListeners();
        }
    }
}
