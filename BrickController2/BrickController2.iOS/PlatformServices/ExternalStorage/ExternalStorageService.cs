using BrickController2.PlatformServices.ExternalStorage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrickController2.iOS.PlatformServices.ExternalStorage
{
    public class ExternalStorageService : IExternalStorageService
    {
        public Task CreateDirectory(string rootPath, string directoryname)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DirectoryExistsAsync(string directoryPath)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> FileExistsAsync(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetDirectorynamesFromDirectory(string directoryPath)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetFilenamesFromDirectory(string directoryPath)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> ReadAllFromFileAsync(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public Task WriteToFile(string filePath, string content, bool overwrite = true)
        {
            throw new System.NotImplementedException();
        }
    }
}