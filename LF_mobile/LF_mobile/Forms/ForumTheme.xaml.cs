using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LF_mobile.Class;
using LF_mobile.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace LF_mobile.Forms
{
    public partial class ForumTheme : ContentPage
    {
		private int selectTheme;
        public async void LoadData(Model.Forum item)
        {
            this.Title = item.theme_name;
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

        async void currentLoadData(Model.Forum item)
        {
            selectTheme = item.id;

			await setSubtheme(Authorization.UserID, selectTheme, messageTxt.Text);

            if (Authorization.IsAuth) menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;
        }

		public async Task setSubtheme(int? idUser, int idTheme, string txt = "")
		{
			HttpClient client = new HttpClient();
			List<ForumSubTheme> comments = new List<ForumSubTheme>();
			try
			{
				HttpResponseMessage response = await client.GetAsync(App.linkServer + "/ForumMessges.ashx?idTheme=" + idTheme + "&idUser=" + idUser + "&sendTxt=" + txt);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					comments = JsonConvert.DeserializeObject<List<ForumSubTheme>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
				}
						}
			catch (Exception e)
			{
				Debug.WriteLine("=============Ошибка загрузки /ForumMessges.ashx?idTheme=" + idTheme + "&idUser=" + idUser + "&sendTxt=" + txt);
			}

			if (comments.Count != 0)
			{
				ForumThemeList.IsVisible = true;
				ForumThemeList.ItemsSource = comments;
			}
			else
			{
				ForumThemeList.IsVisible = false;
			}

		}

		public async void sendMessage(object sender, EventArgs e)
		{
			if (messageTxt.Text != "")
			{
				if (Authorization.IsAuth)
				{
					using (UserDialogs.Instance.Loading("Загрузка..."))
					{
						await Task.Delay(200);
						await setSubtheme(Authorization.UserID, selectTheme, messageTxt.Text);
						messageTxt.Text = "";
					}
				}
				else
				{
					UserDialogs.Instance.Alert("Вы не авторизованы!", "Ошибка", null);
				}
			}
		}

		async void ForumSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (((ListView)sender).SelectedItem == null) return;
			var pageForumMessages = new ForumMessages();
			pageForumMessages.LoadData((Model.ForumSubTheme)e.SelectedItem);
			await this.Navigation.PushAsync(pageForumMessages);
			((ListView)sender).SelectedItem = null;
		}

        public ForumTheme()
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
