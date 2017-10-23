using System;
using UIKit;
using AVFoundation;
using Xamarin.Forms;
using LF_mobile.iOS.DependencySvc;
using LF_mobile.DependencySvc;
using System.Net;
using System.IO;
using AssetsLibrary;
using Foundation;
using System.Threading.Tasks;
using ImageIO;

[assembly: Dependency(typeof(ImageDownload_iOS))]
namespace LF_mobile.iOS.DependencySvc
{
    public class ImageDownload_iOS:IImageDownload
    {
        public void SaveImageFromUrl(string url)
        {
            var ns = new NSDictionary();
            ALAssetsLibrary library = new ALAssetsLibrary();

            var image = ImageDownload_iOS.NSDataFromUrl(url);

            library.WriteImageToSavedPhotosAlbum(image, ns, (assetUrl, error) => {
                    Console.WriteLine("assetUrl:" + assetUrl);
                });



        }
        static  UIImage FromUrl(string uri)
        {
            using (var data = NSData.FromUrl(new Uri(uri)))
                return  UIImage.LoadFromData(data);
        }
        static NSData NSDataFromUrl(string uri)
        {

            return NSData.FromUrl(new Uri(uri));
        }
        }
    }