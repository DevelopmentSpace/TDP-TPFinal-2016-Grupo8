using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using TPFinal.Model;

namespace TPFinal.View
{
    public partial class AdView : Form, IObserver
    {
        CampaignService campaignService;

        public AdView()
        {
            InitializeComponent();
        }

        private void AdView_Load(object sender, EventArgs e)
        {
            campaignService = new CampaignService(50); //ESTE TIEMPO SE TIENE QUE SELECCIONAR EN OTRA VISTA 
            campaignService.AddListener(this);
            campaignService.Start();


        }

        public void Update(String des)
        {
            if (des == "Campaign")
            {
                MemoryStream ms = new MemoryStream(campaignService.GetActualImage());
                imageBox.Image = Image.FromStream(ms);
            }
            else if (des == "Banner")
            {
                //textBanner.Text = bannerService.GetText();
                //textBanner.ForeColor = new Color(); // - PARA CAMBIAR EL COLOR DEL TEXTO.
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
        
        }

    }
}
