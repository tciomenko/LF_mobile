using System;
using UIKit;
using AVFoundation;
using Xamarin.Forms;
using LF_mobile.iOS.DependencySvc;
using LF_mobile.DependencySvc;
using System.Net;
using System.IO;


[assembly: Dependency(typeof(ImageDownload_iOS))]
namespace LF_mobile.iOS.DependencySvc
{
    public class ImageDownload_iOS:IImageDownload
    {
        public ImageDownload_iOS()
        {
        }

        public void SaveImageFromUrl()
        {
                var webClient = new WebClient();
                webClient.DownloadDataCompleted += (s, e) => {
                    var bytes = e.Result; // get the downloaded data
                    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    string localFilename = "downloaded.png";
                    string localPath = Path.Combine(documentsPath, localFilename);
                    File.WriteAllBytes(localPath, bytes); // writes to local storage


                };
                var url = new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png");
                webClient.DownloadDataAsync(url);


            }
        }
    }