using System;
using System.Threading.Tasks;

using R5T.Lombardy;


namespace R5T.D0071.ExecutingAssembly
{
    public class DirectoryPathProvider : IDirectoryPathProvider
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
