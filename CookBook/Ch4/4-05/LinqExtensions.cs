using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Ch4
{
    public static class LinqExtensions
    {
        public static decimal? WeightedMovingAverage(this IEnumerable<decimal?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            decimal aggregate = 0.0M;
            decimal weight;
            int item = 1;
            // count how many items are not null and use that as the wighting factor
            int count = source.Count(val => val.HasValue);
            foreach (var nullable in source)
            {
                if (nullable.HasValue)
                {
                    weight = item / count;
                    aggregate += nullable.GetValueOrDefault() * weight;
                    count++;
                }
            }
            if (count > 0)
                return new decimal?(aggregate / count);
            return null;
        }

        public static double? WeightedMovingAverage(this IEnumerable<double?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            double aggregate = 0.0d;
            double weight;
            int item = 1;
            // count how many items are not null and use that as the wighting factor
            int count = source.Count(val => val.HasValue);
            foreach (var nullable in source)
            {
                if (nullable.HasValue)
                {
                    weight = item / count;
                    aggregate += nullable.GetValueOrDefault() * weight;
                    count++;
                }
            }
            if (count > 0)
                return new double?(aggregate / count);
            return null;
        }

        public static float? WeightedMovingAverage(this IEnumerable<float?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            float aggregate = 0.0f;
            float weight;
            int item = 1;
            // count how many items are not null and use that as the wighting factor
            int count = source.Count(val => val.HasValue);
            foreach (var nullable in source)
            {
                if (nullable.HasValue)
                {
                    weight = item / count;
                    aggregate += nullable.GetValueOrDefault() * weight;
                    count++;
                }
            }
            if (count > 0)
                return new float?(aggregate / count);
            return null;
        }

        public static int? WeightedMovingAverage(this IEnumerable<int?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            int aggregate = 0;
            int weight;
            int item = 1;
            // count how many items are not null and use that as the wighting factor
            int count = source.Count(val => val.HasValue);
            foreach (var nullable in source)
            {
                if (nullable.HasValue)
                {
                    weight = item / count;
                    aggregate += nullable.GetValueOrDefault() * weight;
                    count++;
                }
            }
            if (count > 0)
                return new int?(aggregate / count);
            return null;
        }

        public static long? WeightedMovingAverage(this IEnumerable<long?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            long aggregate = 0L;
            long weight;
            int item = 1;
            // count how many items are not null and use that as the wighting factor
            int count = source.Count(val => val.HasValue);
            foreach (var nullable in source)
            {
                if (nullable.HasValue)
                {
                    weight = item / count;
                    aggregate += nullable.GetValueOrDefault() * weight;
                    count++;
                }
            }
            if (count > 0)
                return new long?(aggregate / count);
            return null;
        }

        public static double? Average(this IEnumerable<short?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            double aggregate = 0.0;
            int count = 0;

            foreach (var nullable in source)
            {
                if (nullable.HasValue)
                {
                    aggregate += nullable.GetValueOrDefault();
                    count++;
                }
            }

            if(count > 0)
                return new double?(aggregate / count);
            return null;
        }

        public static double Average(this IEnumerable<short> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            double aggregate = 0.0;
            int count = source.Count();

            foreach (var value in source)
            {
                aggregate += value;
            }

            if (count > 0)
                return aggregate / count;
            return 0.0;
        }

        public static double? Average<TSource>(this IEnumerable<TSource> source,
            Func<TSource, short?> selector) => source.Select<TSource, short?>(selector).Average();

        public static double Average<TSource>(this IEnumerable<TSource> source,
            Func<TSource, short> selector) => source.Select<TSource, short>(selector).Average();
    }
}
