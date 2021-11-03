using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.T0063;

using R5T.D0071.ExecutingAssembly;


namespace R5T.D0071.Default
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="FilePathProvider"/> implementation of <see cref="IFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddFilePathProvider(this IServiceCollection services)
        {
            services.AddSingleton<IFilePathProvider, FilePathProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryPathProvider"/> implementation of <see cref="IDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectoryPathProvider(this IServiceCollection services,
            IServiceAction<IFilePathProvider> filePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            services.AddSingleton<IDirectoryPathProvider, DirectoryPathProvider>()
                .Run(filePathProviderAction)
                .Run(stringlyTypedPathOperatorAction);

            return services;
        }
    }
}
