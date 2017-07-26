using System;
using System.Windows.Forms;
using TPFinal.View;
using TPFinal.Model;
using Microsoft.Practices.Unity;

namespace TPFinal
{
    /// <summary>
    /// Vista principal de la aplicacion
    /// </summary>
    public partial class Application : Form
    {
        /// <summary>
        /// Servicios de banners de texto
        /// </summary>
        private ITextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<ITextBannerService>();
        /// <summary>
        /// Servicio de fuentes de RSS
        /// </summary>
        private IRssBannerService iRssBannerService = IoCContainerLocator.Container.Resolve<IRssBannerService>();
        /// <summary>
        /// Servicio de banners
        /// </summary>
        private IBannerService iBannerService = IoCContainerLocator.Container.Resolve<IBannerService>();
        /// <summary>
        /// Servicio de campañas
        /// </summary>
        private ICampaignService iCampaignService = IoCContainerLocator.Container.Resolve<ICampaignService>();

        /// <summary>
        /// Constructor principal de la aplicacion
        /// </summary>
        public Application()
        {
            InitializeComponent();
            //Agrega los servicios de texto al servicio de banners
            iBannerService.AddService((ITextBanner)iTextBannerService);
            iBannerService.AddService((ITextBanner)iRssBannerService);
        }

        /// <summary>
        /// Abre la ventana de administrador
        /// </summary>
        private void adminButton_Click(object sender, EventArgs e)
        {
            AdminView adminView = new AdminView();
            adminView.Show();
        }

        /// <summary>
        /// Abre la ventana de publicidad
        /// </summary>
        private void adButton_Click(object sender, EventArgs e)
        {
            AdView adview = new AdView();
            adview.Show();
        }

        /// <summary>
        /// Fuerza a actualizar los servicios
        /// </summary>
        private void forceUpdate_Click(object sender, EventArgs e)
        {
            iBannerService.ForceUpdate();
            iCampaignService.ForceUpdate();
        }
    }
}
