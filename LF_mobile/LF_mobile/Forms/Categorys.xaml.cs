using LF_mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LF_mobile.Class;
using Xamarin.Forms;
using Acr.UserDialogs;
using Plugin.DeviceInfo;
using Rg.Plugins.Popup.Extensions;
using System.Diagnostics;

namespace LF_mobile.Forms
{
    public partial class Categorys : ContentPage
    {


        async void LoadData()
        {
            
            
            CategoryList.ItemsSource = App.Database.GetCategories().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
                c.name = c.name.ToUpper();
				Debug.WriteLine("1========" + c.img);
                return c;
            }).Select(d =>
            {
                d.name = d.name.ToUpper();
                return d;
            });

            if (Authorization.IsAuth)menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;

            //----РЕКЛАМА
            ReklamaCatalog reklamaTop = App.Database.GetReklamaCatalog().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
				Debug.WriteLine("2========" + c.img);
                return c;
            }).SingleOrDefault(h => h.id_reklama_category == 1 && h.id_reklama_number == 1);
            if (reklamaTop != null)
            {
                BannerTop.Source = reklamaTop.img;
                BannerTop.IsVisible = true;

            }


            ReklamaCatalog reklamaBottomOne = App.Database.GetReklamaCatalog().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
				Debug.WriteLine("3========" + c.img);
                return c;
            }).SingleOrDefault(h => h.id_reklama_category == 1 && h.id_reklama_number == 2);
            if (reklamaBottomOne != null)
            {
                BannerBottomOne.Source = reklamaBottomOne.img;
                BannerBottomOne.IsVisible = true;
            }

            ReklamaCatalog reklamaBottomTwo = App.Database.GetReklamaCatalog().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
				Debug.WriteLine("4========" + c.img);
                return c;
            }).SingleOrDefault(h => h.id_reklama_category == 1 && h.id_reklama_number == 3);
            if (reklamaBottomTwo != null)
            {
                BannerBottomTwo.Source = reklamaBottomTwo.img;
                BannerBottomTwo.IsVisible = true;
            }

            ReklamaCatalog reklamaBottomThree = App.Database.GetReklamaCatalog().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
				Debug.WriteLine("5========" + c.img);
                return c;
            }).SingleOrDefault(h => h.id_reklama_category == 1 && h.id_reklama_number == 4);
            if (reklamaBottomThree != null)
            {
                BannerBottomThree.Source = reklamaBottomThree.img;
                BannerBottomThree.IsVisible = true;
            }
            //----РЕКЛАМА
        }

		     public Categorys()
		{
			InitializeComponent();
			loadContent();
		}

        async void  CategorySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null) return;
            var pageShops = new SubCategory();
            pageShops.LoadData((Category)e.SelectedItem);
            await this.Navigation.PushAsync(pageShops);
            ((ListView)sender).SelectedItem = null;
        }

   

        private async void loadContent() {
            base.OnAppearing();
            await Task.Run(async () => {
                //using (UserDialogs.Instance.Loading("Загрузка..."))
               // {
                    await Task.Delay(250);
                    Device.BeginInvokeOnMainThread(() => LoadData());
               // }
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
