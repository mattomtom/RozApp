using System;
using System.IO;
using RozApp.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace RozApp.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
