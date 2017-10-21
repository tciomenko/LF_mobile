using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LF_mobile.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(AwesomeRenderer))]

namespace LF_mobile.Droid
{

    public class AwesomeRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Console.Write("==============" + e.NewElement.FontFamily);
            if (e.NewElement.FontFamily == "FontAwesome")
            {
                var label = (TextView) Control;
                var text = label.Text;
                if (text.Length > 1 || text[0] < 0xf000)
                {
                    return;
                }
                var font = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.ApplicationContext.Assets, "Fonts/fontawesome.ttf");
                label.Typeface = font;
            }
            else
            {
                    try
                    {
                        var font = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.ApplicationContext.Assets, "Fonts/" + e.NewElement.FontFamily + ".ttf");
                        Control.Typeface = font;
                    }
                    catch (Exception ex)
                    {
                        // An exception means that the custom font wasn't found.
                        // Typeface.CreateFromAsset throws an exception when it didn't find a matching font.
                        // When it isn't found we simply do nothing, meaning it reverts back to default.
                    }
            }




        }
    }

}


//base.OnElementChanged(e);

//var label = (TextView)Control;

//var text = label.Text;
//            if (text.Length > 1 || text[0] < 0xf000)
//            {
//                return;
//            }

//            var font = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.ApplicationContext.Assets, "Fonts/" + e.NewElement.FontFamily + ".ttf");
//label.Typeface = font;




