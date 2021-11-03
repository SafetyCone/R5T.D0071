using System;

using R5T.Lombardy;

using R5T.T0062;
using R5T.T0063;

using R5T.D0071.ExecutingAssembly;


namespace R5T.D0071.Default
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FilePathProvider"/> implementation of <see cref="IFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFilePathProvider> AddFilePathProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IFilePathProvider>(services => services.AddFilePathProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryPathProvider"/> implementation of <see cref="IDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDirectoryPathProvider> AddDirectoryPathProviderAction(this IServiceAction _,
            IServiceAction<IFilePathProvider> filePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = _.New<IDirectoryPathProvider>(services => services.AddDirectoryPathProvider(
                filePathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryPathProvider"/> implementation of <see cref="IDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static DirectoryPathProviderActionAggregation AddDirectoryPathProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            // Services.
            // Level 0.
            var filePathProviderAction = _.AddFilePathProviderAction();

            // Level 1.
            var directoryPathProviderAction = _.AddDirectoryPathProviderAction(
                filePathProviderAction,
                stringlyTypedPathOperatorAction);

            return new DirectoryPathProviderActionAggregation
            {
                DirectoryPathProviderAction = directoryPathProviderAction,
                FilePathProviderAction = filePathProviderAction,
            };
        }
    }
}
