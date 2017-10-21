using System;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace LF_mobile.Forms
{
    public partial class TabPages : TabbedPage
    {
        public TabPages()
        {
            InitializeComponent();


            NavigationPage.SetHasBackButton(this, false);
            this.Title = "lifeshopping";

        }
    }
}
