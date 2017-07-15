using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinal.DTO;
using TPFinal.Model;

namespace TPFinal.View
{
    public partial class CampaignView : Form
    {
        public CampaignView()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            foreach (String dir in openFileDialog.FileNames)
            {
                //EL ID ACA TIENE QUE SALIR DE OTRO LADO
                dataGridViewImages.Rows.Add(dataGridViewImages.Rows.Count, Bitmap.FromFile(dir));
             }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewImages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '⌂')
                { 
                foreach (DataGridViewRow row in dataGridViewImages.SelectedRows)
                {
                    dataGridViewImages.Rows.Remove(row);
                }
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            //Este campaign service tiene que salir de otro lado.
            CampaignService campaignService = new CampaignService(30);

            CampaignDTO campaign = new CampaignDTO();
            //campaign.id = campaignService.LastID();
            campaign.name = campaignNameText.Text;

            campaign.interval = Convert.ToInt32(intervalText.Text);

            campaign.initDateTime = initDateTimePicker.Value;
            campaign.endDateTime = endDateTimePicker.Value;

            IEnumerable<ByteImageDTO> imageDTO;

            foreach (DataGridViewRow row in dataGridViewImages.Rows)
            {
               //row
            }

            //campaign.imagesList = imageDTO;

            campaignService.Create(campaign);

        }
    }
}
