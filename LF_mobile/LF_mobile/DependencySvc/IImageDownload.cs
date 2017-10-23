using System;
namespace LF_mobile.DependencySvc
{
    public interface IImageDownload
    {
        void SaveImageFromUrl(string url);
    }
}
