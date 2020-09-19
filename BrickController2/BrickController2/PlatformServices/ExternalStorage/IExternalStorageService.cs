using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrickController2.PlatformServices.ExternalStorage
{
    public interface IExternalStorageService
    {
        Task<bool> FileExistsAsync(string filePath);
        Task<bool> DirectoryExistsAsync(string directoryPath);
        Task<IEnumerable<string>> GetFilenamesFromDirectory(string directoryPath);
        Task<IEnumerable<string>> GetDirectorynamesFromDirectory(string directoryPath);
        Task CreateDirectory(string rootPath, string directoryname);
        Task<string> ReadAllFromFileAsync(string filePath);
        Task WriteToFile(string filePath, string content, bool overwrite = true);
    }
}
