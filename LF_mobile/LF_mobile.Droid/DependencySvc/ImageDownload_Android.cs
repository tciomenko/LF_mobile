using System;
using System.IO;
using System.Net;
using LF_mobile.DependencySvc;
using LF_mobile.iOS.DependencySvc;

[assembly: Xamarin.Forms.Dependency(typeof(ImageDownload_Android))]
namespace LF_mobile.iOS.DependencySvc
{
    public class ImageDownload_Android:Java.Lang.Object,IImageDownload
    {
        public ImageDownload_Android()
        {
        }

        public async void SaveImageFromUrl()
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