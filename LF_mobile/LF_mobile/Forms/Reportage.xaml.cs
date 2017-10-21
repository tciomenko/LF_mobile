using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LF_mobile.Class;
using LF_mobile.Model;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace LF_mobile.Forms
{
    public partial class Reportage : ContentPage
    {


        async void LoadData()
        {
     

			ReportageList.ItemsSource = App.Database.GetReportage().OrderByDescending(h=>h.id).Select(c =>
            {
                c.img_one = App.linkServer + "/" + c.img_one;
                c.img_two = App.linkServer + "/" + c.img_two;
                c.img_three = App.linkServer + "/" + c.img_three;
                c.img_four = App.linkServer + "/" + c.img_four;
                c.img_five = App.linkServer + "/" + c.img_five;
                c.name = c.name.ToUpper();
                return c;
            }).Select(d =>
            {
                d.name = d.name.ToUpper();
                return d;
            });



            if (Authorization.IsAuth) menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;
        }

        async void ReportageSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null) return;
            var pageReportageImg = new ReportageImg();
            pageReportageImg.LoadData((Model.Reportage)e.SelectedItem);
            await this.Navigation.PushAsync(pageReportageImg);
            ((ListView)sender).SelectedItem = null;
        }

        public Reportage()
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
            var masterPage = new TabPages();
            masterPage.CurrentPage = masterPage.Children[1];
            this.Navigation.PushAsync(masterPage);
            SlideMenu.IsOpen = false;
        }
        private void MenuClickReportage(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
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
