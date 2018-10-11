using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Project.Extensions
{
    internal static class MappingExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllDestinationVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            Type desType = typeof(TDestination);
            foreach(PropertyInfo property in desType.GetProperties().Where(p => p.GetGetMethod().IsVirtual && !p.GetGetMethod().IsFinal))
                expression.ForMember(property.Name, opt => opt.Ignore());

            return expression;
        }

        public static IMappingExpression<TSource, TDestination> IgnoreAllSourceVirtual<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            Type desType = typeof(TDestination);
            Type srcType = typeof(TSource);
            foreach(PropertyInfo property in srcType.GetProperties().Where(p1 => p1.GetGetMethod().IsVirtual && !p1.GetGetMethod().IsFinal && desType.GetProperties().Any(p2 => p1.Name == p2.Name)))
                expression.ForMember(property.Name, opt => opt.Ignore());

            return expression;
        }
    }
}
