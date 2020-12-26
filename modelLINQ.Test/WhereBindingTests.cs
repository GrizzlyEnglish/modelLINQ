using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static modelLINQ.Test.TestClasses;

namespace modelLINQ.Test
{
    /// <summary>
    /// Tests the validity of the where binding
    /// genators
    /// </summary>
    [TestClass]
    public class WhereBindingTests
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
                    }
                }
            };

            sourceParam = Expression.Parameter(typeof(ObjectD), "source");
        }

        /// <summary>
        /// Verify the binding of the where clause to list with a select by property
        /// </summary>
        [TestMethod]
        public void WhereSelectTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.Equal(Expression.Property(param, "Id"), Expression.Constant(1));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindFilteredList<ObjectE, ObjectA, ObjectB>("ListOfB", predicateGenerator, ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(1, obj.ListOfB.Count());
            Assert.AreEqual(1, obj.ListOfB.FirstOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the where clause to list with a select by name
        /// </summary>
        [TestMethod]
        public void WhereSelectTestByName()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.Equal(Expression.Property(param, "Id"), Expression.Constant(1));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindFilteredList<ObjectE, ObjectA, ObjectB>("ListOfB", "ListOfA", predicateGenerator, ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(1, obj.ListOfB.Count());
            Assert.AreEqual(1, obj.ListOfB.FirstOrDefault().Id);
        }

        /// <summary>
        /// Verify the binding of the where clause item with a select by property
        /// </summary>
        [TestMethod]
        public void WhereSelectItemTest()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.Equal(Expression.Property(param, "Id"), Expression.Constant(1));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindFilteredItem<ObjectE, ObjectA, ObjectB>("ObjectB", predicateGenerator, ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ObjectB);
            Assert.AreEqual(1, obj.ObjectB.Id);
        }

        /// <summary>
        /// Verify the binding of the where clause item with a select by name
        /// </summary>
        [TestMethod]
        public void WhereSelectItemTestByName()
        {
            Func<Expression, Expression> predicateGenerator = param =>
                Expression.Equal(Expression.Property(param, "Id"), Expression.Constant(1));

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindFilteredItem<ObjectE, ObjectA, ObjectB>("ObjectB", "ListOfA", predicateGenerator, ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ObjectB);
            Assert.AreEqual(1, obj.ObjectB.Id);
        }
    }
}
