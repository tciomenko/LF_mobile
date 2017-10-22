using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using LF_mobile.DependencySvc;
using Xamarin.Forms;

namespace LF_mobile
{
	public partial class ReportageFullImage : ContentPage
	{
        public static string imageUrl;
		public ReportageFullImage()
		{
			InitializeComponent();

		}

        public async void BtnMenu(object sender, EventArgs e)
        {
            string action=await DisplayActionSheet("Меню","Отмена","","Сохранить фото в галерею");


            if(action== "Сохранить фото в галерею")
            {
                string Url= imgList.ItemsSource.Cast<Model.ReportageImg>().ToList().GetRange(imgList.Position,1).First().img;
                DependencyService.Get<IImageDownload>().SaveImageFromUrl();
                
            }
        }


        public async void LoadData(Model.Reportage item, int imageFirst)
        {
            

            this.Title = item.name;
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
        
		async void currentLoadData(Model.Reportage item, int imageFirst)
        {
            imgList.Position = App.Database.GetReportageImg().Where(h => h.reportage_id == item.id).ToList().FindIndex(a => a.id == imageFirst);
            	imgList.ItemsSource = App.Database.GetReportageImg().Select(c =>
			{
                c.img =imageUrl= App.linkServer + "/" + c.img;
				return c;
			}).Where(h => h.reportage_id == item.id).ToList();

        }


	}
}
