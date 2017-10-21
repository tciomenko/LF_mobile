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
    public partial class Catalogs : ContentPage
    {
        public Catalogs()
        {
            InitializeComponent();
        }
      
   
        public async void LoadData(Model.SubCategory item)
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

        async void currentLoadData(Model.SubCategory item)
        {
            CatalogsList.ItemsSource = App.Database.GetCatalogs().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
                c.name = c.name.ToUpper();
                return c;
            }).Where(h => h.id_sub_category == item.id).Select(d =>
            {
                d.name = d.name.ToUpper();
                return d;
            }).OrderBy(h=>h.ordering);


            if (Authorization.IsAuth) menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;

            //----РЕКЛАМА
            ReklamaCatalog reklamaTop = App.Database.GetReklamaCatalog().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
                return c;
            }).SingleOrDefault(h => h.id_reklama_category == 3 && h.id_reklama_number == 1);
            if (reklamaTop != null)
            {
                BannerTop.Source = reklamaTop.img;
                BannerTop.IsVisible = true;

            }


            ReklamaCatalog reklamaBottomOne = App.Database.GetReklamaCatalog().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
                return c;
            }).SingleOrDefault(h => h.id_reklama_category == 3 && h.id_reklama_number == 2);
            if (reklamaBottomOne != null)
            {
                BannerBottomOne.Source = reklamaBottomOne.img;
                BannerBottomOne.IsVisible = true;
            }

            ReklamaCatalog reklamaBottomTwo = App.Database.GetReklamaCatalog().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
                return c;
            }).SingleOrDefault(h => h.id_reklama_category == 3 && h.id_reklama_number == 3);
            if (reklamaBottomTwo != null)
            {
                BannerBottomTwo.Source = reklamaBottomTwo.img;
                BannerBottomTwo.IsVisible = true;
            }

            ReklamaCatalog reklamaBottomThree = App.Database.GetReklamaCatalog().Select(c =>
            {
                c.img = App.linkServer + "/" + c.img;
                return c;
            }).SingleOrDefault(h => h.id_reklama_category == 3 && h.id_reklama_number == 4);
            if (reklamaBottomThree != null)
            {
                BannerBottomThree.Source = reklamaBottomThree.img;
                BannerBottomThree.IsVisible = true;
            }
            //----РЕКЛАМА
        }



        async void CatalogSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Task.Run(async () =>
            {
                using (UserDialogs.Instance.Loading("Загрузка..."))
                {
                    await Task.Delay(200);
                    Device.BeginInvokeOnMainThread(() => loadData(sender, e));
                }
            });
        }

        async void loadData(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null) return;
            var pageShopInfo = new CatalogInfo();
             pageShopInfo.LoadData((Catalog) e.SelectedItem);
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(pageShopInfo);
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
