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
using System.IO;
using System.Drawing.Imaging;

namespace TPFinal.View
{
    public partial class CampaignViewUpdate : Form
    {

        private Application application;

        public CampaignViewUpdate(Application pAplication)
        {
            InitializeComponent();
            application = pAplication;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            dataGridViewImages.Rows.Clear();
            dataGridViewImages.Refresh();

            CampaignDTO campaign = application.CampaignService.GetCampaign(Convert.ToInt32(idText.Text));

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
            campaign.id = Convert.ToInt32(idText.Text);
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
                imageDTO.bytes = CampaignViewUpdate.imageToByte((Image)row.Cells[1].Value);

                imagesAuxDTO.Add(imageDTO);
            }

            campaign.imagesList = imagesAuxDTO;

            application.CampaignService.Update(campaign);

            this.Close();
        }

        private void addImageButton_Click(object sender, EventArgs e)
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

        private void dataGridViewImages_KeyPress_1(object sender, KeyPressEventArgs e)
        {
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            CampaignViewSearch campaignSearch = new CampaignViewSearch(application);
            campaignSearch.Show();
        }
    }
}
