using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0071.ExecutingAssembly
{
    /// <summary>
    /// Note that the entry 
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IFilePathProvider : IServiceDefinition
    {
        Task<string> GetFilePath();
    }
}
