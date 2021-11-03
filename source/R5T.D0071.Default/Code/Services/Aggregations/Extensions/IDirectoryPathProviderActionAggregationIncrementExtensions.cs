using System;


namespace R5T.D0071.Default
{
    public static class IDirectoryPathProviderActionAggregationIncrementExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IDirectoryPathProviderActionAggregationIncrement other)
            where T : IDirectoryPathProviderActionAggregationIncrement
        {
            aggregation.DirectoryPathProviderAction = other.DirectoryPathProviderAction;
            aggregation.FilePathProviderAction = other.FilePathProviderAction;

            return aggregation;
        }
    }
}
