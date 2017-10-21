using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LF_mobile.Class;
using LF_mobile.Model;
using Newtonsoft.Json;
using Plugin.DeviceInfo;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace LF_mobile.Forms
{
    public partial class Login : ContentPage
    {
        ImportExportUser serverUser = new ImportExportUser();
   

        async void LoadData(bool redirect=false)
        {
            this.Title = "Вход";
            new Authorization();
            if (!Authorization.IsAuth)
            {
                if (redirect) UserDialogs.Instance.Alert("Ошибка связи с сервером!");
                return;
            }
            userName.Text = Authorization.UserName;
            userFamlilia.Text = Authorization.UserFirstName;
            menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;
            btnSave.Text = "Сохранить";
            this.Title = "Личный кабинет";

            if (redirect)
            {
                var masterPage = new TabPages();
                masterPage.CurrentPage = masterPage.Children[0];
                this.Navigation.PushAsync(masterPage);
            }
        }

        public Login()
        {
            InitializeComponent();
            loadContent();
        }

        private async void loadContent()
        {

            await Task.Run(async () => {
                using (UserDialogs.Instance.Loading("Загрузка..."))
                {
                    await Task.Delay(500);
                    Device.BeginInvokeOnMainThread(() => LoadData());
                }
            });
        }

        private async void SaveUser(object sender, EventArgs e)
        {
            User usr=new User() {first_name = userFamlilia.Text, id=0,img="",name= userName.Text, uid = CrossDeviceInfo.Current.Id };
            serverUser.SaveAsync(usr);

            await Task.Run(async () => {
                using (UserDialogs.Instance.Loading("Сохранение..."))
                {
                    await Task.Delay(2500);
                    Device.BeginInvokeOnMainThread(() => LoadData(true));
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
        }

        private void MenuClickCatalog(object sender, EventArgs e)
        {
            SlideMenu.IsOpen = false;
            var masterPage =new TabPages();
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
