using System;
namespace RozApp.Services
{
    public interface ITextService
    {
        //void CreateDirectory(string path);
        string ReadTextFile(string path, string fileName);
        void WriteTextFile(string path, string filename, string stringToWrite);
        string RootDirectory();
    }
}
