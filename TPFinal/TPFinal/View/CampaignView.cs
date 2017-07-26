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
using Microsoft.Practices.Unity;
using System.IO;


namespace TPFinal.View
{
    public partial class CampaignView : Form
    {
        public CampaignDTO varCampaignDTO;

        public CampaignView(CampaignDTO pCampaignDTO)
        {
            InitializeComponent();

            if (pCampaignDTO != null)
            {
                varCampaignDTO = pCampaignDTO;
                loadCampaignInView();
            }
        }

        private void loadCampaignInView()
        {
            dataGridViewImages.Rows.Clear();
            dataGridViewImages.Refresh();

            CampaignDTO campaign = varCampaignDTO;
            campaignNameText.Text = campaign.name;

            initDateTimePicker.Value = campaign.initDate;
            endDateTimePicker.Value = campaign.endDate;

            initTimeHour.Text = campaign.initTime.Hours.ToString();
            initTimeMinute.Text = campaign.initTime.Minutes.ToString();

            endTimeHour.Text = campaign.endTime.Hours.ToString();
            endTimeMinute.Text = campaign.endTime.Minutes.ToString();

            TimeSpan interval = new TimeSpan(0, 0, 0, campaign.interval, 0);
            intervalMinute.Text = interval.Minutes.ToString();
            intervalSecond.Text = interval.Seconds.ToString();

            IList<ByteImageDTO> imagesAuxDTO = campaign.imagesList.ToList<ByteImageDTO>();

            foreach (ByteImageDTO image in imagesAuxDTO)
            {
                MemoryStream ms = new MemoryStream(image.bytes);
                Image imageAux = System.Drawing.Image.FromStream(ms);
                dataGridViewImages.Rows.Add(image.id, imageAux);
                ms.Dispose();
            }
        }

        private void loadCampaignInVariable()
        {
            varCampaignDTO.name = campaignNameText.Text;

            varCampaignDTO.interval = Convert.ToInt32(intervalMinute.Text) * 60 + Convert.ToInt32(intervalSecond.Text);

            varCampaignDTO.initDate = initDateTimePicker.Value.Date;
            varCampaignDTO.endDate = endDateTimePicker.Value.Date;

            varCampaignDTO.initTime = new TimeSpan(Convert.ToInt32(initTimeHour.Text), Convert.ToInt32(initTimeMinute.Text), 0);
            varCampaignDTO.endTime = new TimeSpan(Convert.ToInt32(endTimeHour.Text), Convert.ToInt32(endTimeMinute.Text), 0);

            IList<ByteImageDTO> imagesAuxDTO = new List<ByteImageDTO> { };

            foreach (DataGridViewRow row in dataGridViewImages.Rows)
            {
                ByteImageDTO imageDTO = new ByteImageDTO();

                imageDTO.bytes = Utilities.imageToByte((Image)row.Cells[0].Value);

                imagesAuxDTO.Add(imageDTO);
            }

            varCampaignDTO.imagesList = imagesAuxDTO;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            loadCampaignInVariable();
            this.Close();       
        }

        private void addButtonImage_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            foreach (String dir in openFileDialog.FileNames)
            {
                dataGridViewImages.Rows.Add(Bitmap.FromFile(dir));
            }
            dataGridViewImages.Update();
            dataGridViewImages.Refresh();
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
    }
}
