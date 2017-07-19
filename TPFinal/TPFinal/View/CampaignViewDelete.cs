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
using TPFinal.Domain;
using System.IO;

namespace TPFinal.View
{
    public partial class CampaignViewDelete : Form
    {

        private Application application;

        public CampaignViewDelete(Application pAplication)
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

            CampaignDTO campaign= application.CampaignService.GetCampaign(Convert.ToInt32(idText.Text));

            campaignNameText.Text = campaign.name;

            initDateTimePicker.Value = campaign.initDate;
            endDateTimePicker.Value = campaign.endDate;

            initTimeHour.Text = campaign.initTime.Hours.ToString();
            initTimeMinute.Text = campaign.initTime.Minutes.ToString();

            endTimeHour.Text = campaign.endTime.Hours.ToString();
            endTimeMinute.Text = campaign.endTime.Minutes.ToString();

            TimeSpan interval = new TimeSpan(0,0,0,campaign.interval,0);
            intervalMinute.Text = interval.Minutes.ToString();
            intervalSecond.Text = interval.Seconds.ToString();


            IList<ByteImageDTO> imagesAuxDTO = campaign.imagesList.ToList<ByteImageDTO>();

            foreach (ByteImageDTO image in imagesAuxDTO)
            {
                MemoryStream ms = new MemoryStream(image.bytes);
                Image imageAux = System.Drawing.Image.FromStream(ms);
                dataGridViewImages.Rows.Add(image.id,imageAux);
                ms.Dispose();
            }

        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            //Esto creo que podria optimizarse un toque. Me parece al cuete llamar al mensaje de nuevo.
            application.CampaignService.Delete(application.CampaignService.GetCampaign(Convert.ToInt32(idText.Text)));
            this.Close();
        }
    }
}
