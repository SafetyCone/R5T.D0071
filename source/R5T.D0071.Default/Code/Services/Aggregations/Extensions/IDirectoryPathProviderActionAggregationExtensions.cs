using System;


namespace R5T.D0071.Default
{
    public static class IDirectoryPathProviderActionAggregationExtensions
    {
        public static T FillFrom<T>(this T aggregation,
            IDirectoryPathProviderActionAggregation other)
            where T : IDirectoryPathProviderActionAggregation
        {
            (aggregation as IDirectoryPathProviderActionAggregationIncrement).FillFrom(other);

            return aggregation;
        }
    }
}
