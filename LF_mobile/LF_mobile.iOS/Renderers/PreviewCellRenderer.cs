using LF_mobile;
using LF_mobile.iOS;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using LF_mobile.Cells;
using LF_mobile.iOS.Renderers;
using System.Drawing;
using Foundation;
using LF_mobile.Forms;

[assembly: ExportRenderer(typeof(PreviewCell), typeof(PreviewCellRenderer))]
namespace LF_mobile.iOS.Renderers
{
    
    public class PreviewCellRenderer:ViewCellRenderer
    {
        public override UITableViewCell GetCell(Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            if (cell != null)
            {
                // Override background color
                cell.SelectedBackgroundView = new UIView() { BackgroundColor = UIColor.Black };
                cell.BackgroundColor = UIColor.Black; // Set whatever native properties you need
                cell.Layer.AutoReverses = true;
                OnBindingContextChanged(item);

            }
            tv.SeparatorStyle = UITableViewCellSeparatorStyle.None;

            return cell;
        }


        protected void OnBindingContextChanged(Xamarin.Forms.Cell cell)
        {
            //Here I check what type of data is being bound to the cell so I can get the text needed to calculate the information
            //ResponseView is the custom class that I bound to the listview
            var context = cell.BindingContext as Preview;
            if (context != null)
            {
                const int totalPadding = 40; // Width Padding
                cell.Height = 1000;

            }

        }

        //private Decimal EstimateHeight(String text, Int32 width, UIFont font)
        //{

        //    SizeF size = ((NSString)text).StringSize(font, new SizeF(width, float.MaxValue), UILineBreakMode.WordWrap);
        //    return (Decimal)size.Height + 50; // The +50 is for extra height padding
            
        //}

    }
}