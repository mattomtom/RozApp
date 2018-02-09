using System;
using System.Diagnostics;
using Java.IO;
using RozApp.Droid.DependencyService;
using RozApp.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(TextService))]
namespace RozApp.Droid.DependencyService
{
    public class TextService : ITextService
    {
        public TextService()
        {
        }


        public string ReadTextFile(string path, string fileName)
        {
            //throw new NotImplementedException();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Path.Combine(path, fileName)))
            {
                string line = sr.ReadToEnd();
                Debug.WriteLine("Text: " + line);
                sr.Close();
                return line;
            }
        }

        private string creaFileName(string directory, string fileName)
        {
            string path = RootDirectory();
            string file = System.IO.Path.Combine(path, fileName);
            return file;
        }

        public void WriteTextFile(string path, string fileName, string stringToWrite)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(path, fileName), false))
            {
                sw.WriteLine(stringToWrite);
                sw.Close();
            }
        }

        public string RootDirectory()
        {
            File path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            return path.AbsolutePath;
        }
    }
}

