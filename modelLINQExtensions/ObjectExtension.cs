using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace modelLINQ
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Binds an object decleration to result, checking if the source is null and if it 
        /// is putting a null in stead of the member init expression
        /// </summary>
        /// <typeparam name="TBindingTo">The parent object of the binding where we are binding the result to</typeparam>
        /// <typeparam name="TSelectSource">The source of the object bind</typeparam>
        /// <typeparam name="TSelectResult">The result of the object bind</typeparam>
        /// <param name="param">The source parameter expression</param>
        /// <param name="bindingProperty">The name of the property on the parent we are binding to</param>
        /// <param name="bindingGenerator">The member generator of the new member init, if null check passes on the source</param>
        /// <exception cref="Exception">If parent lacks binding property</exception>
        /// <returns>
        /// An object bound memberassignment on either null or the new model
        /// </returns>
        public static MemberAssignment ObjectBind<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingProperty, Func<Expression, MemberAssignment[]> bindingGenerator)
        {
            if (typeof(TBindingTo).GetProperty(bindingProperty) == null)
            {
                throw new Exception("Parent object must have binding property");
            }

            return Expression.Bind(
                 typeof(TBindingTo).GetProperty(bindingProperty),
                 param.NullModelCondition<TSelectSource, TSelectResult>(Expression.MemberInit(Expression.New(typeof(TSelectResult)), bindingGenerator(param)))
             );
        }

        /// <summary>
        /// Binds an object decleration to result, checking if the source is null and if it 
        /// is putting a null in stead of the member init expression
        /// </summary>
        /// <typeparam name="TBindingTo">The parent object of the binding where we are binding the result to</typeparam>
        /// <typeparam name="TSelectSource">The source of the object bind</typeparam>
        /// <typeparam name="TSelectResult">The result of the object bind</typeparam>
        /// <param name="param">The source parameter expression</param>
        /// <param name="bindingProperty">The name of the property on the parent we are binding to</param>
        /// <param name="bindingGenerator">The member generator of the new member init, if null check passes on the source</param>
        /// <param name="propertyNames">The property names to go down from the existing param</param>
        /// <exception cref="Exception">If parent lacks binding property</exception>
        /// <returns>
        /// An object bound memberassignment on either null or the new model
        /// </returns>
        public static MemberAssignment ObjectBind<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingProperty, Func<Expression, MemberAssignment[]> bindingGenerator, params string[] propertyNames)
        {
            Expression propParam = param;

            foreach (string propName in propertyNames)
            {
                propParam = Expression.Property(propParam, propName);
            }

            return propParam.ObjectBind<TBindingTo, TSelectSource, TSelectResult>(bindingProperty, bindingGenerator);
        }
    }
}
