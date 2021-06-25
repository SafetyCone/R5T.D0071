using System;
using System.Reflection;
using System.Threading.Tasks;


namespace R5T.D0071.ExecutingAssembly
{
    public class FilePathProvider : IFilePathProvider
    {
        public Task<string> GetFilePath()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            var filePath = executingAssembly.Location;
            
            return Task.FromResult(filePath);
        }
    }
}
