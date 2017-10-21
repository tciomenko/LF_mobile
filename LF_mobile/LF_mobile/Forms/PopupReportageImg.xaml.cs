using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;


namespace LF_mobile.Forms
{
    public partial class PopupReportageImg 
    {
        public PopupReportageImg()
        {
            InitializeComponent();
        }

        public async void LoadData(Model.ReportageImg item)
        {
            TextLabel.Text = "ФОТО №" + item.id;
            ImgHead.Source = item.img;
        }
        private void ClosePopup(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }


        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }

        protected override Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(1);
        }

        protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);

        }
    }
}
