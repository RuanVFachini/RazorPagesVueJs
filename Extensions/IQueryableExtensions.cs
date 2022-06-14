using System.Linq.Expressions;
using System.Text.RegularExpressions;
using RazorPagesVueJs.Dtos;

namespace RazorPagesVueJs.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> SortAndPage<T>(this IQueryable<T> query, RequestModelDto model) {

            return query
                .SortBy(model.Sort)
                .Skip(model.Skip)
                .Take(model.MaxResult);
        }

        public static IQueryable<T> SortBy<T>(this IQueryable<T> query, string? sort) {
            
            if (!string.IsNullOrEmpty(sort)) {

                var isMatch = new Regex("^[+-]").IsMatch(sort);
                var asc = isMatch ? sort[0] == '+' : true;
                var field = string.Empty;

                var propertyStartIndex = isMatch ? 1 : 0;
                var fieldCharArray = sort.Substring(propertyStartIndex);
                field = char.ToUpper(fieldCharArray[0]) + fieldCharArray.Substring(1);

                var property = typeof(T).GetProperty(field);

                if (property != null) {
                    var parameter = Expression.Parameter(typeof(T));
                    var memberExpression = Expression.Property(parameter, typeof(T), field);
                    var orderBy = Expression.Lambda(memberExpression, parameter);
                    
                    return asc
                        ? System.Linq.Queryable.OrderBy(query, (dynamic) orderBy)
                        : System.Linq.Queryable.OrderByDescending(query, (dynamic) orderBy);
                }
            }

            return query;
        }
    }
}