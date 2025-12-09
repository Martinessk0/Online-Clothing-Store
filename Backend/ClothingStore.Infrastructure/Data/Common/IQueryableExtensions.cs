using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ClothingStore.Infrastructure.Data.Common
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> query,
            bool condition,
            Expression<Func<T, bool>> predicate)
        {
            return condition ? query.Where(predicate) : query;
        }
    }
}
