using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace modelLINQ
{
    public static class BindingExtension
    {

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
        /// Binds a selected list to the binding property name on the TBindingTo from
        /// the TSelectSource as a TSelectResult
        /// </summary>
        /// <typeparam name="TBindingTo">The parent object we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the binding result</typeparam>
        /// <typeparam name="TSelectResult">The result object of the selected</typeparam>
        /// <param name="param">The param of the tparent to get the property of</param>
        /// <param name="bindingPropertyName">The name of the binding property</param>
        /// <param name="bindingGenerator">The assigment bindings</param>
        /// <returns>
        /// A memeber assigment of selecting a list of tresult
        /// </returns>
        public static MemberAssignment BindSelectedList<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, Func<Expression, MemberAssignment[]> bindingGenerator)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param.Select<TSelectSource, TSelectResult>(bindingGenerator, asList: true)
                    );
        }

        /// <summary>
        /// Binds a selected list to the binding property name on the TBindingTo from
        /// the TSelectSource as a TSelectResult
        /// </summary>
        /// <typeparam name="TBindingTo">The parent object we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the binding result</typeparam>
        /// <typeparam name="TSelectResult">The result object of the selected</typeparam>
        /// <param name="param">The param of the tparent to get the property of</param>
        /// <param name="bindingPropertyName">The name of the binding property</param>
        /// <param name="paramPropertyName">The property of the param to select on</param>
        /// <param name="bindingGenerator">The assigment bindings</param>
        /// <returns>
        /// A memeber assigment of selecting a list of tresult
        /// </returns>
        public static MemberAssignment BindSelectedList<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, string paramPropertyName, Func<Expression, MemberAssignment[]> bindingGenerator)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    Expression.Property(param, paramPropertyName).Select<TSelectSource, TSelectResult>(bindingGenerator, asList: true)
                    );
        }

        /// <summary>
        /// Selects a list with a predicate to filter on
        /// </summary>
        /// <typeparam name="TBindingTo">The parent model we are selecting on</typeparam>
        /// <typeparam name="TSelectSource">The soruce of the select</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The param of the source</param>
        /// <param name="bindingPropertyName">The property name of the parent to bind on</param>
        /// <param name="predicateGenerator">The predicate generator</param>
        /// <param name="bindingGenerator">The results binding generator</param>
        /// <returns>
        /// A filitered list of TResults
        /// </returns>
        public static MemberAssignment BindFilteredList<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, Func<Expression, Expression> predicateGenerator, Func<Expression, MemberAssignment[]> bindingGenerator)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param.Select<TSelectSource, TSelectResult>(predicateGenerator, bindingGenerator, asList: true)
                    );
        }

        /// <summary>
        /// Selects a list with a predicate to filter on
        /// </summary>
        /// <typeparam name="TBindingTo">The parent model we are selecting on</typeparam>
        /// <typeparam name="TSelectSource">The soruce of the select</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The param of the source</param>
        /// <param name="bindingPropertyName">The property name of the parent to bind on</param>
        /// <param name="paramPropertyName">The property name of the param that is being filtered</param>
        /// <param name="predicateGenerator">The predicate generator</param>
        /// <param name="bindingGenerator">The results binding generator</param>
        /// <returns>
        /// A filitered list of TResults
        /// </returns>
        public static MemberAssignment BindFilteredList<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, string paramPropertyName, Func<Expression, Expression> predicateGenerator, Func<Expression, MemberAssignment[]> bindingGenerator)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    Expression.Property(param, paramPropertyName).Select<TSelectSource, TSelectResult>(predicateGenerator, bindingGenerator, asList: true)
                    );
        }

        /// <summary>
        /// Selects a item from a list with a predicate to filter on
        /// </summary>
        /// <typeparam name="TBindingTo">The parent model we are selecting on</typeparam>
        /// <typeparam name="TSelectSource">The soruce of the select</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The param of the source</param>
        /// <param name="bindingPropertyName">The property name of the parent to bind on</param>
        /// <param name="predicateGenerator">The predicate generator</param>
        /// <param name="bindingGenerator">The results binding generator</param>
        /// <returns>
        /// A filitered item of TSelectResult
        /// </returns>
        public static MemberAssignment BindFilteredItem<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, Func<Expression, Expression> predicateGenerator, Func<Expression, MemberAssignment[]> bindingGenerator)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param.Select<TSelectSource, TSelectResult>(predicateGenerator, bindingGenerator, asList: false)
                    );
        }


        /// <summary>
        /// Selects a item from a list with a predicate to filter on
        /// </summary>
        /// <typeparam name="TBindingTo">The parent model we are selecting on</typeparam>
        /// <typeparam name="TSelectSource">The soruce of the select</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The param of the source</param>
        /// <param name="bindingPropertyName">The property name of the parent to bind on</param>
        /// <param name="paramPropertyName">The property name of the source param to filter on</param>
        /// <param name="predicateGenerator">The predicate generator</param>
        /// <param name="bindingGenerator">The results binding generator</param>
        /// <returns>
        /// A filitered item of TSelectResult
        /// </returns>
        public static MemberAssignment BindFilteredItem<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, string paramPropertyName, Func<Expression, Expression> predicateGenerator, Func<Expression, MemberAssignment[]> bindingGenerator)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    Expression.Property(param, paramPropertyName).Select<TSelectSource, TSelectResult>(predicateGenerator, bindingGenerator, asList: false)
                    );
        }

        /// <summary>
        /// Generates an item from a ordered list grabing the first
        /// item in the newly ordered list
        /// </summary>
        /// <typeparam name="TBindingTo">The parent we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The type we are ordering on</typeparam>
        /// <typeparam name="TSelectResult"></typeparam>
        /// <param name="param">The source param we are filtering the list on</param>
        /// <param name="bindingPropertyName">The binding property of the source</param>
        /// <param name="orderByProperty">The property on TSelectSource we are ordering on</param>
        /// <param name="predicateGenerator">The filtering generator function</param>
        /// <param name="bindingGenerator">The assigment generator</param>
        /// <param name="desc">If we are descending the ordering</param>
        /// <returns>
        /// A item of TSelectResult from a list filtered and ordered
        /// </returns>
        public static MemberAssignment BindOrderedFilteredItem<TBindingTo, TSelectSource, TOrderBy, TSelectResult>(this Expression param, string bindingPropertyName, string orderByProperty, Func<Expression, Expression> predicateGenerator, Func<Expression, MemberAssignment[]> bindingGenerator, bool desc = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param.Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, predicateGenerator, bindingGenerator, asList: false, desc: desc)
                    );
        }

        /// <summary>
        /// Binds a single item from an ordered list
        /// </summary>
        /// <typeparam name="TBindingTo">The parent we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The order by type</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The source parametere</param>
        /// <param name="bindingPropertyName">The binding property name on the source</param>
        /// <param name="orderByProperty">The order by property name</param>
        /// <param name="bindingGenerator">The select bindings generator</param>
        /// <param name="desc">If we want to order by descending</param>
        /// <returns>
        /// A Binding of a single item to the property from an ordered list
        /// </returns>
        public static MemberAssignment BindOrderedItem<TBindingTo, TSelectSource, TOrderBy, TSelectResult>(this Expression param, string bindingPropertyName, string orderByProperty, Func<Expression, MemberAssignment[]> bindingGenerator, bool desc = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param.Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, bindingGenerator, asList: false, desc: desc)
                    );
        }

        /// <summary>
        /// Binds a single item from an ordered list
        /// </summary>
        /// <typeparam name="TBindingTo">The parent we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The order by type</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The source parametere</param>
        /// <param name="bindingPropertyName">The binding property name on the source</param>
        /// <param name="paramPropertyName">The property name of the list on the source</param>
        /// <param name="orderByProperty">The order by property name</param>
        /// <param name="bindingGenerator">The select bindings generator</param>
        /// <param name="desc">If we want to order by descending</param>
        /// <returns>
        /// A Binding of a single item to the property from an ordered list
        /// </returns>
        public static MemberAssignment BindOrderedItem<TBindingTo, TSelectSource, TOrderBy, TSelectResult>(this Expression param, string bindingPropertyName, string paramPropertyName, string orderByProperty, Func<Expression, MemberAssignment[]> bindingGenerator, bool desc = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    Expression.Property(param, paramPropertyName).Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, bindingGenerator, asList: false, desc: desc)
                    );
        }

        /// <summary>
        /// Generates an item from a ordered list grabing the first
        /// item in the newly ordered list
        /// </summary>
        /// <typeparam name="TBindingTo">The parent we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The type we are ordering on</typeparam>
        /// <typeparam name="TSelectResult"></typeparam>
        /// <param name="param">The source param we are filtering the list on</param>
        /// <param name="bindingPropertyName">The binding property of the source</param>
        /// <param name="paramPropertyName">The name of the property on the source</param>
        /// <param name="orderByProperty">The property on TSelectSource we are ordering on</param>
        /// <param name="predicateGenerator">The filtering generator function</param>
        /// <param name="bindingGenerator">The assigment generator</param>
        /// <param name="desc">If we are descending the ordering</param>
        /// <returns>
        /// A item of TSelectResult from a list filtered and ordered
        /// </returns>
        public static MemberAssignment BindOrderedFilteredItem<TBindingTo, TSelectSource, TOrderBy, TSelectResult>(this Expression param, string bindingPropertyName, string paramPropertyName, string orderByProperty, Func<Expression, Expression> predicateGenerator, Func<Expression, MemberAssignment[]> bindingGenerator, bool desc = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    Expression.Property(param, paramPropertyName).Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, predicateGenerator, bindingGenerator, asList: false, desc: desc)
                    );
        }

        /// <summary>
        /// Generates an list from a list by ordering and selecting
        /// </summary>
        /// <typeparam name="TBindingTo">The parent we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The type we are ordering on</typeparam>
        /// <typeparam name="TSelectResult"></typeparam>
        /// <param name="param">The source param we are filtering the list on</param>
        /// <param name="bindingPropertyName">The binding property of the source</param>
        /// <param name="paramPropertyName">The name of the property of the list on the source</param>
        /// <param name="orderByProperty">The property we are ordering by on TSelectSource</param>
        /// <param name="predicateGenerator">The filtering generator function</param>
        /// <param name="bindingGenerator">The assigment generator</param>
        /// <param name="desc">If we are descending the ordering</param>
        /// <returns>
        /// An ordered and filtered list of TSelectResult
        /// </returns>
        public static MemberAssignment BindOrderedFilteredList<TBindingTo, TSelectSource, TOrderBy, TSelectResult>(this Expression param, string bindingPropertyName, string paramPropertyName, string orderByProperty, Func<Expression, Expression> predicateGenerator, Func<Expression, MemberAssignment[]> bindingGenerator, bool desc = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    Expression.Property(param, paramPropertyName).Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, predicateGenerator, bindingGenerator, asList: true, desc: desc)
                    );
        }

        /// <summary>
        /// Generates an list from a list by ordering and selecting
        /// </summary>
        /// <typeparam name="TBindingTo">The parent we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The type we are ordering on</typeparam>
        /// <typeparam name="TSelectResult"></typeparam>
        /// <param name="param">The source param we are filtering the list on</param>
        /// <param name="bindingPropertyName">The binding property of the source</param>
        /// <param name="orderByProperty">The property we are ordering by on TSelectSource</param>
        /// <param name="predicateGenerator">The filtering generator function</param>
        /// <param name="bindingGenerator">The assigment generator</param>
        /// <param name="desc">If we are descending the ordering</param>
        /// <returns>
        /// An ordered and filtered list of TSelectResult
        /// </returns>
        public static MemberAssignment BindOrderedFilteredList<TBindingTo, TSelectSource, TOrderBy, TSelectResult>(this Expression param, string bindingPropertyName, string orderByProperty, Func<Expression, Expression> predicateGenerator, Func<Expression, MemberAssignment[]> bindingGenerator, bool desc = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param.Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, predicateGenerator, bindingGenerator, asList: true, desc: desc)
                    );
        }

        /// <summary>
        /// Binds an ordered list to from a list
        /// </summary>
        /// <typeparam name="TBindingTo">The parent we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The order by type</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The source param</param>
        /// <param name="bindingPropertyName">The name of the property being bound to</param>
        /// <param name="orderByProperty">The name of the order by property</param>
        /// <param name="bindingGenerator">The bindings generator</param>
        /// <param name="desc">If the list is descending</param>
        /// <returns>
        /// A binding assigment of an ordered list
        /// </returns>
        public static MemberAssignment BindOrderedList<TBindingTo, TSelectSource, TOrderBy, TSelectResult>(this Expression param, string bindingPropertyName, string orderByProperty, Func<Expression, MemberAssignment[]> bindingGenerator, bool desc = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param.Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, bindingGenerator, asList: true, desc: desc)
                    );
        }

        /// <summary>
        /// Binds an ordered list to from a list
        /// </summary>
        /// <typeparam name="TBindingTo">The parent we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The order by type</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The source param</param>
        /// <param name="bindingPropertyName">The name of the property being bound to</param>
        /// <param name="paramPropertyName">The property name of the list on the source</param>
        /// <param name="orderByProperty">The name of the order by property</param>
        /// <param name="bindingGenerator">The bindings generator</param>
        /// <param name="desc">If the list is descending</param>
        /// <returns>
        /// A binding assigment of an ordered list
        /// </returns>
        public static MemberAssignment BindOrderedList<TBindingTo, TSelectSource, TOrderBy, TSelectResult>(this Expression param, string bindingPropertyName, string paramPropertyName, string orderByProperty, Func<Expression, MemberAssignment[]> bindingGenerator, bool desc = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    Expression.Property(param, paramPropertyName).Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, bindingGenerator, asList: true, desc: desc)
                    );
        }
    }
}
