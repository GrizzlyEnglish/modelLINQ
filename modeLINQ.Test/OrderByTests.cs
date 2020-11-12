using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static modeLINQ.Test.TestClasses;

namespace modeLINQ.Test
{
    /// <summary>
    /// Tests the validity of the order by
    /// bindings with the various variations
    /// </summary>
    [TestClass]
    public class OrderByTests
    {
        /// <summary>
        /// Our source list of Object D to select 
        /// and gnerate with a sub list
        /// </summary>
        private static List<ObjectD> listOfObjectD;

        /// <summary>
        /// The source list of our selecting
        /// </summary>
        private static ParameterExpression sourceParam;

        [TestInitialize]
        public void Init()
        {
            listOfObjectD = new List<ObjectD>
            {
                new ObjectD
                {
                    Id = 1,
                    ListOfA = new List<ObjectA>
                    {
                        new ObjectA
                        {
                            Id = 1,
                            Name = "Object A 1",
                            SubLevel = new ObjectA
                            {
                                Id = 2,
                                Name = "Object A 1-2"
                            }
                        },
                        new ObjectA
                        {
                            Id = 3,
                            Name = "Object A 1",
                        },
                        new ObjectA
                        {
                            Id = 7,
                            Name = "Object A 1",
                        },
                        new ObjectA
                        {
                            Id = 9,
                            Name = "Object A 1",
                        },
                    }
                }
            };

            sourceParam = Expression.Parameter(typeof(ObjectD), "source");
        }

        /// <summary>
        /// Verify the binding of the where clause / order by / list with a select by property in asc
        /// </summary>
        [TestMethod]
        public void FilterOrderBySelectTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindOrderedFilteredList<ObjectE, ObjectA, int, ObjectB>("ListOfB", "Id", predicateGenerator, ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(3, obj.ListOfB.Count());
            Assert.AreEqual(1, obj.ListOfB.FirstOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the where clause / order by / list with a select by property in desc
        /// </summary>
        [TestMethod]
        public void FilterOrderBySelectDescTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindOrderedFilteredList<ObjectE, ObjectA, int, ObjectB>("ListOfB", "Id", predicateGenerator, ObjectB.FromObjectA, true)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(3, obj.ListOfB.Count());
            Assert.AreEqual(7, obj.ListOfB.FirstOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the where clause / order by / list with a select by property name in asc
        /// </summary>
        [TestMethod]
        public void FilterOrderBySelectByNameTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindOrderedFilteredList<ObjectE, ObjectA, int, ObjectB>("ListOfB", "ListOfA", "Id", predicateGenerator, ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(3, obj.ListOfB.Count());
            Assert.AreEqual(1, obj.ListOfB.FirstOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the where clause / order by / list with a select by property name in desc
        /// </summary>
        [TestMethod]
        public void FilterOrderBySelectByNameDescTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindOrderedFilteredList<ObjectE, ObjectA, int, ObjectB>("ListOfB", "ListOfA", "Id", predicateGenerator, ObjectB.FromObjectA, true)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(3, obj.ListOfB.Count());
            Assert.AreEqual(7, obj.ListOfB.FirstOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the where clause / order by / item with a select by property name in asc
        /// </summary>
        [TestMethod]
        public void FilterOrderByItemByNameTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindOrderedFilteredItem<ObjectE, ObjectA, int, ObjectB>("ObjectB", "ListOfA", "Id", predicateGenerator, ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ObjectB);
            Assert.AreEqual(1, obj.ObjectB.Id);
        }

        /// <summary>
        /// Verify the binding of the where clause / order by / item with a select by property name in desc
        /// </summary>
        [TestMethod]
        public void FilterOrderByItemByNameDescTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindOrderedFilteredItem<ObjectE, ObjectA, int, ObjectB>("ObjectB", "ListOfA", "Id", predicateGenerator, ObjectB.FromObjectA, true)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ObjectB);
            Assert.AreEqual(7, obj.ObjectB.Id);
        }

        /// <summary>
        /// Verify the binding of the where clause / order by / item with a select by property in asc
        /// </summary>
        [TestMethod]
        public void FilterOrderByItemTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindOrderedFilteredItem<ObjectE, ObjectA, int, ObjectB>("ObjectB", "Id", predicateGenerator, ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ObjectB);
            Assert.AreEqual(1, obj.ObjectB.Id);
        }

        /// <summary>
        /// Verify the binding of the where clause / order by / item with a select by property in desc
        /// </summary>
        [TestMethod]
        public void FilterOrderByItemDescTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindOrderedFilteredItem<ObjectE, ObjectA, int, ObjectB>("ObjectB", "Id", predicateGenerator, ObjectB.FromObjectA, true)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ObjectB);
            Assert.AreEqual(7, obj.ObjectB.Id);
        }

        /// <summary>
        /// Verify the binding of the order by item with a select by property in asc
        /// </summary>
        [TestMethod]
        public void OrderByItemTest()
        {
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindOrderedItem<ObjectE, ObjectA, int, ObjectB>("ObjectB", "Id", ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ObjectB);
            Assert.AreEqual(1, obj.ObjectB.Id);
        }

        /// <summary>
        /// Verify the binding of the order by item with a select by property in desc
        /// </summary>
        [TestMethod]
        public void OrderByItemDescTest()
        {
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindOrderedItem<ObjectE, ObjectA, int, ObjectB>("ObjectB", "Id", ObjectB.FromObjectA, true)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ObjectB);
            Assert.AreEqual(9, obj.ObjectB.Id);
        }

        /// <summary>
        /// Verify the binding of the order by list with a select by property in asc
        /// </summary>
        [TestMethod]
        public void OrderByListTest()
        {
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindOrderedList<ObjectE, ObjectA, int, ObjectB>("ListOfB", "Id", ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(1, obj.ListOfB.FirstOrDefault().Id);
            Assert.AreEqual(9, obj.ListOfB.LastOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the order by item with a select by property in desc
        /// </summary>
        [TestMethod]
        public void OrderByListDescTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindOrderedList<ObjectE, ObjectA, int, ObjectB>("ListOfB", "Id", ObjectB.FromObjectA, true)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(9, obj.ListOfB.FirstOrDefault().Id);
            Assert.AreEqual(1, obj.ListOfB.LastOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the order by list with a select by property name in asc
        /// </summary>
        [TestMethod]
        public void OrderByListByNameTest()
        {
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindOrderedList<ObjectE, ObjectA, int, ObjectB>("ListOfB", "ListOfA", "Id", ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(1, obj.ListOfB.FirstOrDefault().Id);
            Assert.AreEqual(9, obj.ListOfB.LastOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the order by item with a select by property name in desc
        /// </summary>
        [TestMethod]
        public void OrderByListByNameDescTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.LessThan(Expression.Property(param, "Id"), Expression.Constant(9));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindOrderedList<ObjectE, ObjectA, int, ObjectB>("ListOfB", "ListOfA", "Id", ObjectB.FromObjectA, true)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(9, obj.ListOfB.FirstOrDefault().Id);
            Assert.AreEqual(1, obj.ListOfB.LastOrDefault().Id);
        }
    }
}
