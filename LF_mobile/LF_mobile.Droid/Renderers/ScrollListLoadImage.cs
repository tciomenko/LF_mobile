using Android.Widget;
using FFImageLoading;
using LF_mobile.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ListView), typeof(ScrollListLoadImage))]
namespace LF_mobile.Droid
{
    public class ScrollListLoadImage : ListViewRenderer
    {
       
  
    public ScrollListLoadImage ()
    {

    }
    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
    {
        base.OnElementChanged(e);

        if (Control == null)
            return;

        var listView = Control as global::Android.Widget.ListView;
        listView.ScrollStateChanged += (object sender, AbsListView.ScrollStateChangedEventArgs scrollArgs) => {
            switch (scrollArgs.ScrollState)
            {
                case ScrollState.Fling:
                    ImageService.Instance.SetPauseWork(true); // all image loading requests will be silently canceled
                    break;
                case ScrollState.Idle:
                    ImageService.Instance.SetPauseWork(false); // loading requests are allowed again
                    break;
            }
        };
    }
}
}