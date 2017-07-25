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

namespace TPFinal.View
{
    public partial class RssTextBannerSearch : Form
    {
        private IRssBannerService iRssBannerService = IoCContainerLocator.Container.Resolve<IRssBannerService>();

        private IEnumerator<RssBannerDTO> rssBanners;

        public RssTextBannerSearch()
        {
            InitializeComponent();
            rssBanners = iRssBannerService.GetAll().GetEnumerator();
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewRssBanners.Rows.Clear();

            while (rssBanners.MoveNext())
            {
                if (rssBanners.Current.name.Length >= searchLenght)
                {
                    if (rssBanners.Current.name.Substring(0, searchLenght) == searchText.Text.ToString().Substring(0, searchLenght))
                    {
                        dataGridViewRssBanners.Rows.Add(rssBanners.Current.id, rssBanners.Current.name, rssBanners.Current.initDate.Date.ToString(), rssBanners.Current.endDate.Date.ToString(), rssBanners.Current.url);
                    }
                }
            }
            rssBanners.Reset();
        }
    }
}
