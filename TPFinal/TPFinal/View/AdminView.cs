using System;
using System.Windows.Forms;
using TPFinal.Model;
using Microsoft.Practices.Unity;

namespace TPFinal.View
{
    /// <summary>
    /// Vista del administrador
    /// </summary>
    public partial class AdminView : Form
    {
        /// <summary>
        /// Servicio de campañas
        /// </summary>
        private ICampaignService iCampaignService = IoCContainerLocator.Container.Resolve<ICampaignService>();
        /// <summary>
        /// Servicio de banners de texto
        /// </summary>
        private ITextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<ITextBannerService>();
        /// <summary>
        /// Servicio de fuentes de RSS
        /// </summary>
        private IRssBannerService iRssBannerService = IoCContainerLocator.Container.Resolve<IRssBannerService>();

        public AdminView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se ejecuta al cliquear en Create del menu de Campaigns
        /// </summary>
        private void createCampaign_Click(object sender, EventArgs e)
        {
            //Crea una vista CampaignView y le pasa un parametro vacio
            CampaignView campaignView = new CampaignView(null);

            //Muestra la vista y si da OK intenta crear una campaña.
            if (campaignView.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iCampaignService.Create(campaignView.ViewCampaignDTO);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in database.");
                }
            }
        }

        /// <summary>
        /// Se ejecuta al cliquear en Search del menu de Campaigns
        /// </summary>
        private void searchCampaign_Click(object sender, EventArgs e)
        {
            //Crea una vista de busqueda
            CampaignViewSearch campaignViewList = new CampaignViewSearch();
            campaignViewList.Show();
        }

        /// <summary>
        /// Se ejecuta al cliquear en Create del menu de TextBanners
        /// </summary>
        private void createTextBanner_Click(object sender, EventArgs e)
        {
            //Crea una vista de texts banners y le pasa un parametro vacio
            TextBannerView textBannerView = new TextBannerView(null);

            //Muestra la vista creada y si da OK intenta crear el banner de texto
            if (textBannerView.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iTextBannerService.Create(textBannerView.ViewTextBannerDTO);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in database");
                }
            }
        }

        /// <summary>
        /// Se ejecuta al cliquear en Search del menu de TextBanners
        /// </summary>
        private void searchTextBanner_Click(object sender, EventArgs e)
        {
            //Crea una vista de busqueda
            TextBannerViewSearch textBannerViewSearch = new TextBannerViewSearch();
            textBannerViewSearch.Show();
        }

        /// <summary>
        /// Se ejecuta al cliquear en Create del menu de RssSource
        /// </summary>
        private void createRssBanner_Click(object sender, EventArgs e)
        {
            //Crea una vista de fuente de rss y le pasa un parametro vacio
            RssBannerView rssBannerView = new RssBannerView(null);

            //Muestra la vista creada y si da OK intenta crear la fuente de Rss
            if (rssBannerView.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iRssBannerService.Create(rssBannerView.ViewRssBannerDTO);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in database");
                }
            }
        }

        /// <summary>
        /// Se ejecuta al cliquear en Search del menu de RssSource
        /// </summary>
        private void searchRssBanner_Click(object sender, EventArgs e)
        {
            //Crea una vista de busqueda
            RssTextBannerSearch rssTextBannerSearch = new RssTextBannerSearch();
            rssTextBannerSearch.Show();
        }
    }
}
