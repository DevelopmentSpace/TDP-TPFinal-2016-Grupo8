using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinal.DTO;
using TPFinal.Model;

namespace TPFinal.View
{
    public partial class CampaignViewAdd : Form
    {
        private Application application;

        public CampaignViewAdd(Application pApplication)
        {
            InitializeComponent();
            application = pApplication;
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
            dataGridViewImages.Update();
            dataGridViewImages.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewImages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
                { 
                foreach (DataGridViewRow row in dataGridViewImages.SelectedRows)
                {
                    dataGridViewImages.Rows.Remove(row);
                }

            }
        }

        //ESTO NO VA ACA
        private static Byte[] imageToByte(Image i)
        {
            MemoryStream stream = new MemoryStream();
            i.Save(stream, ImageFormat.Png);
            byte[] bytes = stream.ToArray();
            return bytes;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            CampaignDTO campaign = new CampaignDTO();
            //campaign.id = campaignService.LastID();
            campaign.name = campaignNameText.Text;

            campaign.interval = Convert.ToInt32(intervalMinute.Text) * 60 + Convert.ToInt32(intervalSecond.Text);

            campaign.initDate = initDateTimePicker.Value.Date;
            campaign.endDate = endDateTimePicker.Value.Date;

            campaign.initTime = new TimeSpan(Convert.ToInt32(initTimeHour.Text), Convert.ToInt32(initTimeMinute.Text), 0);
            campaign.endTime = new TimeSpan(Convert.ToInt32(endTimeHour.Text), Convert.ToInt32(endTimeMinute.Text), 0);

            IList<ByteImageDTO> imagesAuxDTO = new List<ByteImageDTO> { };

            foreach (DataGridViewRow row in dataGridViewImages.Rows)
            {
                ByteImageDTO imageDTO = new ByteImageDTO();

                imageDTO.id = Convert.ToInt32(row.Cells[0].Value);
                imageDTO.bytes = CampaignViewAdd.imageToByte((Image)row.Cells[1].Value);

                imagesAuxDTO.Add(imageDTO);
            }

            campaign.imagesList = imagesAuxDTO;
            
            application.CampaignService.Create(campaign);

            this.Close();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
