using System;
using System.Net.Http;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DLToolkit.Forms.Controls;
using FFImageLoading.Config;
using FFImageLoading.Forms.Droid;
using ScnViewGestures.Plugin.Forms.Droid.Renderers;
using Telerik.XamarinForms.Common.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Telerik.XamarinForms.Primitives.RadSideDrawer), typeof(Telerik.XamarinForms.PrimitivesRenderer.Android.SideDrawerRenderer))]
namespace LF_mobile.Droid
{
    [Activity(Label = "lifeshopping", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
  
			global::Xamarin.Forms.Forms.Init(this, bundle);


			Xamarin.FormsMaps.Init(this, bundle);
			UserDialogs.Init(this);
			TelerikForms.Init();
			FlowListView.Init();
            var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;

            App.ScreenWidth = (width - 0.5f) / density;
            App.ScreenHeight = (height - 0.5f) / density;

			if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
			{

			}
			else
			{

				UserDialogs.Instance.AlertAsync( "Отсутствует подключение к интернет! Некоторые возможности будут отключены!","Внимание!");
			}

			CachedImageRenderer.Init();
			var config = new Configuration
			{
				HttpClient = new HttpClient(new ModernHttpClient.NativeMessageHandler()),  //используем быстрые библиотеки для загрузки 
				FadeAnimationDuration = 250,  //ускоряем анимацию появления 
			};
			FFImageLoading.ImageService.Instance.Initialize(config);







			LoadApplication(new App());


        }
    }
}

