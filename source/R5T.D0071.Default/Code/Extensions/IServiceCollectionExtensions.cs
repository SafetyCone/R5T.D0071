using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy;

using R5T.D0071.ExecutingAssembly;


namespace R5T.D0071.Default
{
    public static class IServiceCollectionExtensions
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
        /// Adds the <see cref="FilePathProvider"/> implementation of <see cref="IFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IFilePathProvider> AddFilePathProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IFilePathProvider>(() => services.AddFilePathProvider());
            return serviceAction;
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

        /// <summary>
        /// Adds the <see cref="DirectoryPathProvider"/> implementation of <see cref="IDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IDirectoryPathProvider> AddDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IFilePathProvider> filePathProviderAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var serviceAction = ServiceAction.New<IDirectoryPathProvider>(() => services.AddDirectoryPathProvider(
                filePathProviderAction,
                stringlyTypedPathOperatorAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="DirectoryPathProvider"/> implementation of <see cref="IDirectoryPathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static DirectoryPathProviderAggregation01 AddDirectoryPathProviderAction(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction)
        {
            var filePathProviderAction = services.AddFilePathProviderAction();

            var directoryPathProviderAction = services.AddDirectoryPathProviderAction(
                filePathProviderAction,
                stringlyTypedPathOperatorAction);

            return new DirectoryPathProviderAggregation01
            {
                DirectoryPathProviderAction = directoryPathProviderAction,
                FilePathProviderAction = filePathProviderAction,
            };
        }
    }
}
