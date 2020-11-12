using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using modeLINQ;
using static modeLINQ.Test.TestClasses;

namespace modeLINQ.Test
{
    /// <summary>
    /// Tests the validaty of binding extension methods
    /// </summary>
    [TestClass]
    public class DirectBindingTests
    {
        /// <summary>
        /// Basic list for selecting ObjectBs from
        /// </summary>
        private static List<ObjectA> listOfObjectA;

        /// <summary>
        /// The basic source param of ObjectA
        /// </summary>
        private static ParameterExpression sourceParam;

        [TestInitialize]
        public void Init()
        {
            listOfObjectA = new List<ObjectA>
            {
                new ObjectA
                {
                    Id = 15,
                    SubLevel = new ObjectA
                    {
                        Id = 33
                    },
                    Name = "Object"
                }
            };

            // The source parameter for the bingdings
            sourceParam = Expression.Parameter(typeof(ObjectA), "source");
        }

        /// <summary>
        /// Verify the direct binding will map over ObjectA.Id to ObjectB.Id
        /// </summary>
        [TestMethod]
        public void DirectBindingTest()
        {
            // Map ObjectA to ObjectB with a direct bind to Id
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.DirectBind<ObjectB>("Id")
            };

            ObjectB obj = listOfObjectA.Select(Expression.Lambda<Func<ObjectA, ObjectB>>(
                Expression.MemberInit(Expression.New(typeof(ObjectB)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.AreEqual(15, obj.Id);
        }

        /// <summary>
        /// Test the sub level direct binding, where we can go down
        /// as many levels as need to grab the information
        /// </summary>
        [TestMethod]
        public void DirectSubLevelBinding()
        {
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.DirectBind<ObjectB>("Id", "SubLevel", "Id")
            };

            ObjectB obj = listOfObjectA.Select(Expression.Lambda<Func<ObjectA, ObjectB>>(
                Expression.MemberInit(Expression.New(typeof(ObjectB)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.AreEqual(33, obj.Id);
        }

        /// <summary>
        /// Directly binds an object and verifies an exception is thrown
        /// if a mismatch of properties 
        /// </summary>
        [TestMethod]
        public void DirectObjectBinding()
        {
            Func<Expression, MemberAssignment[]> objectAssigments = (param) =>
                new MemberAssignment[]
                {
                    param.DirectBind<ObjectC>("Name")
                };

            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.ObjectBind<ObjectB, ObjectA, ObjectC>("Object", objectAssigments)
            };

            ObjectB obj = listOfObjectA.Select(Expression.Lambda<Func<ObjectA, ObjectB>>(
                Expression.MemberInit(Expression.New(typeof(ObjectB)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.AreEqual("Object", obj.Object.Name);

            // Verify if the parent object lacks the property we get an exception
            Assert.ThrowsException<Exception>(() => 
                {
                    sourceParam.ObjectBind<ObjectB, ObjectA, ObjectC>("Name", objectAssigments);
                }
            );
        }
    }
}
