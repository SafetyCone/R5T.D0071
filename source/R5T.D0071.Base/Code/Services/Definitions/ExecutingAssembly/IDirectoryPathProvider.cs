using System;
using System.Threading.Tasks;


namespace R5T.D0071.ExecutingAssembly
{
    public interface IDirectoryPathProvider
    {
        Task<string> GetDirectoryPath();
    }
}
