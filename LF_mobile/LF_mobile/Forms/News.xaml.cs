using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LF_mobile.Class;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace LF_mobile.Forms
{
    public partial class News : ContentPage
    {
  

        async void LoadData()
        {
			NewsList.ItemsSource = App.Database.GetNews().Select(c =>
			{
			c.img = App.linkServer + "/" + c.img;
			c.name = c.name.ToUpper();
			c.description = (c.description.Length > 100) ? c.description.Substring(0, 97) + "..." : c.description;
                return c;
            }).Select(d =>
            {
                d.name = d.name.ToUpper();
                return d;
            });



            if (Authorization.IsAuth) menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;
        }

        public News()
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
                     Device.BeginInvokeOnMainThread(
                         () => LoadData());
                 }
             });
        }

		    async void NewSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (((ListView)sender).SelectedItem == null) return;
			var pageNew = new NewsMore();
			pageNew.LoadData((Model.News)e.SelectedItem);
			await Navigation.PushAsync(pageNew);
			((ListView)sender).SelectedItem = null;
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
