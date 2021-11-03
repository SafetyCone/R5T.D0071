using System;
using System.Reflection;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0071.ExecutingAssembly
{
    [ServiceImplementationMarker]
    public class FilePathProvider : IFilePathProvider, IServiceImplementation
    {
        public Task<string> GetFilePath()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            var filePath = executingAssembly.Location;
            
            return Task.FromResult(filePath);
        }
    }
}
