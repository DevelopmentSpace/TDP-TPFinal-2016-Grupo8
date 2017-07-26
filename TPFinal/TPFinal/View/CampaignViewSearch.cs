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
    /// <summary>
    /// Vista de busqueda de campañas
    /// </summary>
    public partial class CampaignViewSearch : Form
    {
        /// <summary>
        /// Servicio de campañas
        /// </summary>
        private ICampaignService iCampaignService = IoCContainerLocator.Container.Resolve<ICampaignService>();

        /// <summary>
        /// Enumerable con todas las campañasDTO
        /// </summary>
        private IEnumerable<CampaignDTO> campaigns;

        /// <summary>
        /// Constructor de la vista de busqueda de campañas
        /// </summary>
        public CampaignViewSearch()
        {
            InitializeComponent();
            //Se obtienen todas las campañas en el enumerable
            campaigns = iCampaignService.GetAll();

            //Se ejecuta por primera para actualizar la lista de campañas
            searchText.Text = "";
            searchText_TextChanged(null, EventArgs.Empty);
        }

        /// <summary>
        /// Se ejecuta cuando cambia el texto en pantalla. Muestra las campañas cuyo nombre coincida con el texto ingresado.
        /// </summary>
        private void searchText_TextChanged(object sender, EventArgs e)
        {
            int searchLenght = searchText.Text.Length;
            dataGridViewCampaigns.Rows.Clear();
            IEnumerator<CampaignDTO> campaignsEnumerator = campaigns.GetEnumerator();

            while (campaignsEnumerator.MoveNext())
            {
                if (campaignsEnumerator.Current.name.Length >= searchLenght)
                {
                    if (campaignsEnumerator.Current.name.Substring(0, searchLenght).ToLower() == searchText.Text.ToString().Substring(0, searchLenght).ToLower())
                    {
                        dataGridViewCampaigns.Rows.Add(campaignsEnumerator.Current.id, campaignsEnumerator.Current.name, campaignsEnumerator.Current.initDate.Date.ToString("dd/MM/yyyy"), campaignsEnumerator.Current.endDate.Date.ToString("dd/MM/yyyy"));
                    }
                }
             }
            campaignsEnumerator.Reset();
         }

        /// <summary>
        /// En el caso de estar seleccionando la lista y presionar la 'd' o la 'm'. Permite eliminar o modificar filas segun corresponda.
        /// </summary>
        private void dataGridViewCampaigns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd')
            {
                foreach (DataGridViewRow row in dataGridViewCampaigns.SelectedRows)
                {
                    try
                    {
                        //Se le pasa la id de la columna seleccionada
                        iCampaignService.Delete((int)row.Cells[0].Value);
                        dataGridViewCampaigns.Rows.Remove(row);
                        dataGridViewCampaigns.Refresh();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error deleting campaigns.");
                    }
                }
                campaigns = iCampaignService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }
            else if (e.KeyChar == 'm')
            {
                if (dataGridViewCampaigns.SelectedRows.Count == 1)
                {
                    try
                    {
                        //Se crea una vista pasandole como parametro el objeto seleccionado.
                        CampaignView campaignView = new CampaignView(campaigns.First<CampaignDTO>(x => x.id == ((int)dataGridViewCampaigns.SelectedRows[0].Cells[0].Value)));
                        campaignView.ShowDialog();
                        iCampaignService.Update(campaignView.ViewCampaignDTO);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error updating campaign.");
                    }
                }
                campaigns = iCampaignService.GetAll();
                searchText_TextChanged(null, EventArgs.Empty);
            }

        }
    }
}
