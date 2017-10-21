using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace LF_mobile
{
	public partial class CatalogInfoFullImage : ContentPage
	{
		public CatalogInfoFullImage()
		{
			InitializeComponent();
		}
	

	public async void LoadData(Model.GoodPhoto item, int imageFirst)
	{
		//this.Title = item.name;
		await Task.Run(async () =>
		{
			using (UserDialogs.Instance.Loading("Загрузка..."))
			{
				await Task.Delay(500);
				Device.BeginInvokeOnMainThread(
					() => currentLoadData(item, imageFirst));
			}
		});
	}

	async void currentLoadData(Model.GoodPhoto item, int imageFirst)
	{
			
		imgList.Position = App.Database.GetGoodPhoto().Where(h => h.id_goods == item.id_goods).ToList().FindIndex(a => a.id == imageFirst);

	imgList.ItemsSource = App.Database.GetGoodPhoto().Select(c =>
	{
		c.img = App.linkServer + "/" + c.img; 
		return c;
	}).Where(h => h.id_goods == item.id_goods).ToList();

	}


}
	}