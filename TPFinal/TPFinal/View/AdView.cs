using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using TPFinal.Model;

namespace TPFinal.View
{
    public partial class AdView : Form
    {
        CampaignService campaña;

        public AdView()
        {
            InitializeComponent();
        }



        private void AdView_Load(object sender, EventArgs e)
        {
            campaña = new CampaignService(50);
            campaña.Start();
            refreshTimer.Start();
            refreshTimer.Tick += OnRefresh;
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream(campaña.GetActualImage());
            imageBox.Image = Image.FromStream(ms);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
        
        }
    }
}
