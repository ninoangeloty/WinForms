using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hats.Infrastructure.Core
{
    public static class EnumerableExtensions
    {
        public static IQueryable<TSource> FilterWhen<TSource>(this IQueryable<TSource> source, Func<bool> predicate, Expression<Func<TSource, bool>> criteria)
        {
            if (predicate.Invoke())
            {
                return source.Where(criteria);
            }

            return source;
        }

        public static IEnumerable<TSource> FilterWhen<TSource>(this IEnumerable<TSource> source, Func<bool> predicate, Func<TSource, bool> criteria)
        {
            if (predicate.Invoke())
            {
                return source.Where(criteria);
            }

            return source;
        }
    }
}
