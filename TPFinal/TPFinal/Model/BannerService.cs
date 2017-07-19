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
        /// Creador del servicio de campañas
        /// </summary>
        /// <param name="pRefreshTime">Minutos para el refresco con la base de datos</param>
        public BannerService(int pRefreshTime)
        {

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

        }

        /// <summary>
        /// Frena 
        /// </summary>
        public void Stop()
        {
        }
        /// <summary>
        /// Cuando se llega al tiempo de cada refresco con la base de datos.
        /// </summary>
        private void OnRefreshTimer(object sender, EventArgs e)
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
