using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LF_mobile.Class;
using Xamarin.Forms;
using System.Diagnostics;
using Rg.Plugins.Popup.Extensions;

namespace LF_mobile.Forms
{
    public partial class ReportageImg : ContentPage
    {

        public async void LoadData(Model.Reportage item)
        {
            this.Title = item.name;
            await Task.Run(async () =>
            {
                using (UserDialogs.Instance.Loading("Загрузка..."))
                {
                    await Task.Delay(500);
                    Device.BeginInvokeOnMainThread(
                        () => currentLoadData(item));
                }
            });
        }

        async void currentLoadData(Model.Reportage item)
        {
            ReportageImgList.FlowItemsSource =  App.Database.GetReportageImg().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
                return c;
            }).Where(h => h.reportage_id == item.id).ToList();

            ReportageImgList.FlowItemTapped += async (sender, e) =>
			{
				var itemPhoto = e.Item as Model.ReportageImg;
				var pageReportageImgFull = new ReportageFullImage();
				pageReportageImgFull.LoadData(item, itemPhoto.id);
				await this.Navigation.PushAsync(pageReportageImgFull);
				((ListView)sender).SelectedItem = null;


			};


            if (Authorization.IsAuth) menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;
        }



        async void PhotoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null) return;
            var pageShops = new SubCategory();
             await this.Navigation.PushAsync(pageShops);
            // ((ListView)sender).SelectedItem = null;
          //  var page = new PopupReportageImg();
          //  await Navigation.PushPopupAsync(page);
        }

        public ReportageImg()
        {
            InitializeComponent();
        }
        private void BtnMenu(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = true;
        }

        private void MenuClickLogin(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            this.Navigation.PushAsync(new Login());
        }

        private void MenuClickCatalog(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var masterPage = new TabPages();
            masterPage.CurrentPage = masterPage.Children[0];
            this.Navigation.PushAsync(masterPage);
        }
        private void MenuClickPreview(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var masterPage = new TabPages();
            masterPage.CurrentPage = masterPage.Children[1];
            this.Navigation.PushAsync(masterPage);
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
    }
}
