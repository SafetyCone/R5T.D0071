using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0071.ExecutingAssembly
{
    [ServiceDefinitionMarker]
    public interface IDirectoryPathProvider : IServiceDefinition
    {
        Task<string> GetDirectoryPath();
    }
}
