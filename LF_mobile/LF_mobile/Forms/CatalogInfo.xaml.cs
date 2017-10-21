using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using System.Diagnostics;
using LF_mobile.Class;
using LF_mobile.Model;
using Plugin.DeviceInfo;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LF_mobile.Forms
{
    public partial class CatalogInfo : ContentPage
    {
        Catalog itemModel;

		public CatalogInfo()
        {
            InitializeComponent();
            loadContent();
        }
		int selectCatalog;


        private async void loadContent()
        {
            await Task.Run(
               async () =>
               {
                   using (UserDialogs.Instance.Loading("Загрузка..."))
                   {
                       await Task.Delay(500);
                       Device.BeginInvokeOnMainThread(
                           () => currentLoadData(itemModel));
                   }
               });

        }


		public async Task setShowLike(int? idUser, int idCatalog,int like=0)
		{
			HttpClient client = new HttpClient();
			LikesShows likesShows = new LikesShows();
			try
			{
				HttpResponseMessage response = await client.GetAsync(App.linkServer + "/likesshows.ashx?idCatalog=" + idCatalog + "&idUser=" + idUser + "&like=" + like);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					likesShows = JsonConvert.DeserializeObject<LikesShows>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("=============Ошибка загрузки likesshows " + App.linkServer + "/likesshows.ashx?idCatalog=" + idCatalog + "&idUser=" + idUser + "&like=" + like);
			}

			if (likesShows != null)
			{
				likeCount.Text = likesShows.countLikes.ToString();
				viewCount.Text = likesShows.countShows.ToString();
			}
			else
			{ 
			    likeCount.Text = "0";
				viewCount.Text = "0";
			}

		}


		public async Task setComments(int? idUser, int idCatalog, string txt = "")
		{
			HttpClient client = new HttpClient();
			List<Comment> comments = new List<Comment>();
			try
			{
				HttpResponseMessage response = await client.GetAsync(App.linkServer + "/Comments.ashx?idCatalog=" + idCatalog + "&idUser=" + idUser + "&sendTxt=" + txt);
				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					comments = JsonConvert.DeserializeObject<List<Comment>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy HH:mm:ss" });
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("=============Ошибка загрузки /Comments.ashx?idCatalog=" + idCatalog + "&idUser=" + idUser + "&sendTxt=" + txt);
			}

			stackLayoutComments.HeightRequest = comments.Count * 100;

			if (comments.Count != 0)
			{
				CommentsList.IsVisible = true;
				CommentsList.ItemsSource = comments;
			}
			else
			{
				CommentsList.IsVisible = false;
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
						await setComments(Authorization.UserID, selectCatalog, messageTxt.Text);
						messageTxt.Text = "";
					}
				}
				else { 
						UserDialogs.Instance.Alert("Вы не авторизованы!", "Ошибка", null);
				}
			}
		}
 

        public async void LoadData(Model.Catalog item)
        {

            this.Title = item.name;
            itemModel = item;
        }

        public void DialNumber(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(String.Format("tel:{0}", ((Label)sender).Text)));
        }

        async void currentLoadData(Model.Catalog item)
        {
            try
           {

           
            this.Title = item.name;
            ImgHead.Source = App.linkServer + "/" + item.img_header;
            LabelHead.Text = item.name;
            LabelDescriptionLtl.Text = item.ltl_description;
            LabelAdress.Text = item.adress;
            LabelPhone.Text = item.phone;
            LabelSite.Text = item.site;
            LabelTimeJob.Text = item.time_job;
            icon_wifi.IsVisible = item.wifi;
            icon_visa.IsVisible = item.visa;
            icon_dostavka.IsVisible = item.delivery;
            icon_parking.IsVisible = item.parking;
            LabelDescript.Text = item.full_description;
			LabelInsta.Text = item.instagram;
			if (string.IsNullOrEmpty(item.instagram)) instaIco.IsVisible = false;


            var position = new Position(double.Parse(item.adress_latittude.ToString(), CultureInfo.InvariantCulture), double.Parse(item.adress_longitude.ToString(), CultureInfo.InvariantCulture)); // Latitude, Longitude
           
            var pin = new Pin { Type = PinType.Place, Position = position, Label = item.name, Address = item.adress };
            MapControl.Pins.Add(pin);
            MapControl.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(double.Parse(item.adress_latittude.ToString(), CultureInfo.InvariantCulture), double.Parse(item.adress_longitude.ToString(), CultureInfo.InvariantCulture)), Distance.FromMiles(0.1)));

            List<ParentGood> goodPhoto = new List<ParentGood>();
            foreach (Good good in App.Database.GetGood().Where(h => h.id_catalog == item.id))
            {

                goodPhoto.Add(new ParentGood()
                {
                    title = good.name,
                    description = good.description,
                    ChildPhotoes = App.Database.GetGoodPhoto().Where(h => h.id_goods == good.id).Select(c =>
                    {
                        c.img = App.linkServer + "/" + c.img;
                        c.name = c.name.ToUpper();
                        return c;
                    }).ToList()
                });

            }
            GoodList.ItemsSource = goodPhoto;

			stackLayoutGoods.HeightRequest = goodPhoto.Count * 205;
			if (goodPhoto.Count==0) GoodList.IsVisible = false;

			selectCatalog = item.id;
			int? idUser=null;
			if (Authorization.IsAuth) 
			{
				menuLabelUser.Text = Authorization.UserName + " " + Authorization.UserFirstName;
				idUser = Authorization.UserID;
			}

			await setShowLike(idUser, selectCatalog);
           
			await setComments(idUser, selectCatalog);




			}
            catch (Exception)
            {

            }
        }

		private async void clickLike(object sender, EventArgs e)
		{
			if (Authorization.IsAuth)
			{
				using (UserDialogs.Instance.Loading("Загрузка..."))
				{
					await Task.Delay(200);
					await setShowLike(Authorization.UserID, selectCatalog, 1);
				}
			}
		}

		async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var itemPhoto = e.Item as Model.GoodPhoto;
			var pageCatalogImgFull = new CatalogInfoFullImage();
			pageCatalogImgFull.LoadData(itemPhoto, itemPhoto.id);
		
			await this.Navigation.PushAsync(pageCatalogImgFull);
			((ListView)sender).SelectedItem = null;

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

		 private void OpenLinkInstagram(object sender, EventArgs e)
		{
			try
			{
Device.OpenUri(new Uri("https://www.instagram.com/" + ((Label)sender).Text));
			}
			catch (Exception ex)
			{

			}

		}

	//	protected override void OnDisappearing()
      //  {
          //  base.OnDisappearing();
           // this.Content = null;
       // }


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
    public class ParentGood
    {
        public string title { get; set; }

        public string description { get; set; }
        public List<GoodPhoto> ChildPhotoes { get; set; }
    }


}
