using System;
using LF_mobile;
using LF_mobile.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ListView), typeof(ListtViewCustomRenderer))]
namespace LF_mobile.Droid
{
	public class ListtViewCustomRenderer : ListViewRenderer
	{
		protected override void OnAttachedToWindow()
		{
			base.OnAttachedToWindow();
			this.Control.SetSelection(0);
		}

		public ListtViewCustomRenderer()
		{
		}
	}
}
