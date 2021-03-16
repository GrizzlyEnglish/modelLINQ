using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace modelLINQ
{
    public static class ListExtension
    {
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
        /// Binds a property to a filtered list of items or item
        /// </summary>
        /// <typeparam name="TBindingTo">The type of the binding</typeparam>
        /// <typeparam name="TSelectSource">The type of the select for getting the property</typeparam>
        /// <typeparam name="TSelectResult">The result of the select</typeparam>
        /// <param name="param">The param of the binding</param>
        /// <param name="bindingPropertyName">The name of the property to bind to</param>
        /// <param name="predicateGenerator">The filter predicate generation</param>
        /// <param name="propertyToBind">The property name for getting the binding</param>
        /// <param name="asList">If binding a list or a single item</param>
        /// <returns>
        /// The memberassignment of the filtered property
        /// </returns>
        public static MemberAssignment BindFilteredPropertyItem<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, Func<Expression, Expression> predicateGenerator, string propertyToBind, bool asList = false)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param
                        .WherePredictate<TSelectSource>(predicateGenerator)
                        .SelectProperty<TSelectSource, TSelectResult>(propertyToBind, asList: asList)
                    );
        }

        /// <summary>
        /// Bind on selected property of a given list item as a single item
        /// </summary>
        /// <typeparam name="TBindingTo">The type we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source we are binding to</typeparam>
        /// <typeparam name="TSelectResult">The result of select type</typeparam>
        /// <param name="param">The parameter to generate the binding on</param>
        /// <param name="bindingPropertyName">The property name on the binding model</param>
        /// <param name="propertyToBind">The name of the property to selet</param>
        /// <returns>
        /// An expression tree of the select binding
        /// </returns>
        public static MemberAssignment BindSelectedPropertyItem<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, string propertyToBind)
        {
            return param
                .BindSelectedProperty<TBindingTo, TSelectSource, TSelectResult>(bindingPropertyName, propertyToBind, false);
        }

        /// <summary>
        /// Bind on selected property of a given list item as a single item
        /// </summary>
        /// <typeparam name="TBindingTo">The type we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source we are binding to</typeparam>
        /// <typeparam name="TSelectResult">The result of select type</typeparam>
        /// <param name="param">The parameter to generate the binding on</param>
        /// <param name="bindingPropertyName">The property name on the binding model</param>
        /// <param name="selectOnPropertyName">Selects the property on the param before building</param>
        /// <param name="propertyToBind">The name of the property to selet</param>
        /// <returns>
        /// An expression tree of the select binding
        /// </returns>
        public static MemberAssignment BindSelectedPropertyItem<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, string selectOnPropertyName, string propertyToBind)
        {
            return Expression.Property(param, selectOnPropertyName)
                .BindSelectedProperty<TBindingTo, TSelectSource, TSelectResult>(bindingPropertyName, propertyToBind, false);
        }

        /// <summary>
        /// Bind on selected property of a given list item as a list
        /// </summary>
        /// <typeparam name="TBindingTo">The type we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source we are binding to</typeparam>
        /// <typeparam name="TSelectResult">The result of select type</typeparam>
        /// <param name="param">The parameter to generate the binding on</param>
        /// <param name="bindingPropertyName">The property name on the binding model</param>
        /// <param name="propertyToBind">The name of the property to selet</param>
        /// <returns>
        /// An expression tree of the select binding
        /// </returns>
        public static MemberAssignment BindSelectedPropertyList<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, string propertyToBind)
        {
            return param
                .BindSelectedProperty<TBindingTo, TSelectSource, TSelectResult>(bindingPropertyName, propertyToBind, true);
        }

        /// <summary>
        /// Bind on selected property of a given list item as a list
        /// </summary>
        /// <typeparam name="TBindingTo">The type we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source we are binding to</typeparam>
        /// <typeparam name="TSelectResult">The result of select type</typeparam>
        /// <param name="param">The parameter to generate the binding on</param>
        /// <param name="bindingPropertyName">The property name on the binding model</param>
        /// <param name="selectOnPropertyName">The property name to get on the param before building</param>
        /// <param name="propertyToBind">The name of the property to selet</param>
        /// <returns>
        /// An expression tree of the select binding
        /// </returns>
        public static MemberAssignment BindSelectedPropertyList<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, string selectOnPropertyName ,string propertyToBind)
        {
            return Expression.Property(param, selectOnPropertyName)
                .BindSelectedProperty<TBindingTo, TSelectSource, TSelectResult>(bindingPropertyName, propertyToBind, true);
        }

        /// <summary>
        /// Bind on selected property of a given list item as a list or a single item
        /// </summary>
        /// <typeparam name="TBindingTo">The type we are binding to</typeparam>
        /// <typeparam name="TSelectSource">The source we are binding to</typeparam>
        /// <typeparam name="TSelectResult">The result of select type</typeparam>
        /// <param name="param">The parameter to generate the binding on</param>
        /// <param name="bindingPropertyName">The property name on the binding model</param>
        /// <param name="propertyToBind">The name of the property to selet</param>
        /// <returns>
        /// An expression tree of the select binding
        /// </returns>
        public static MemberAssignment BindSelectedProperty<TBindingTo, TSelectSource, TSelectResult>(this Expression param, string bindingPropertyName, string propertyToBind, bool asList)
        {
            return Expression.Bind(
                    typeof(TBindingTo).GetProperty(bindingPropertyName),
                    param.SelectProperty<TSelectSource, TSelectResult>(propertyToBind, asList: asList)
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
