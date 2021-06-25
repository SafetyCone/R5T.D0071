using System;
using System.Threading.Tasks;


namespace R5T.D0071.ExecutingAssembly
{
    /// <summary>
    /// Note that the entry 
    /// </summary>
    public interface IFilePathProvider
    {
        Task<string> GetFilePath();
    }
}
