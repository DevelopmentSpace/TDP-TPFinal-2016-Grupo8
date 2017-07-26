using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TPFinal.DTO;

namespace TPFinal.View
{
    /// <summary>
    /// Vista de fuentes de RSS
    /// </summary>
    public partial class RssBannerView : Form
    {
        /// <summary>
        /// Atributo RssBannerDTO
        /// </summary>
        private RssBannerDTO iRssBannerDTO;

        /// <summary>
        /// Accesor del atributo RssBannerDTO
        /// </summary>
        public RssBannerDTO ViewRssBannerDTO
        {
            get
            {
                return iRssBannerDTO;
            }
        }

        /// <summary>
        /// Constructor de la vista de RssBanners
        /// </summary>
        /// <param name="pCampaignDTO">Objeto de tipo RssBannersDTO que se asigna a el atributo</param>
        public RssBannerView(RssBannerDTO pRssBannerDTO)
        {
            InitializeComponent();

            //Si el objeto no es nulo, lo carga en la vista y lo asigna a la variable.
            if (pRssBannerDTO != null)
            {
                iRssBannerDTO = pRssBannerDTO;
                loadRssBannerInView();
            }
            else
            {
                iRssBannerDTO = new RssBannerDTO();
            }

        }
        /// <summary>
        /// Carga la fuente RSS del atributo en la vista
        /// </summary>
        private void loadRssBannerInView()
        {
            bannerNameText.Text = iRssBannerDTO.name;

            initDateTimePicker.Value = iRssBannerDTO.initDate;
            endDateTimePicker.Value = iRssBannerDTO.endDate;

            initTimeHour.Text = iRssBannerDTO.initTime.Hours.ToString();
            initTimeMinute.Text = iRssBannerDTO.initTime.Minutes.ToString();

            endTimeHour.Text = iRssBannerDTO.endTime.Hours.ToString();
            endTimeMinute.Text = iRssBannerDTO.endTime.Minutes.ToString();

            textBanner.Text = iRssBannerDTO.url;
        }

        /// <summary>
        /// Carga la fuente RSS de la vista en la fuente RSS del atributo
        /// </summary>
        private void loadRssBannerInVariable()
        {
            iRssBannerDTO.name = bannerNameText.Text;

            if (initDateTimePicker.Value.Date > endDateTimePicker.Value.Date)
                throw new ArgumentException();

            iRssBannerDTO.initDate = initDateTimePicker.Value.Date;
            iRssBannerDTO.endDate = endDateTimePicker.Value.Date;

            IList<TimeSpan> listSpan = Utilities.createTimeSpans(initTimeHour.Text, initTimeMinute.Text, endTimeHour.Text, endTimeMinute.Text);

            iRssBannerDTO.initTime = listSpan.ElementAt(0);
            iRssBannerDTO.endTime = listSpan.ElementAt(1);

            iRssBannerDTO.url = textBanner.Text;
        }

        /// <summary>
        /// Se ejecuta cuando se cliquea el boton de cancelar. Cierra la vista
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se ejecuta cuando se cliquea el boton de aceptar. Intenta cargar la fuente RSS de la vista en el atributo
        /// </summary>
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                loadRssBannerInVariable();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Bad time format: Insert numbers");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Bad hour format: Hours must go from 0 to 24, minutes and seconds must go from 0 to 60. Also init-time/date must be greater then end-time/date.");
            }
        }
    }
}
