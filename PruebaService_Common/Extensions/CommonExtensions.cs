using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PruebaService_Common.Extensions
{
    public static class CommonExtensions
    {
        public delegate object ConstructorDelegate(params object[] args);

        public static ConstructorDelegate CreateConstructor(Type type, params Type[] parameters)
        {
            var constructorInfo = type.GetConstructor(parameters);

            var paramExpr = Expression.Parameter(typeof(Object[]));

            var constructorParameters = parameters.Select((paramType, index) =>
                Expression.Convert(
                    Expression.ArrayAccess(
                        paramExpr,
                        Expression.Constant(index)),
                    paramType)).ToArray();

            var body = Expression.New(constructorInfo, constructorParameters);

            var constructor = Expression.Lambda<ConstructorDelegate>(body, paramExpr);
            return constructor.Compile();
        }

        public static T UseIf<T>(this T obj, bool conditional, Func<T, T> funcIf, Func<T, T> funcElse) =>
            conditional ? funcIf(obj) : funcElse(obj);

        public static T UseIf<T>(this T obj, bool conditional, Func<T, T> funcIf) =>
            conditional ? funcIf(obj) : obj;
    }
}
