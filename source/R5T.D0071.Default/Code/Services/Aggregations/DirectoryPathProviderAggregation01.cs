using System;

using R5T.Dacia;

using R5T.D0071.ExecutingAssembly;


namespace R5T.D0071.Default
{
    public class DirectoryPathProviderAggregation01
    {
        public IServiceAction<IDirectoryPathProvider> DirectoryPathProviderAction { get; set; }
        public IServiceAction<IFilePathProvider> FilePathProviderAction { get; set; }
    }
}
