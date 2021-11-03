using System;

using R5T.T0063;

using R5T.D0071.ExecutingAssembly;


namespace R5T.D0071.Default
{
    public interface IDirectoryPathProviderActionAggregationIncrement
    {
        public IServiceAction<IDirectoryPathProvider> DirectoryPathProviderAction { get; set; }
        public IServiceAction<IFilePathProvider> FilePathProviderAction { get; set; }
    }
}
