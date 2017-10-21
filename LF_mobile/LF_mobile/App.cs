using System.Diagnostics;
using LF_mobile.Class;
using LF_mobile.Forms;
using Xamarin.Forms;

namespace LF_mobile
{
    public class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;
        public const string linkServer = "http://mobile.lifeshopping.ru";
        public const string DATABASE_NAME = "LF_Database.db";
        public static DBcommands database;
        public static DBcommands Database
        {
            get
            {
                if (database == null)
                {
                    database = new DBcommands(DATABASE_NAME);
                }
                return database;
            }
        }

        public App()
        {
			// The root page of your application
			//  var pageTabsPage = new TabPages();
			// NavigationPage.SetHasNavigationBar(pageTabsPage, false);
			//  MainPage = new NavigationPage(pageTabsPage);
			Debug.WriteLine("----------------------------------------------0");
			UpdateFromServer srv = new UpdateFromServer();
			srv.update();
			Debug.WriteLine("----------------------------------------------1");
            new Authorization();


	

			MainPage = new NavigationPage(new TabPages())
            {
                BarBackgroundColor = Color.FromHex("#000000"),
                BarTextColor = Color.White,
                Title="lifeshopping"
            };
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
