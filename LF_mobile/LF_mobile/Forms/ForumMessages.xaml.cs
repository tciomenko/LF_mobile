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
    public partial class ForumMessages : ContentPage
    {
		private int selectTheme;
        private int selectSubTheme;
		public async void LoadData(Model.ForumSubTheme item)
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

		async void currentLoadData(Model.ForumSubTheme item)
		{
			selectTheme = item.theme_id;
			selectSubTheme = item.id;

			await setSubtheme(Authorization.UserID, selectTheme, selectSubTheme, messageTxt.Text);

			if (Authorization.IsAuth) menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;
		}

		public async Task setSubtheme(int? idUser, int idTheme,int idSubTheme,string txt = "")
		{
			HttpClient client = new HttpClient();
			List<ForumMessage> comments = new List<ForumMessage>();
			try
			{
				HttpResponseMessage response = await client.GetAsync(App.linkServer + "/ForumMessges.ashx?idTheme=" + idTheme + "&idSubTheme=" + idSubTheme + "&idUser=" + idUser + "&sendTxt=" + txt);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					comments = JsonConvert.DeserializeObject<List<ForumMessage>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("=============Ошибка загрузки " + App.linkServer + "/ForumMessges.ashx?idTheme=" + idTheme + "&idSubTheme=" + idSubTheme + "&idUser=" + idUser + "&sendTxt=" + txt);
			}

			if (comments.Count != 0)
			{
				ForumMessagesList.IsVisible = true;
				ForumMessagesList.ItemsSource = comments;
			}
			else
			{
				ForumMessagesList.IsVisible = false;
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
						await setSubtheme(Authorization.UserID, selectTheme,selectSubTheme, messageTxt.Text);
						messageTxt.Text = "";
					}
				}
				else
				{
					UserDialogs.Instance.Alert("Вы не авторизованы!", "Ошибка", null);
				}
			}
		}


		public ForumMessages()
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
