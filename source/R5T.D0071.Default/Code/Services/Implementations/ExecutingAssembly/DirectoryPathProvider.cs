using System;
using System.Threading.Tasks;

using R5T.Lombardy;

using R5T.T0064;


namespace R5T.D0071.ExecutingAssembly
{
    [ServiceImplementationMarker]
    public class DirectoryPathProvider : IDirectoryPathProvider, IServiceImplementation
    {
        private IFilePathProvider FilePathProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public DirectoryPathProvider(
            IFilePathProvider filePathProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.FilePathProvider = filePathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public async Task<string> GetDirectoryPath()
        {
            var filePath = await this.FilePathProvider.GetFilePath();

            var directoryPath = this.StringlyTypedPathOperator.GetDirectoryPathForFilePath(filePath);
            return directoryPath;
        }
    }
}
