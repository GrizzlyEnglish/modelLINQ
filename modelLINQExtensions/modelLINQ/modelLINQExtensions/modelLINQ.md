<a name='assembly'></a>
# modelLINQ

## Contents

- [BindingExtension](#T-modelLINQ-BindingExtension 'modelLINQ.BindingExtension')
  - [BindHasAny\`\`2(param,bindPropname,anyPredicate,propNames)](#M-modelLINQ-BindingExtension-BindHasAny``2-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-String[]- 'modelLINQ.BindingExtension.BindHasAny``2(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.String[])')
  - [DirectBind\`\`1(param)](#M-modelLINQ-BindingExtension-DirectBind``1-System-Linq-Expressions-Expression- 'modelLINQ.BindingExtension.DirectBind``1(System.Linq.Expressions.Expression)')
  - [DirectBind\`\`1(param,propName)](#M-modelLINQ-BindingExtension-DirectBind``1-System-Linq-Expressions-Expression,System-String- 'modelLINQ.BindingExtension.DirectBind``1(System.Linq.Expressions.Expression,System.String)')
  - [DirectBind\`\`1(param,bindPropname,propNames)](#M-modelLINQ-BindingExtension-DirectBind``1-System-Linq-Expressions-Expression,System-String,System-String[]- 'modelLINQ.BindingExtension.DirectBind``1(System.Linq.Expressions.Expression,System.String,System.String[])')
  - [PropertyHasValue\`\`2(param,propName,bindToPropertyName)](#M-modelLINQ-BindingExtension-PropertyHasValue``2-System-Linq-Expressions-Expression,System-String,System-String- 'modelLINQ.BindingExtension.PropertyHasValue``2(System.Linq.Expressions.Expression,System.String,System.String)')
- [ListExtension](#T-modelLINQ-ListExtension 'modelLINQ.ListExtension')
  - [BindFilteredItem\`\`3(param,bindingPropertyName,predicateGenerator,bindingGenerator)](#M-modelLINQ-ListExtension-BindFilteredItem``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}- 'modelLINQ.ListExtension.BindFilteredItem``3(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]})')
  - [BindFilteredItem\`\`3(param,bindingPropertyName,paramPropertyName,predicateGenerator,bindingGenerator)](#M-modelLINQ-ListExtension-BindFilteredItem``3-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}- 'modelLINQ.ListExtension.BindFilteredItem``3(System.Linq.Expressions.Expression,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]})')
  - [BindFilteredList\`\`3(param,bindingPropertyName,predicateGenerator,bindingGenerator)](#M-modelLINQ-ListExtension-BindFilteredList``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}- 'modelLINQ.ListExtension.BindFilteredList``3(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]})')
  - [BindFilteredList\`\`3(param,bindingPropertyName,paramPropertyName,predicateGenerator,bindingGenerator)](#M-modelLINQ-ListExtension-BindFilteredList``3-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}- 'modelLINQ.ListExtension.BindFilteredList``3(System.Linq.Expressions.Expression,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]})')
  - [BindFilteredPropertyItem\`\`3(param,bindingPropertyName,predicateGenerator,propertyToBind,asList)](#M-modelLINQ-ListExtension-BindFilteredPropertyItem``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-String,System-Boolean- 'modelLINQ.ListExtension.BindFilteredPropertyItem``3(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.String,System.Boolean)')
  - [BindOrderedFilteredItem\`\`4(param,bindingPropertyName,orderByProperty,predicateGenerator,bindingGenerator,desc)](#M-modelLINQ-ListExtension-BindOrderedFilteredItem``4-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean- 'modelLINQ.ListExtension.BindOrderedFilteredItem``4(System.Linq.Expressions.Expression,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean)')
  - [BindOrderedFilteredItem\`\`4(param,bindingPropertyName,paramPropertyName,orderByProperty,predicateGenerator,bindingGenerator,desc)](#M-modelLINQ-ListExtension-BindOrderedFilteredItem``4-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean- 'modelLINQ.ListExtension.BindOrderedFilteredItem``4(System.Linq.Expressions.Expression,System.String,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean)')
  - [BindOrderedFilteredList\`\`4(param,bindingPropertyName,paramPropertyName,orderByProperty,predicateGenerator,bindingGenerator,desc)](#M-modelLINQ-ListExtension-BindOrderedFilteredList``4-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean- 'modelLINQ.ListExtension.BindOrderedFilteredList``4(System.Linq.Expressions.Expression,System.String,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean)')
  - [BindOrderedFilteredList\`\`4(param,bindingPropertyName,orderByProperty,predicateGenerator,bindingGenerator,desc)](#M-modelLINQ-ListExtension-BindOrderedFilteredList``4-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean- 'modelLINQ.ListExtension.BindOrderedFilteredList``4(System.Linq.Expressions.Expression,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean)')
  - [BindOrderedItem\`\`4(param,bindingPropertyName,orderByProperty,bindingGenerator,desc)](#M-modelLINQ-ListExtension-BindOrderedItem``4-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean- 'modelLINQ.ListExtension.BindOrderedItem``4(System.Linq.Expressions.Expression,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean)')
  - [BindOrderedItem\`\`4(param,bindingPropertyName,paramPropertyName,orderByProperty,bindingGenerator,desc)](#M-modelLINQ-ListExtension-BindOrderedItem``4-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean- 'modelLINQ.ListExtension.BindOrderedItem``4(System.Linq.Expressions.Expression,System.String,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean)')
  - [BindOrderedList\`\`4(param,bindingPropertyName,orderByProperty,bindingGenerator,desc)](#M-modelLINQ-ListExtension-BindOrderedList``4-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean- 'modelLINQ.ListExtension.BindOrderedList``4(System.Linq.Expressions.Expression,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean)')
  - [BindOrderedList\`\`4(param,bindingPropertyName,paramPropertyName,orderByProperty,bindingGenerator,desc)](#M-modelLINQ-ListExtension-BindOrderedList``4-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean- 'modelLINQ.ListExtension.BindOrderedList``4(System.Linq.Expressions.Expression,System.String,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean)')
  - [BindSelectedList\`\`3(param,bindingPropertyName,bindingGenerator)](#M-modelLINQ-ListExtension-BindSelectedList``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}- 'modelLINQ.ListExtension.BindSelectedList``3(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]})')
  - [BindSelectedList\`\`3(param,bindingPropertyName,paramPropertyName,bindingGenerator)](#M-modelLINQ-ListExtension-BindSelectedList``3-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}- 'modelLINQ.ListExtension.BindSelectedList``3(System.Linq.Expressions.Expression,System.String,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]})')
  - [BindSelectedPropertyItem\`\`3(param,bindingPropertyName,propertyToBind)](#M-modelLINQ-ListExtension-BindSelectedPropertyItem``3-System-Linq-Expressions-Expression,System-String,System-String- 'modelLINQ.ListExtension.BindSelectedPropertyItem``3(System.Linq.Expressions.Expression,System.String,System.String)')
  - [BindSelectedPropertyItem\`\`3(param,bindingPropertyName,selectOnPropertyName,propertyToBind)](#M-modelLINQ-ListExtension-BindSelectedPropertyItem``3-System-Linq-Expressions-Expression,System-String,System-String,System-String- 'modelLINQ.ListExtension.BindSelectedPropertyItem``3(System.Linq.Expressions.Expression,System.String,System.String,System.String)')
  - [BindSelectedPropertyList\`\`3(param,bindingPropertyName,propertyToBind)](#M-modelLINQ-ListExtension-BindSelectedPropertyList``3-System-Linq-Expressions-Expression,System-String,System-String- 'modelLINQ.ListExtension.BindSelectedPropertyList``3(System.Linq.Expressions.Expression,System.String,System.String)')
  - [BindSelectedPropertyList\`\`3(param,bindingPropertyName,selectOnPropertyName,propertyToBind)](#M-modelLINQ-ListExtension-BindSelectedPropertyList``3-System-Linq-Expressions-Expression,System-String,System-String,System-String- 'modelLINQ.ListExtension.BindSelectedPropertyList``3(System.Linq.Expressions.Expression,System.String,System.String,System.String)')
  - [BindSelectedProperty\`\`3(param,bindingPropertyName,propertyToBind)](#M-modelLINQ-ListExtension-BindSelectedProperty``3-System-Linq-Expressions-Expression,System-String,System-String,System-Boolean- 'modelLINQ.ListExtension.BindSelectedProperty``3(System.Linq.Expressions.Expression,System.String,System.String,System.Boolean)')
- [MethodExtension](#T-modelLINQ-MethodExtension 'modelLINQ.MethodExtension')
  - [Any\`\`1(param,anyPredicateExpression)](#M-modelLINQ-MethodExtension-Any``1-System-Linq-Expressions-Expression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression}- 'modelLINQ.MethodExtension.Any``1(System.Linq.Expressions.Expression,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression})')
  - [GetAny()](#M-modelLINQ-MethodExtension-GetAny 'modelLINQ.MethodExtension.GetAny')
  - [GetOrderBy(desc)](#M-modelLINQ-MethodExtension-GetOrderBy-System-Boolean- 'modelLINQ.MethodExtension.GetOrderBy(System.Boolean)')
  - [GetSelect()](#M-modelLINQ-MethodExtension-GetSelect 'modelLINQ.MethodExtension.GetSelect')
  - [GetWhere()](#M-modelLINQ-MethodExtension-GetWhere 'modelLINQ.MethodExtension.GetWhere')
  - [SelectProperty\`\`2(param,propertyName,sourceName,asList)](#M-modelLINQ-MethodExtension-SelectProperty``2-System-Linq-Expressions-Expression,System-String,System-String,System-Boolean- 'modelLINQ.MethodExtension.SelectProperty``2(System.Linq.Expressions.Expression,System.String,System.String,System.Boolean)')
  - [Select\`\`2(bindingParam,predicate,assigments,predicateSourceName,selectSourceName,asList)](#M-modelLINQ-MethodExtension-Select``2-System-Linq-Expressions-Expression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-String,System-Boolean- 'modelLINQ.MethodExtension.Select``2(System.Linq.Expressions.Expression,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.String,System.String,System.Boolean)')
  - [Select\`\`2(predicate,assigments,sourceName,asList)](#M-modelLINQ-MethodExtension-Select``2-System-Linq-Expressions-MethodCallExpression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-Boolean- 'modelLINQ.MethodExtension.Select``2(System.Linq.Expressions.MethodCallExpression,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.String,System.Boolean)')
  - [Select\`\`2(param,assigments,sourceName,asList)](#M-modelLINQ-MethodExtension-Select``2-System-Linq-Expressions-Expression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-Boolean- 'modelLINQ.MethodExtension.Select``2(System.Linq.Expressions.Expression,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.String,System.Boolean)')
  - [Select\`\`3(bindingParam,orderByProperty,predicate,assigments,predicateSourceName,selectSourceName,desc,asList)](#M-modelLINQ-MethodExtension-Select``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-String,System-Boolean,System-Boolean- 'modelLINQ.MethodExtension.Select``3(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.String,System.String,System.Boolean,System.Boolean)')
  - [Select\`\`3(predicate,orderByProperty,assigments,sourceName,desc,asList)](#M-modelLINQ-MethodExtension-Select``3-System-Linq-Expressions-MethodCallExpression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean,System-String,System-Boolean- 'modelLINQ.MethodExtension.Select``3(System.Linq.Expressions.MethodCallExpression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.Boolean,System.String,System.Boolean)')
  - [Select\`\`3(param,orderBy,assigments,sourceName,desc,asList)](#M-modelLINQ-MethodExtension-Select``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-Boolean,System-Boolean- 'modelLINQ.MethodExtension.Select``3(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.String,System.Boolean,System.Boolean)')
  - [WherePredictate\`\`1(bindingParam,predicate,paramName)](#M-modelLINQ-MethodExtension-WherePredictate``1-System-Linq-Expressions-Expression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-String- 'modelLINQ.MethodExtension.WherePredictate``1(System.Linq.Expressions.Expression,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.String)')
  - [WherePredictate\`\`1(param,paramPropertyName,predicate,paramName)](#M-modelLINQ-MethodExtension-WherePredictate``1-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-String- 'modelLINQ.MethodExtension.WherePredictate``1(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression},System.String)')
- [ModelExtension](#T-modelLINQ-ModelExtension 'modelLINQ.ModelExtension')
  - [AsModel\`\`2()](#M-modelLINQ-ModelExtension-AsModel``2 'modelLINQ.ModelExtension.AsModel``2')
  - [GenerateModel\`\`2(sourceObject)](#M-modelLINQ-ModelExtension-GenerateModel``2-``0- 'modelLINQ.ModelExtension.GenerateModel``2(``0)')
  - [Model\`\`2(bindingGenerator,paramName)](#M-modelLINQ-ModelExtension-Model``2-System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberBinding[]},System-String- 'modelLINQ.ModelExtension.Model``2(System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberBinding[]},System.String)')
  - [NullModelCondition\`\`2(param,memberInit)](#M-modelLINQ-ModelExtension-NullModelCondition``2-System-Linq-Expressions-Expression,System-Linq-Expressions-MemberInitExpression- 'modelLINQ.ModelExtension.NullModelCondition``2(System.Linq.Expressions.Expression,System.Linq.Expressions.MemberInitExpression)')
- [ObjectExtension](#T-modelLINQ-ObjectExtension 'modelLINQ.ObjectExtension')
  - [ObjectBind\`\`3(param,bindingProperty,bindingGenerator)](#M-modelLINQ-ObjectExtension-ObjectBind``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}- 'modelLINQ.ObjectExtension.ObjectBind``3(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]})')
  - [ObjectBind\`\`3(param,bindingProperty,bindingGenerator,propertyNames)](#M-modelLINQ-ObjectExtension-ObjectBind``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String[]- 'modelLINQ.ObjectExtension.ObjectBind``3(System.Linq.Expressions.Expression,System.String,System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]},System.String[])')

<a name='T-modelLINQ-BindingExtension'></a>
## BindingExtension `type`

##### Namespace

modelLINQ

<a name='M-modelLINQ-BindingExtension-BindHasAny``2-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-String[]-'></a>
### BindHasAny\`\`2(param,bindPropname,anyPredicate,propNames) `method`

##### Summary

Bind a has any function on a parameter

##### Returns

A has any memberassignment

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source parameter |
| bindPropname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The selected results type property |
| anyPredicate | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate function of the any clause |
| propNames | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The prop names param to drill down to correct property |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectResult | The selected result type |
| TAnySource | The any type check |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | Binding type is not boolean |

<a name='M-modelLINQ-BindingExtension-DirectBind``1-System-Linq-Expressions-Expression-'></a>
### DirectBind\`\`1(param) `method`

##### Summary

Gets the direct mapping assignments from one source param
to a TResult, ignoring properties that don't exist on both

##### Returns

An assignment array of all the properties

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source param of the mapping |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The result of the mapping |

<a name='M-modelLINQ-BindingExtension-DirectBind``1-System-Linq-Expressions-Expression,System-String-'></a>
### DirectBind\`\`1(param,propName) `method`

##### Summary

Directly bind the same property from the source to the result

##### Returns

A member assignment of the direct binding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source parameter expression |
| propName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property we are binding |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The object we are binding the property to |

<a name='M-modelLINQ-BindingExtension-DirectBind``1-System-Linq-Expressions-Expression,System-String,System-String[]-'></a>
### DirectBind\`\`1(param,bindPropname,propNames) `method`

##### Summary

Direct bind on sublevel properties as many names that are passed through

##### Returns

A binding of the sub param on the bind prop name

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The top level param we will get the sub property from |
| bindPropname | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to bind the param on |
| propNames | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The property names we will expand |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectResult | The result we are binding to |

<a name='M-modelLINQ-BindingExtension-PropertyHasValue``2-System-Linq-Expressions-Expression,System-String,System-String-'></a>
### PropertyHasValue\`\`2(param,propName,bindToPropertyName) `method`

##### Summary

Binds to the property as a terinary statement with null
backing if it is null

##### Returns

The ternirary binding with the item or null

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param of the property we are creating terinary for |
| propName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the type to do the check against |
| bindToPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name we are binding to |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindTo | The type we are binding the statement to |
| TProperty | The type of the property we are checking |

<a name='T-modelLINQ-ListExtension'></a>
## ListExtension `type`

##### Namespace

modelLINQ

<a name='M-modelLINQ-ListExtension-BindFilteredItem``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}-'></a>
### BindFilteredItem\`\`3(param,bindingPropertyName,predicateGenerator,bindingGenerator) `method`

##### Summary

Selects a item from a list with a predicate to filter on

##### Returns

A filitered item of TSelectResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param of the source |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the parent to bind on |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate generator |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The results binding generator |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent model we are selecting on |
| TSelectSource | The soruce of the select |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindFilteredItem``3-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}-'></a>
### BindFilteredItem\`\`3(param,bindingPropertyName,paramPropertyName,predicateGenerator,bindingGenerator) `method`

##### Summary

Selects a item from a list with a predicate to filter on

##### Returns

A filitered item of TSelectResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param of the source |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the parent to bind on |
| paramPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the source param to filter on |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate generator |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The results binding generator |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent model we are selecting on |
| TSelectSource | The soruce of the select |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindFilteredList``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}-'></a>
### BindFilteredList\`\`3(param,bindingPropertyName,predicateGenerator,bindingGenerator) `method`

##### Summary

Selects a list with a predicate to filter on

##### Returns

A filitered list of TResults

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param of the source |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the parent to bind on |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate generator |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The results binding generator |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent model we are selecting on |
| TSelectSource | The soruce of the select |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindFilteredList``3-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}-'></a>
### BindFilteredList\`\`3(param,bindingPropertyName,paramPropertyName,predicateGenerator,bindingGenerator) `method`

##### Summary

Selects a list with a predicate to filter on

##### Returns

A filitered list of TResults

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param of the source |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the parent to bind on |
| paramPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the param that is being filtered |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate generator |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The results binding generator |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent model we are selecting on |
| TSelectSource | The soruce of the select |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindFilteredPropertyItem``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-String,System-Boolean-'></a>
### BindFilteredPropertyItem\`\`3(param,bindingPropertyName,predicateGenerator,propertyToBind,asList) `method`

##### Summary

Binds a property to a filtered list of items or item

##### Returns

The memberassignment of the filtered property

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param of the binding |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to bind to |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The filter predicate generation |
| propertyToBind | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name for getting the binding |
| asList | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If binding a list or a single item |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The type of the binding |
| TSelectSource | The type of the select for getting the property |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindOrderedFilteredItem``4-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean-'></a>
### BindOrderedFilteredItem\`\`4(param,bindingPropertyName,orderByProperty,predicateGenerator,bindingGenerator,desc) `method`

##### Summary

Generates an item from a ordered list grabing the first
item in the newly ordered list

##### Returns

A item of TSelectResult from a list filtered and ordered

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source param we are filtering the list on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The binding property of the source |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property on TSelectSource we are ordering on |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The filtering generator function |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The assigment generator |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we are descending the ordering |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent we are binding to |
| TSelectSource | The source of the list |
| TOrderBy | The type we are ordering on |
| TSelectResult |  |

<a name='M-modelLINQ-ListExtension-BindOrderedFilteredItem``4-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean-'></a>
### BindOrderedFilteredItem\`\`4(param,bindingPropertyName,paramPropertyName,orderByProperty,predicateGenerator,bindingGenerator,desc) `method`

##### Summary

Generates an item from a ordered list grabing the first
item in the newly ordered list

##### Returns

A item of TSelectResult from a list filtered and ordered

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source param we are filtering the list on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The binding property of the source |
| paramPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property on the source |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property on TSelectSource we are ordering on |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The filtering generator function |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The assigment generator |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we are descending the ordering |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent we are binding to |
| TSelectSource | The source of the list |
| TOrderBy | The type we are ordering on |
| TSelectResult |  |

<a name='M-modelLINQ-ListExtension-BindOrderedFilteredList``4-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean-'></a>
### BindOrderedFilteredList\`\`4(param,bindingPropertyName,paramPropertyName,orderByProperty,predicateGenerator,bindingGenerator,desc) `method`

##### Summary

Generates an list from a list by ordering and selecting

##### Returns

An ordered and filtered list of TSelectResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source param we are filtering the list on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The binding property of the source |
| paramPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property of the list on the source |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property we are ordering by on TSelectSource |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The filtering generator function |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The assigment generator |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we are descending the ordering |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent we are binding to |
| TSelectSource | The source of the list |
| TOrderBy | The type we are ordering on |
| TSelectResult |  |

<a name='M-modelLINQ-ListExtension-BindOrderedFilteredList``4-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean-'></a>
### BindOrderedFilteredList\`\`4(param,bindingPropertyName,orderByProperty,predicateGenerator,bindingGenerator,desc) `method`

##### Summary

Generates an list from a list by ordering and selecting

##### Returns

An ordered and filtered list of TSelectResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source param we are filtering the list on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The binding property of the source |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property we are ordering by on TSelectSource |
| predicateGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The filtering generator function |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The assigment generator |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we are descending the ordering |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent we are binding to |
| TSelectSource | The source of the list |
| TOrderBy | The type we are ordering on |
| TSelectResult |  |

<a name='M-modelLINQ-ListExtension-BindOrderedItem``4-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean-'></a>
### BindOrderedItem\`\`4(param,bindingPropertyName,orderByProperty,bindingGenerator,desc) `method`

##### Summary

Binds a single item from an ordered list

##### Returns

A Binding of a single item to the property from an ordered list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source parametere |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The binding property name on the source |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The order by property name |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The select bindings generator |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we want to order by descending |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent we are binding to |
| TSelectSource | The source of the list |
| TOrderBy | The order by type |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindOrderedItem``4-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean-'></a>
### BindOrderedItem\`\`4(param,bindingPropertyName,paramPropertyName,orderByProperty,bindingGenerator,desc) `method`

##### Summary

Binds a single item from an ordered list

##### Returns

A Binding of a single item to the property from an ordered list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source parametere |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The binding property name on the source |
| paramPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the list on the source |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The order by property name |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The select bindings generator |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we want to order by descending |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent we are binding to |
| TSelectSource | The source of the list |
| TOrderBy | The order by type |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindOrderedList``4-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean-'></a>
### BindOrderedList\`\`4(param,bindingPropertyName,orderByProperty,bindingGenerator,desc) `method`

##### Summary

Binds an ordered list to from a list

##### Returns

A binding assigment of an ordered list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source param |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property being bound to |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the order by property |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The bindings generator |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If the list is descending |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent we are binding to |
| TSelectSource | The source of the list |
| TOrderBy | The order by type |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindOrderedList``4-System-Linq-Expressions-Expression,System-String,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean-'></a>
### BindOrderedList\`\`4(param,bindingPropertyName,paramPropertyName,orderByProperty,bindingGenerator,desc) `method`

##### Summary

Binds an ordered list to from a list

##### Returns

A binding assigment of an ordered list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source param |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property being bound to |
| paramPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name of the list on the source |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the order by property |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The bindings generator |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If the list is descending |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent we are binding to |
| TSelectSource | The source of the list |
| TOrderBy | The order by type |
| TSelectResult | The result of the select |

<a name='M-modelLINQ-ListExtension-BindSelectedList``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}-'></a>
### BindSelectedList\`\`3(param,bindingPropertyName,bindingGenerator) `method`

##### Summary

Binds a selected list to the binding property name on the TBindingTo from
the TSelectSource as a TSelectResult

##### Returns

A memeber assigment of selecting a list of tresult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param of the tparent to get the property of |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the binding property |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The assigment bindings |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent object we are binding to |
| TSelectSource | The source of the binding result |
| TSelectResult | The result object of the selected |

<a name='M-modelLINQ-ListExtension-BindSelectedList``3-System-Linq-Expressions-Expression,System-String,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}-'></a>
### BindSelectedList\`\`3(param,bindingPropertyName,paramPropertyName,bindingGenerator) `method`

##### Summary

Binds a selected list to the binding property name on the TBindingTo from
the TSelectSource as a TSelectResult

##### Returns

A memeber assigment of selecting a list of tresult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param of the tparent to get the property of |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the binding property |
| paramPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property of the param to select on |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The assigment bindings |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent object we are binding to |
| TSelectSource | The source of the binding result |
| TSelectResult | The result object of the selected |

<a name='M-modelLINQ-ListExtension-BindSelectedPropertyItem``3-System-Linq-Expressions-Expression,System-String,System-String-'></a>
### BindSelectedPropertyItem\`\`3(param,bindingPropertyName,propertyToBind) `method`

##### Summary

Bind on selected property of a given list item as a single item

##### Returns

An expression tree of the select binding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The parameter to generate the binding on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name on the binding model |
| propertyToBind | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to selet |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The type we are binding to |
| TSelectSource | The source we are binding to |
| TSelectResult | The result of select type |

<a name='M-modelLINQ-ListExtension-BindSelectedPropertyItem``3-System-Linq-Expressions-Expression,System-String,System-String,System-String-'></a>
### BindSelectedPropertyItem\`\`3(param,bindingPropertyName,selectOnPropertyName,propertyToBind) `method`

##### Summary

Bind on selected property of a given list item as a single item

##### Returns

An expression tree of the select binding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The parameter to generate the binding on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name on the binding model |
| selectOnPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Selects the property on the param before building |
| propertyToBind | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to selet |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The type we are binding to |
| TSelectSource | The source we are binding to |
| TSelectResult | The result of select type |

<a name='M-modelLINQ-ListExtension-BindSelectedPropertyList``3-System-Linq-Expressions-Expression,System-String,System-String-'></a>
### BindSelectedPropertyList\`\`3(param,bindingPropertyName,propertyToBind) `method`

##### Summary

Bind on selected property of a given list item as a list

##### Returns

An expression tree of the select binding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The parameter to generate the binding on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name on the binding model |
| propertyToBind | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to selet |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The type we are binding to |
| TSelectSource | The source we are binding to |
| TSelectResult | The result of select type |

<a name='M-modelLINQ-ListExtension-BindSelectedPropertyList``3-System-Linq-Expressions-Expression,System-String,System-String,System-String-'></a>
### BindSelectedPropertyList\`\`3(param,bindingPropertyName,selectOnPropertyName,propertyToBind) `method`

##### Summary

Bind on selected property of a given list item as a list

##### Returns

An expression tree of the select binding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The parameter to generate the binding on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name on the binding model |
| selectOnPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name to get on the param before building |
| propertyToBind | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to selet |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The type we are binding to |
| TSelectSource | The source we are binding to |
| TSelectResult | The result of select type |

<a name='M-modelLINQ-ListExtension-BindSelectedProperty``3-System-Linq-Expressions-Expression,System-String,System-String,System-Boolean-'></a>
### BindSelectedProperty\`\`3(param,bindingPropertyName,propertyToBind) `method`

##### Summary

Bind on selected property of a given list item as a list or a single item

##### Returns

An expression tree of the select binding

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The parameter to generate the binding on |
| bindingPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name on the binding model |
| propertyToBind | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property to selet |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The type we are binding to |
| TSelectSource | The source we are binding to |
| TSelectResult | The result of select type |

<a name='T-modelLINQ-MethodExtension'></a>
## MethodExtension `type`

##### Namespace

modelLINQ

<a name='M-modelLINQ-MethodExtension-Any``1-System-Linq-Expressions-Expression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression}-'></a>
### Any\`\`1(param,anyPredicateExpression) `method`

##### Summary

Any method call expression generator

##### Returns

A any method call expression

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The parameter generating the any |
| anyPredicateExpression | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The lambda function body |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TAnySource | The any param source |

<a name='M-modelLINQ-MethodExtension-GetAny'></a>
### GetAny() `method`

##### Summary

Gets any method information

##### Returns

Anys IEnumerable method information

##### Parameters

This method has no parameters.

<a name='M-modelLINQ-MethodExtension-GetOrderBy-System-Boolean-'></a>
### GetOrderBy(desc) `method`

##### Summary

Gets the order by method info off enumerable

##### Returns

Order by Method Info

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we want to descend |

<a name='M-modelLINQ-MethodExtension-GetSelect'></a>
### GetSelect() `method`

##### Summary

Gets the select method info from Enumerable

##### Returns

The select method info

##### Parameters

This method has no parameters.

<a name='M-modelLINQ-MethodExtension-GetWhere'></a>
### GetWhere() `method`

##### Summary

Gets IEnumerables where MethodInfo

##### Returns

The where MethodInfo

##### Parameters

This method has no parameters.

<a name='M-modelLINQ-MethodExtension-SelectProperty``2-System-Linq-Expressions-Expression,System-String,System-String,System-Boolean-'></a>
### SelectProperty\`\`2(param,propertyName,sourceName,asList) `method`

##### Summary

Selects a property from a lisst

##### Returns

The selects method call expression

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The select parameter |
| propertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property on the TSource we are selecting |
| sourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the select source |
| asList | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we need to generate a list or get a single item |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectSource | The source type of the select |
| TSelectResult | The result type of the select |

<a name='M-modelLINQ-MethodExtension-Select``2-System-Linq-Expressions-Expression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-String,System-Boolean-'></a>
### Select\`\`2(bindingParam,predicate,assigments,predicateSourceName,selectSourceName,asList) `method`

##### Summary

Selects a list of items into another list of results filtered by
a where predicate

##### Returns

A filitered list of TSelectResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bindingParam | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The binding param of the predicate |
| predicate | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate to filter the results on |
| assigments | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The assignments of the result |
| predicateSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The predicate source name override |
| selectSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The source name override |
| asList | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we want to select as a list |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectSource | The source of the list of items |
| TSelectResult | The result of the list of items |

<a name='M-modelLINQ-MethodExtension-Select``2-System-Linq-Expressions-MethodCallExpression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-Boolean-'></a>
### Select\`\`2(predicate,assigments,sourceName,asList) `method`

##### Summary

Selects a list of items into another list of results filtered by
a where predicate

##### Returns

A filitered list/item of TSelectResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| predicate | [System.Linq.Expressions.MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') | The predicate to filter the results on |
| assigments | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The assignments of the result |
| sourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The source name override |
| asList | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we want to select a list of items |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectSource | The source of the list of items |
| TSelectResult | The result of the list of items |

<a name='M-modelLINQ-MethodExtension-Select``2-System-Linq-Expressions-Expression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-Boolean-'></a>
### Select\`\`2(param,assigments,sourceName,asList) `method`

##### Summary

Selects a sub item off the expression and utilizing the member assignments
creates a list of objects

##### Returns

A list of TResults MethodCallExpression

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The expression param that contains the property to sellect off |
| assigments | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The member assignments to generate the model from the parm |
| sourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Lets you override the source name if necessary of the lambda select body |
| asList | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we want to select as a list |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectSource | The source of the list of items to select on |
| TSelectResult | The result model the list will contain |

<a name='M-modelLINQ-MethodExtension-Select``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-String,System-Boolean,System-Boolean-'></a>
### Select\`\`3(bindingParam,orderByProperty,predicate,assigments,predicateSourceName,selectSourceName,desc,asList) `method`

##### Summary

Selects a list of items that are filtered by the given
predicate and ordered by the ordering expression, and finally
selecting the TResults by the bindings

##### Returns

A list of filtered and ordered TResults

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bindingParam | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The parameter to bind on |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property that is being ordered on |
| predicate | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate generator |
| assigments | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The select generator |
| predicateSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The predicate source name override |
| selectSourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The select source name override |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we are descending the ordering |
| asList | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we are selecting as a list |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectSource | The source of the list |
| TOrderBy | The type of the ordering |
| TSelectResult | The result to select on |

<a name='M-modelLINQ-MethodExtension-Select``3-System-Linq-Expressions-MethodCallExpression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-Boolean,System-String,System-Boolean-'></a>
### Select\`\`3(predicate,orderByProperty,assigments,sourceName,desc,asList) `method`

##### Summary

Selects a sub item off the expression and utilizing the member assignments
creates a list of objects

##### Returns

A filtered orderd list/item of TResults MethodCallExpression

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| predicate | [System.Linq.Expressions.MethodCallExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MethodCallExpression 'System.Linq.Expressions.MethodCallExpression') | The where predicate of the items |
| orderByProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The order by property |
| assigments | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The member assignments to generate the model from the parm |
| sourceName | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Lets you override the source name if necessary of the lambda select body |
| desc | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | If we are ordering by descending |
| asList | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we want to select as a list |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectSource | The source of the list of items to select on |
| TOrderBy | The ordering by type |
| TSelectResult | The result model the list will contain |

<a name='M-modelLINQ-MethodExtension-Select``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String,System-Boolean,System-Boolean-'></a>
### Select\`\`3(param,orderBy,assigments,sourceName,desc,asList) `method`

##### Summary

Selects a sub item off the expression and utilizing the member assignments
creates a list of objects

##### Returns

A orderd list of TResults MethodCallExpression

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The expression param that contains the property to sellect off |
| orderBy | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The order by expression |
| assigments | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The member assignments to generate the model from the parm |
| sourceName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Lets you override the source name if necessary of the lambda select body |
| desc | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we are ordering by descending |
| asList | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If we want to select as a list |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSelectSource | The source of the list of items to select on |
| TOrderBy | The ordering by type |
| TSelectResult | The result model the list will contain |

<a name='M-modelLINQ-MethodExtension-WherePredictate``1-System-Linq-Expressions-Expression,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-String-'></a>
### WherePredictate\`\`1(bindingParam,predicate,paramName) `method`

##### Summary

Generates a where predicate in order to filter a list
down by the function predicate, generally to be selected or
to listed

##### Returns

A filtered list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bindingParam | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The binding param of the list |
| predicate | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate generator function |
| paramName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The override of the source param name |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source of the list to filter |

<a name='M-modelLINQ-MethodExtension-WherePredictate``1-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-Expression},System-String-'></a>
### WherePredictate\`\`1(param,paramPropertyName,predicate,paramName) `method`

##### Summary

Generates a where predicate in order to filter a list
down by the function predicate binding from the param property name
generally to be selected or to listed

##### Returns

A filtered list

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The binding parent param |
| paramPropertyName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The property name to get the binding |
| predicate | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.Expression}') | The predicate generator |
| paramName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The param name |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source of the list |

<a name='T-modelLINQ-ModelExtension'></a>
## ModelExtension `type`

##### Namespace

modelLINQ

<a name='M-modelLINQ-ModelExtension-AsModel``2'></a>
### AsModel\`\`2() `method`

##### Summary

Directly maps one type to another type

##### Returns

A function for direct mapping

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source type of the mapping |
| TResult | The result type of the mapping |

<a name='M-modelLINQ-ModelExtension-GenerateModel``2-``0-'></a>
### GenerateModel\`\`2(sourceObject) `method`

##### Summary

Maps over a TSource to a TResult by creating a list
of the individual object and utilizing the member assignments
to project the TResult.

##### Returns

An instance of TResult

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sourceObject | [\`\`0](#T-``0 '``0') | The source object we are mapping over to the TResult |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source of the generation |
| TResult | The result of the generation |

<a name='M-modelLINQ-ModelExtension-Model``2-System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberBinding[]},System-String-'></a>
### Model\`\`2(bindingGenerator,paramName) `method`

##### Summary

Proxy method for generating a new member expression, just for saving on 
typing each time a new model is needing to be generated

##### Returns

A new expression lamaba of the model being generated

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberBinding[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberBinding[]}') | A function that generates the necessary bindings of the model from the source |
| paramName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | If you want to overide the name of the source, otherwise default to source |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source of the model whom gets passed down to the bindings |
| TResult | The result of the new expression init |

<a name='M-modelLINQ-ModelExtension-NullModelCondition``2-System-Linq-Expressions-Expression,System-Linq-Expressions-MemberInitExpression-'></a>
### NullModelCondition\`\`2(param,memberInit) `method`

##### Summary

Generates an expression conditional that checks if the source is null before
adding the new memeber init expression

##### Returns

A conditional expression that is binds null or a memberinit

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The param we are null checking |
| memberInit | [System.Linq.Expressions.MemberInitExpression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.MemberInitExpression 'System.Linq.Expressions.MemberInitExpression') | The member init function to generate if sourece is not null |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TSource | The source we are checking if null |
| TResult | The result we will bind as null if the source is null |

<a name='T-modelLINQ-ObjectExtension'></a>
## ObjectExtension `type`

##### Namespace

modelLINQ

<a name='M-modelLINQ-ObjectExtension-ObjectBind``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]}-'></a>
### ObjectBind\`\`3(param,bindingProperty,bindingGenerator) `method`

##### Summary

Binds an object decleration to result, checking if the source is null and if it 
is putting a null in stead of the member init expression

##### Returns

An object bound memberassignment on either null or the new model

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source parameter expression |
| bindingProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property on the parent we are binding to |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The member generator of the new member init, if null check passes on the source |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent object of the binding where we are binding the result to |
| TSelectSource | The source of the object bind |
| TSelectResult | The result of the object bind |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | If parent lacks binding property |

<a name='M-modelLINQ-ObjectExtension-ObjectBind``3-System-Linq-Expressions-Expression,System-String,System-Func{System-Linq-Expressions-Expression,System-Linq-Expressions-MemberAssignment[]},System-String[]-'></a>
### ObjectBind\`\`3(param,bindingProperty,bindingGenerator,propertyNames) `method`

##### Summary

Binds an object decleration to result, checking if the source is null and if it 
is putting a null in stead of the member init expression

##### Returns

An object bound memberassignment on either null or the new model

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| param | [System.Linq.Expressions.Expression](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Linq.Expressions.Expression 'System.Linq.Expressions.Expression') | The source parameter expression |
| bindingProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the property on the parent we are binding to |
| bindingGenerator | [System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.Linq.Expressions.Expression,System.Linq.Expressions.MemberAssignment[]}') | The member generator of the new member init, if null check passes on the source |
| propertyNames | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The property names to go down from the existing param |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TBindingTo | The parent object of the binding where we are binding the result to |
| TSelectSource | The source of the object bind |
| TSelectResult | The result of the object bind |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | If parent lacks binding property |
