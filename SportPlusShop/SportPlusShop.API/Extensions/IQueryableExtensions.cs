using System.Linq.Expressions;
using System.Reflection;

namespace SportPlusShop.API.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<TEntity> OrderByCustom<TEntity>(this IQueryable<TEntity> items, string sortBy, string sortOrder)
    {
        Type type = typeof(TEntity);
        ParameterExpression expression2 = Expression.Parameter(type, "t");
        PropertyInfo? property = type.GetProperty(sortBy);

        MemberExpression expression1 = Expression.MakeMemberAccess(expression2, property!);
        LambdaExpression lambda = Expression.Lambda(expression1, expression2);

        MethodCallExpression result = Expression.Call(
            typeof(Queryable),
            sortOrder == "desc" ? "OrderByDescending" : "OrderBy",
            new Type[] { type, property!.PropertyType },
            items.Expression,
            Expression.Quote(lambda));

        return items.Provider.CreateQuery<TEntity>(result);
    }
}

