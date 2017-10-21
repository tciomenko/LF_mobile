using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LF_mobile.Class;
using LF_mobile.Model;
using Plugin.DeviceInfo;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace LF_mobile.Forms
{
    public partial class Preview : ContentPage
    {
        public void DialNumber(object sender, EventArgs e)
        {
			try
			{
Device.OpenUri(new Uri(String.Format("tel:{0}", ((Label)sender).Text)));
			}
			catch (Exception ex)
			{

			}
        }

        async void LoadData()
        {
            PreviewList.ItemsSource = App.Database.GetPreview().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
                c.name = c.name.ToUpper();
                return c;
            }).Select(d =>
            {
                d.name = d.name.ToUpper();
                return d;
			}).OrderByDescending(h=>h.id);

            if (Authorization.IsAuth) menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;
        }

        public Preview()
        {
            InitializeComponent();
            loadContent();
        }

        private async void loadContent()
        {
            await Task.Run(
                    async () =>
                    {
                        using (UserDialogs.Instance.Loading("Загрузка..."))
                        {
                            await Task.Delay(500);
                            Device.BeginInvokeOnMainThread(() => LoadData());
                        }
                    });
        }
        

        private void BtnMenu(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = true;
        }

        private void MenuClickLogin(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var pageLogin = new Login();
            this.Navigation.PushAsync(pageLogin);
        }

        private void MenuClickCatalog(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var masterPage = new TabPages();
            masterPage.CurrentPage = masterPage.Children[0];
            this.Navigation.PushAsync(masterPage);
        }
        private async void MenuClickPreview(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
        }
        private void MenuClickReportage(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var masterPage = new TabPages();
            masterPage.CurrentPage = masterPage.Children[2];
            this.Navigation.PushAsync(masterPage);
        }

        private void MenuClickNews(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var masterPage = new TabPages();
            masterPage.CurrentPage = masterPage.Children[3];
            this.Navigation.PushAsync(masterPage);
        }
        private void MenuClickForum(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var masterPage = new TabPages();
            masterPage.CurrentPage = masterPage.Children[4];
            this.Navigation.PushAsync(masterPage);
        }

        private void MenuClickBook(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var masterPage = new TabPages();
            masterPage.CurrentPage = masterPage.Children[5];
            this.Navigation.PushAsync(masterPage);
        }

        private async void MenuClickAbout(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var page = new PopupAbout();
            Navigation.PushPopupAsync(page);
        }

        private void OpenLinkSite(object sender, EventArgs e)
        {
			try
			{
                  Device.OpenUri(new Uri("http://" + ((Label)sender).Text));
			}
			catch (Exception ex)
			{

			}

        }
    }
}
