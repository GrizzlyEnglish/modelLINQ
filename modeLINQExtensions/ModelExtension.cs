using System;
using System.Linq.Expressions;

namespace modelLINQ
{
    public static class ModelExtension
    {

        /// <summary>
        /// Proxy method for generating a new member expression, just for saving on 
        /// typing each time a new model is needing to be generated
        /// </summary>
        /// <typeparam name="TSource">The source of the model whom gets passed down to the bindings</typeparam>
        /// <typeparam name="TResult">The result of the new expression init</typeparam>
        /// <param name="bindingGenerator">A function that generates the necessary bindings of the model from the source</param>
        /// <param name="paramName">If you want to overide the name of the source, otherwise default to source</param>
        /// <returns>
        /// A new expression lamaba of the model being generated
        /// </returns>
        public static Expression<Func<TSource, TResult>> Model<TSource, TResult>(this Func<Expression, MemberBinding[]> bindingGenerator, string paramName = "source")
        {
            ParameterExpression param = Expression.Parameter(typeof(TSource), paramName);
            NewExpression newModel = Expression.New(typeof(TResult));
            MemberInitExpression init = Expression.MemberInit(newModel, bindingGenerator(param));
            return Expression.Lambda<Func<TSource, TResult>>(init, param);
        }

        /// <summary>
        /// Generates an expression conditional that checks if the source is null before
        /// adding the new memeber init expression
        /// </summary>
        /// <typeparam name="TSource">The source we are checking if null</typeparam>
        /// <typeparam name="TResult">The result we will bind as null if the source is null</typeparam>
        /// <param name="param">The param we are null checking</param>
        /// <param name="memberInit">The member init function to generate if sourece is not null</param>
        /// <returns>
        /// A conditional expression that is binds null or a memberinit
        /// </returns>
        public static ConditionalExpression NullModelCondition<TSource, TResult>(this Expression param, MemberInitExpression memberInit)
        {
            return Expression.Condition(
                Expression.Equal(param, Expression.Constant(null, typeof(TSource))),
                Expression.Constant(null, typeof(TResult)),
                memberInit
            );
        }

    }
}
