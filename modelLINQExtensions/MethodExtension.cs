using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace modelLINQ
{
    /// <summary>
    /// Method extensions handles the expression 
    /// calls to methods like any, where, select, ect
    /// </summary>
    public static class MethodExtension
    {

        /// <summary>
        /// Gets the select method info from Enumerable
        /// </summary>
        /// <returns>
        /// The select method info
        /// </returns>
        public static MethodInfo GetSelect()
        {
            foreach (MethodInfo m in typeof(Enumerable).GetMethods().Where(m => m.Name == "Select"))
            {
                foreach (ParameterInfo p in m.GetParameters().Where(p => p.Name.Equals("selector")))
                {
                    if (p.ParameterType.GetGenericArguments().Count() == 2)
                    {
                        return (MethodInfo)p.Member;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets IEnumerables where MethodInfo
        /// </summary>
        /// <returns>
        /// The where MethodInfo
        /// </returns>
        public static MethodInfo GetWhere()
        {
            foreach (MethodInfo m in typeof(Enumerable).GetMethods().Where(m => m.Name == "Where"))
            {
                foreach (ParameterInfo p in m.GetParameters().Where(p => p.Name.Equals("source")))
                {
                    return (MethodInfo)p.Member;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets any method information
        /// </summary>
        /// <returns>
        /// Anys IEnumerable method information
        /// </returns>
        public static MethodInfo GetAny()
        {
            foreach (MethodInfo m in typeof(Enumerable).GetMethods().Where(m => m.Name == "Any"))
            {
                if (m.GetParameters().Count() == 2)
                {
                    return m;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the order by method info off enumerable
        /// </summary>
        /// <param name="desc">If we want to descend</param>
        /// <returns>
        /// Order by Method Info
        /// </returns>
        public static MethodInfo GetOrderBy(bool desc)
        {
            string name = desc ? "OrderByDescending" : "OrderBy";
            foreach (MethodInfo m in typeof(Enumerable).GetMethods().Where(m => m.Name == name))
            {
                foreach (ParameterInfo p in m.GetParameters().Where(p => p.Name.Equals("source")))
                {
                    return (MethodInfo)p.Member;
                }
            }
            return null;
        }

        /// <summary>
        /// Generates a count method call to get the count
        /// of a list of items
        /// </summary>
        /// <typeparam name="TCountSource">The source of the count</typeparam>
        /// <param name="countParameter">The parameter source of the list</param>
        /// <returns>
        /// A method call expression of the count
        /// </returns>
        public static MethodCallExpression Count<TCountSource>(this Expression countParameter)
        {
            return Expression.Call(
                typeof(Enumerable),
                "Count",
                new Type[] { typeof(TCountSource) },
                countParameter
            );
        }

        /// <summary>
        /// Generates a where predicate in order to filter a list
        /// down by the function predicate, generally to be selected or
        /// to listed
        /// </summary>
        /// <typeparam name="TSource">The source of the list to filter</typeparam>
        /// <param name="bindingParam">The binding param of the list</param>
        /// <param name="predicate">The predicate generator function</param>
        /// <param name="paramName">The override of the source param name</param>
        /// <returns>
        /// A filtered list
        /// </returns>
        public static MethodCallExpression WherePredicate<TSource>(this Expression bindingParam, Func<Expression, Expression> predicate, string paramName = "whereSource")
        {
            ParameterExpression whereParam = Expression.Parameter(typeof(TSource), paramName);

            return Expression.Call(
             null,
             GetWhere().MakeGenericMethod(new Type[] {
                  typeof(TSource),
             }),
             new Expression[] {
                  bindingParam,
                  Expression.Lambda<Func<TSource, bool>>(
                      predicate(whereParam),
                      whereParam
                  )
             });
        }

        /// <summary>
        /// Generates a where predicate in order to filter a list
        /// down by the function predicate binding from the param property name
        /// generally to be selected or to listed
        /// </summary>
        /// <typeparam name="TSource">The source of the list</typeparam>
        /// <param name="param">The binding parent param</param>
        /// <param name="paramPropertyName">The property name to get the binding</param>
        /// <param name="predicate">The predicate generator</param>
        /// <param name="paramName">The param name</param>
        /// <returns>
        /// A filtered list
        /// </returns>
        public static MethodCallExpression WherePredictate<TSource>(this Expression param, string paramPropertyName, Func<Expression, Expression> predicate, string paramName = "whereSource")
        {
            return WherePredicate<TSource>(Expression.Property(param, paramPropertyName), predicate, paramName);
        }

        /// <summary>
        /// Selects a list of items into another list of results filtered by
        /// a where predicate
        /// </summary>
        /// <typeparam name="TSelectSource">The source of the list of items</typeparam>
        /// <typeparam name="TSelectResult">The result of the list of items</typeparam>
        /// <param name="bindingParam">The binding param of the predicate</param>
        /// <param name="predicate">The predicate to filter the results on</param>
        /// <param name="assigments">The assignments of the result</param>
        /// <param name="predicateSourceName">The predicate source name override</param>
        /// <param name="selectSourceName">The source name override</param>
        /// <param name="asList">If we want to select as a list</param>
        /// <returns>
        /// A filitered list of TSelectResult
        /// </returns>
        public static MethodCallExpression Select<TSelectSource, TSelectResult>(this Expression bindingParam, Func<Expression, Expression> predicate, Func<Expression, MemberAssignment[]> assigments, string predicateSourceName = "whereSource", string selectSourceName = "listSource", bool asList = false)
        {
            return WherePredicate<TSelectSource>(bindingParam, predicate, predicateSourceName)
                .Select<TSelectSource, TSelectResult>(assigments, selectSourceName, asList);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TSelectSource">The source of the list of items</typeparam>
        /// <typeparam name="TSelectResult">The result of the list of items</typeparam>
        /// <param name="bindingParam">The binding param of the predicate</param>
        /// <param name="predicate">The predicate to filter the results on</param>
        /// <param name="selectPropertyName">The name of the property being selected off of TSelectSource</param>
        /// <param name="predicateSourceName">The predicate source name override</param>
        /// <param name="selectSourceName">The source name override</param>
        /// <param name="asList">If we want to select as a list</param>
        /// <returns>
        /// A filitered list of TSelectResult
        /// </returns>
        public static MethodCallExpression SelectProperty<TSelectSource, TSelectResult>(this Expression bindingParam, Func<Expression, Expression> predicate, string selectPropertyName, string predicateSourceName = "whereSource", string selectSourceName = "listSource", bool asList = false)
        {
            return WherePredicate<TSelectSource>(bindingParam, predicate, predicateSourceName)
                .SelectProperty<TSelectSource, TSelectResult>(selectPropertyName, selectSourceName, asList);
        }

        /// <summary>
        /// Selects a list of items that are filtered by the given
        /// predicate and ordered by the ordering expression, and finally
        /// selecting the TResults by the bindings
        /// </summary>
        /// <typeparam name="TSelectSource">The source of the list</typeparam>
        /// <typeparam name="TOrderBy">The type of the ordering</typeparam>
        /// <typeparam name="TSelectResult">The result to select on</typeparam>
        /// <param name="bindingParam">The parameter to bind on</param>
        /// <param name="orderByProperty">The property that is being ordered on</param>
        /// <param name="predicate">The predicate generator</param>
        /// <param name="assigments">The select generator</param>
        /// <param name="predicateSourceName">The predicate source name override</param>
        /// <param name="selectSourceName">The select source name override</param>
        /// <param name="desc">If we are descending the ordering</param>
        /// <param name="asList">If we are selecting as a list</param>
        /// <returns>
        /// A list of filtered and ordered TResults
        /// </returns>
        public static MethodCallExpression Select<TSelectSource, TOrderBy, TSelectResult>(this Expression bindingParam, string orderByProperty, Func<Expression, Expression> predicate, Func<Expression, MemberAssignment[]> assigments, string predicateSourceName = "whereSource", string selectSourceName = "listSource", bool desc = false, bool asList = false)
        {
            return WherePredicate<TSelectSource>(bindingParam, predicate, predicateSourceName)
                .Select<TSelectSource, TOrderBy, TSelectResult>(orderByProperty, assigments, desc, selectSourceName, asList);
        }

        /// <summary>
        /// Selects a list of items into another list of results filtered by
        /// a where predicate
        /// </summary>
        /// <typeparam name="TSelectSource">The source of the list of items</typeparam>
        /// <typeparam name="TSelectResult">The result of the list of items</typeparam>
        /// <param name="predicate">The predicate to filter the results on</param>
        /// <param name="assigments">The assignments of the result</param>
        /// <param name="sourceName">The source name override</param>
        /// <param name="asList">If we want to select a list of items</param>
        /// <returns>
        /// A filitered list/item of TSelectResult
        /// </returns>
        public static MethodCallExpression Select<TSelectSource, TSelectResult>(this MethodCallExpression predicate, Func<Expression, MemberAssignment[]> assigments, string sourceName = "listSource", bool asList = false)
        {
            ParameterExpression sourceParam = Expression.Parameter(typeof(TSelectSource), sourceName);
            MemberInitExpression initMethod = Expression.MemberInit(Expression.New(typeof(TSelectResult)), assigments(sourceParam));
            LambdaExpression selectLambda = Expression.Lambda<Func<TSelectSource, TSelectResult>>(initMethod, sourceParam);

            MethodCallExpression selectCall = Expression.Call(
              null,
              GetSelect().MakeGenericMethod(new Type[] {
                  typeof(TSelectSource),
                  typeof(TSelectResult)
              }),
                  predicate,
                  selectLambda
              );

            return Expression.Call(
                typeof(Enumerable),
                asList ? "ToList" : "FirstOrDefault",
                new Type[] { typeof(TSelectResult) },
                selectCall
                );
        }

        /// <summary>
        /// Selects a sub item off the expression and utilizing the member assignments
        /// creates a list of objects
        /// </summary>
        /// <typeparam name="TSelectSource">The source of the list of items to select on</typeparam>
        /// <typeparam name="TOrderBy">The ordering by type</typeparam>
        /// <typeparam name="TSelectResult">The result model the list will contain</typeparam>
        /// <param name="predicate">The where predicate of the items</param>
        /// <param name="orderByProperty">The order by property</param>
        /// <param name="assigments">The member assignments to generate the model from the parm</param>
        /// <param name="sourceName">Lets you override the source name if necessary of the lambda select body</param>
        /// <param name="desc">If we are ordering by descending</param>
        /// <param name="asList">If we want to select as a list</param>
        /// <returns>
        /// A filtered orderd list/item of TResults MethodCallExpression
        /// </returns>
        public static MethodCallExpression Select<TSelectSource, TOrderBy, TSelectResult>(this MethodCallExpression predicate, string orderByProperty, Func<Expression, MemberAssignment[]> assigments, bool desc = false, string sourceName = "listSource", bool asList = false)
        {
            ParameterExpression sourceParam = Expression.Parameter(typeof(TSelectSource), sourceName);
            MemberInitExpression initMethod = Expression.MemberInit(Expression.New(typeof(TSelectResult)), assigments(sourceParam));
            LambdaExpression selectLambda = Expression.Lambda<Func<TSelectSource, TSelectResult>>(initMethod, sourceParam);

            MethodCallExpression orderByCall = Expression.Call(
              null,
              GetOrderBy(desc).MakeGenericMethod(new Type[] { 
                  typeof(TSelectSource), 
                  typeof(TOrderBy), 
              }),
              predicate,
              Expression.Lambda<Func<TSelectSource, TOrderBy>>(
                  Expression.Property(sourceParam, orderByProperty),
                  sourceParam
              )
              );

            MethodCallExpression selectCall = Expression.Call(
              null,
              GetSelect().MakeGenericMethod(new Type[] {
                  typeof(TSelectSource),
                  typeof(TSelectResult)
              }),
                  orderByCall,
                  selectLambda
              );

            return Expression.Call(
                typeof(Enumerable),
                asList ? "ToList" : "FirstOrDefault",
                new Type[] { typeof(TSelectResult) },
                selectCall
                );
        }

        /// <summary>
        /// Selects a sub item off the expression and utilizing the member assignments
        /// creates a list of objects
        /// </summary>
        /// <typeparam name="TSelectSource">The source of the list of items to select on</typeparam>
        /// <typeparam name="TSelectResult">The result model the list will contain</typeparam>
        /// <param name="param">The expression param that contains the property to sellect off</param>
        /// <param name="assigments">The member assignments to generate the model from the parm</param>
        /// <param name="sourceName">Lets you override the source name if necessary of the lambda select body</param>
        /// <param name="asList">If we want to select as a list</param>
        /// <returns>
        /// A list of TResults MethodCallExpression
        /// </returns>
        public static MethodCallExpression Select<TSelectSource, TSelectResult>(this Expression param, Func<Expression, MemberAssignment[]> assigments, string sourceName = "listSource", bool asList = false)
        {
            ParameterExpression sourceParam = Expression.Parameter(typeof(TSelectSource), sourceName);
            MemberInitExpression initMethod = Expression.MemberInit(Expression.New(typeof(TSelectResult)), assigments(sourceParam));
            LambdaExpression selectLambda = Expression.Lambda<Func<TSelectSource, TSelectResult>>(initMethod, sourceParam);

            MethodCallExpression selectCall = Expression.Call(
              null,
              GetSelect().MakeGenericMethod(new Type[] {
                  typeof(TSelectSource),
                  typeof(TSelectResult)
              }),
              new Expression[] {
                  param,
                  selectLambda
              });

            return Expression.Call(
                typeof(Enumerable),
                asList ? "ToList" : "FirstOrDefault",
                new Type[] { typeof(TSelectResult) },
                selectCall
                );
        }

        /// <summary>
        /// Selects a property from a lisst
        /// </summary>
        /// <typeparam name="TSelectSource">The source type of the select</typeparam>
        /// <typeparam name="TSelectResult">The result type of the select</typeparam>
        /// <param name="param">The select parameter</param>
        /// <param name="propertyName">The property on the TSource we are selecting</param>
        /// <param name="sourceName">The name of the select source</param>
        /// <param name="asList">If we need to generate a list or get a single item</param>
        /// <returns>
        /// The selects method call expression
        /// </returns>
        public static MethodCallExpression SelectProperty<TSelectSource, TSelectResult>(this Expression param, string propertyName, string sourceName = "listSource", bool asList = false)
        {
            ParameterExpression sourceParam = Expression.Parameter(typeof(TSelectSource), sourceName);
            Expression propertyParam = Expression.Property(sourceParam, propertyName);
            LambdaExpression selectLambda = Expression.Lambda<Func<TSelectSource, TSelectResult>>(propertyParam, sourceParam);

            MethodCallExpression selectCall = Expression.Call(
              null,
              GetSelect().MakeGenericMethod(new Type[] {
                  typeof(TSelectSource),
                  typeof(TSelectResult)
              }),
              new Expression[] {
                  param,
                  selectLambda
              });

            return Expression.Call(
                typeof(Enumerable),
                asList ? "ToList" : "FirstOrDefault",
                new Type[] { typeof(TSelectResult) },
                selectCall
                );
        }

        /// <summary>
        /// Selects a sub item off the expression and utilizing the member assignments
        /// creates a list of objects
        /// </summary>
        /// <typeparam name="TSelectSource">The source of the list of items to select on</typeparam>
        /// <typeparam name="TOrderBy">The ordering by type</typeparam>
        /// <typeparam name="TSelectResult">The result model the list will contain</typeparam>
        /// <param name="param">The expression param that contains the property to sellect off</param>
        /// <param name="orderByProperty">The order by expression</param>
        /// <param name="assigments">The member assignments to generate the model from the parm</param>
        /// <param name="sourceName">Lets you override the source name if necessary of the lambda select body</param>
        /// <param name="desc">If we are ordering by descending</param>
        /// <param name="asList">If we want to select as a list</param>
        /// <returns>
        /// A orderd list of TResults MethodCallExpression
        /// </returns>
        public static MethodCallExpression Select<TSelectSource, TOrderBy, TSelectResult>(this Expression param, string orderByProperty, Func<Expression, MemberAssignment[]> assigments, string sourceName = "listSource", bool desc = false, bool asList = false)
        {
            ParameterExpression sourceParam = Expression.Parameter(typeof(TSelectSource), sourceName);
            MemberInitExpression initMethod = Expression.MemberInit(Expression.New(typeof(TSelectResult)), assigments(sourceParam));
            LambdaExpression selectLambda = Expression.Lambda<Func<TSelectSource, TSelectResult>>(initMethod, sourceParam);

            MethodCallExpression orderByCall = Expression.Call(
              null,
              GetOrderBy(desc).MakeGenericMethod(new Type[] { 
                  typeof(TSelectSource), 
                  typeof(TOrderBy), 
              }),
              new Expression[]
              {
                  param,
                  Expression.Lambda<Func<TSelectSource, TOrderBy>>(
                      Expression.Property(sourceParam, orderByProperty),
                      sourceParam
                  )
              }
              );

            MethodCallExpression selectCall = Expression.Call(
              null,
              GetSelect().MakeGenericMethod(new Type[] {
                  typeof(TSelectSource),
                  typeof(TSelectResult)
              }),
              orderByCall,
              selectLambda
              );

            return Expression.Call(
                typeof(Enumerable),
                asList ? "ToList" : "FirstOrDefault",
                new Type[] { typeof(TSelectResult) },
                selectCall
                );
        }

        /// <summary>
        /// Any method call expression generator
        /// </summary>
        /// <typeparam name="TAnySource">The any param source</typeparam>
        /// <param name="param">The parameter generating the any</param>
        /// <param name="anyPredicateExpression">The lambda function body</param>
        /// <returns>
        /// A any method call expression
        /// </returns>
        public static MethodCallExpression Any<TAnySource>(this Expression param, Func<Expression, Expression> anyPredicateExpression)
        {
            ParameterExpression anyParam = Expression.Parameter(typeof(TAnySource), "anyParam");

            return Expression.Call(
                null,
                GetAny().MakeGenericMethod(new Type[]{
                    typeof(TAnySource),
                }),
                new Expression[]
                {
                    param,
                    Expression.Lambda<Func<TAnySource, bool>>(
                        anyPredicateExpression(anyParam),
                        anyParam
                    )
                });
        }

    }
}
