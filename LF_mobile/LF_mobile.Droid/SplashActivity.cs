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
using Android.Content;

namespace LF_mobile.Droid
{
	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			//Thread.Sleep(10000); // Simulate a long loading process on app startup.

			var intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
         }

	}
}
