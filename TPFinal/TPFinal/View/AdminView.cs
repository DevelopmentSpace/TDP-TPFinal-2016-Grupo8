using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal.View
{
    public partial class AdminView : Form
    {

        private Application application;

        public AdminView(Application pApplication)
        {
            InitializeComponent();
            application = pApplication;
        }

        private void AdminView_Load(object sender, EventArgs e)
        {

        }

        private void Campaign_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CampaignViewAdd campaignViewAdd = new CampaignViewAdd(application);
            campaignViewAdd.Show();
        }
    }
}
