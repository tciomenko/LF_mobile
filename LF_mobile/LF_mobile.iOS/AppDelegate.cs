
using FFImageLoading.Config;
using FFImageLoading.Forms.Touch;
using Foundation;
using Telerik.XamarinForms.Common.iOS;
using UIKit;
using System.Net.Http;
using DLToolkit.Forms.Controls;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Telerik.XamarinForms.Primitives.RadSideDrawer), typeof(Telerik.XamarinForms.PrimitivesRenderer.iOS.SideDrawerRenderer))]
namespace LF_mobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			new Telerik.XamarinForms.PrimitivesRenderer.iOS.SideDrawerRenderer();
           Xamarin.Forms.Forms.Init();
			TelerikForms.Init();
            LoadApplication(new App());

            
            Xamarin.FormsMaps.Init();
            CachedImageRenderer.Init();
            FlowListView.Init();
            UIApplication.SharedApplication.StatusBarHidden = true;
            App.ScreenWidth = UIScreen.MainScreen.Bounds.Width/2;
            App.ScreenHeight = UIScreen.MainScreen.Bounds.Height/2;
            var config = new Configuration
            {
                HttpClient = new HttpClient(new ModernHttpClient.NativeMessageHandler()),  //используем быстрые библиотеки для загрузки 
                FadeAnimationDuration = 250,  //ускоряем анимацию появления 
            };
            FFImageLoading.ImageService.Instance.Initialize(config);


            return base.FinishedLaunching(app, options);
        }
    }
}
