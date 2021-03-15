using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace modelLINQ
{
    public static class BindingExtension
    {
        /// <summary>
        /// Gets the direct mapping assignments from one source param
        /// to a TResult, ignoring properties that don't exist on both
        /// </summary>
        /// <typeparam name="TResult">The result of the mapping</typeparam>
        /// <param name="param">The source param of the mapping</param>
        /// <returns>
        /// An assignment array of all the properties
        /// </returns>
        public static MemberAssignment[] DirectBind<TResult>(this Expression param)
        {
            // Do list for easy inserts
            List<MemberAssignment> bindingGenerator = new List<MemberAssignment>();
            Type sourceType = param.Type;
            Type resultType = typeof(TResult);
            MethodInfo directBindMethod = typeof(BindingExtension)
                .GetMethods()
                .Where(m => m.Name == "DirectBind" && m.GetParameters().Count() == 2)
                .FirstOrDefault()
                .MakeGenericMethod(resultType);
            // Loop the properties of the source and create the binding generator
            foreach(PropertyInfo property in sourceType.GetProperties())
            {
                // Check if the result type has the property
                if (resultType.GetProperties().Any(prop => prop.Name.Equals(property.Name) && prop.PropertyType.Equals(property.PropertyType)))
                {
                    // We have to make a generic method of the direct bind
                    MemberAssignment propBind = (MemberAssignment)directBindMethod.Invoke(null, new object[] { param, property.Name });
                    bindingGenerator.Add(propBind); 
                }
            }
            // Return the bindings
            return bindingGenerator.ToArray();
        }

        /// <summary>
        /// Directly bind the same property from the source to the result
        /// </summary>
        /// <typeparam name="TResult">The object we are binding the property to</typeparam>
        /// <param name="param">The source parameter expression</param>
        /// <param name="propName">The name of the property we are binding</param>
        /// <returns>
        /// A member assignment of the direct binding
        /// </returns>
        public static MemberAssignment DirectBind<TResult>(this Expression param, string propName)
        {
            return Expression.Bind(typeof(TResult).GetProperty(propName), Expression.Property(param, propName));
        }

        /// <summary>
        /// Binds to the property as a terinary statement with null
        /// backing if it is null
        /// </summary>
        /// <typeparam name="TBindTo">The type we are binding the statement to</typeparam>
        /// <typeparam name="TProperty">The type of the property we are checking</typeparam>
        /// <param name="param">The param of the property we are creating terinary for</param>
        /// <param name="propName">The property name of the type to do the check against</param>
        /// <param name="bindToPropertyName">The property name we are binding to</param>
        /// <returns>
        /// The ternirary binding with the item or null
        /// </returns>
        public static MemberAssignment PropertyHasValue<TBindTo, TProperty>(this Expression param, string propName, string bindToPropertyName)
        {
            return Expression.Bind(typeof(TBindTo).GetProperty(bindToPropertyName), Expression.Condition(
                Expression.Equal(Expression.Property(param, propName), Expression.Constant(null, typeof(TProperty))),
                Expression.Constant(true),
                Expression.Constant(false)
            ));
        }

        /// <summary>
        /// Direct bind on sublevel properties as many names that are passed through
        /// </summary>
        /// <typeparam name="TSelectResult">The result we are binding to</typeparam>
        /// <param name="param">The top level param we will get the sub property from</param>
        /// <param name="bindPropname">The name of the property to bind the param on</param>
        /// <param name="propNames">The property names we will expand</param>
        /// <returns>
        /// A binding of the sub param on the bind prop name
        /// </returns>
        public static MemberAssignment DirectBind<TSelectResult>(this Expression param, string bindPropname, params string[] propNames)
        {
            Expression prop = param;
            foreach (string name in propNames)
            {
                prop = Expression.Property(prop, name);
            }

            return Expression.Bind(typeof(TSelectResult).GetProperty(bindPropname), prop);
        }

            
        /// <summary>
        /// Bind a has any function on a parameter
        /// </summary>
        /// <typeparam name="TSelectResult">The selected result type</typeparam>
        /// <typeparam name="TAnySource">The any type check</typeparam>
        /// <param name="param">The source parameter</param>
        /// <param name="bindPropname">The selected results type property</param>
        /// <param name="anyPredicate">The predicate function of the any clause</param>
        /// <param name="propNames">The prop names param to drill down to correct property</param>
        /// <exception cref="Exception">Binding type is not boolean</exception>
        /// <returns>
        /// A has any memberassignment
        /// </returns>
        public static MemberAssignment BindHasAny<TSelectResult, TAnySource>(this Expression param, string bindPropname, Func<Expression,Expression> anyPredicate, params string[] propNames)
        {
            Expression prop = param;
            foreach (string name in propNames)
            {
                prop = Expression.Property(prop, name);
            }

            PropertyInfo bindingProperty = typeof(TSelectResult).GetProperty(bindPropname);

            if (bindingProperty.PropertyType != typeof(bool))
            {
                throw new Exception("Binding on has any must be a boolean");
            }

            return Expression.Bind(bindingProperty, prop.Any<TAnySource>(anyPredicate));
        }
    }
}
