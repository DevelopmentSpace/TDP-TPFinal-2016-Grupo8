using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using TPFinal.Model;
using TPFinal.DTO;

namespace TPFinal.View
{
    public partial class TextBannerViewSearch : Form
    {

        private TextBannerService iTextBannerService = IoCContainerLocator.Container.Resolve<TextBannerService>();

        private IEnumerator<TextBannerDTO> textBanners;

        public TextBannerViewSearch()
        {
            InitializeComponent();
            textBanners = iTextBannerService.GetAll().GetEnumerator();
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewTextBanners.Rows.Clear();

            while (textBanners.MoveNext())
            {
                if (textBanners.Current.name.Length >= searchLenght)
                {
                    if (textBanners.Current.name.Substring(0, searchLenght) == searchText.Text.ToString().Substring(0, searchLenght))
                    {
                        dataGridViewTextBanners.Rows.Add(textBanners.Current.id, textBanners.Current.name, textBanners.Current.initDate.Date.ToString(), textBanners.Current.endDate.Date.ToString(),textBanners.Current.text);
                    }
                }
            }
            textBanners.Reset();
        }
    }
}
