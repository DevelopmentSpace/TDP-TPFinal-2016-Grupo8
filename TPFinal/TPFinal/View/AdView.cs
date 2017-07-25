﻿using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using TPFinal.Model;

namespace TPFinal.View
{
    public partial class AdView : Form, IObserver
    {
        private Application application;

        private static string SPACE_STRING = "                                                                                                                                                                                                                                                             ";

        public AdView(Application pApplication)
        {
            InitializeComponent();
            application = pApplication;
        }

        private void AdView_Load(object sender, EventArgs e)
        {

            application.CampaignService.AddListener(this);
            application.BannerService.AddListener(this);

            UpdateImage();

            moveTextTimer.Interval = 100;
            moveTextTimer.Enabled = true;
            // textBanner.Text = AdView.SPACE_STRING+"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc";
            textBanner.Text = "";



        }

        private void UpdateImage()
        {
            byte[] image = application.CampaignService.GetActualImage();
            if (image.Length == 0)
                return;

            MemoryStream stream = new MemoryStream(image);
            Image i = Image.FromStream(stream);
            stream.Dispose();

            imageBox.Image = i;
        }

        public void Update(String des)
        {
            if (des == "Campaign")
            {
                UpdateImage();
            }
            else if (des == "Banner")
            {
                textBanner.ForeColor = System.Drawing.Color.Red; // - PARA CAMBIAR EL COLOR DEL TEXTO.
                //textBanner.Text = application.BannerService.GetText();
                textBanner.ForeColor = System.Drawing.Color.Black;

            }
        }

        private void moveTextTimer_Tick(object sender, EventArgs e)
        {
            if (textBanner.Text.Length > 0)
            {
                textBanner.Text = textBanner.Text.Remove(0, 1);
            }
            else
            {
                if (application.BannerService.GetText() != "")
                { 
                    textBanner.Text = SPACE_STRING + application.BannerService.GetText();
                }
            }
        }
    }
}
