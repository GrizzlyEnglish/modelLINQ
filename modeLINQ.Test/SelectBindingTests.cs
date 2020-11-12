﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static modeLINQ.Test.TestClasses;

namespace modeLINQ.Test
{
    /// <summary>
    /// Tests the select binding of objects
    /// </summary>
    [TestClass]
    public class SelectBindingTests
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
        /// Select from the property expression and verify
        /// the sub list of objects was converted over
        /// </summary>
        [TestMethod]
        public void SelectTestByProperty()
        {
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                Expression.Property(sourceParam, "ListOfA").BindSelectedList<ObjectE, ObjectA, ObjectB>("ListOfB", ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(2, obj.ListOfB.Count());
        }

        /// <summary>
        /// Select from the source param expression by name and verify
        /// the sub list of objects was converted over
        /// </summary>
        [TestMethod] 
        public void SelectTestByString()
        {
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.BindSelectedList<ObjectE, ObjectA, ObjectB>("ListOfB", "ListOfA", ObjectB.FromObjectA)
            };

            ObjectE obj = listOfObjectD.Select(Expression.Lambda<Func<ObjectD, ObjectE>>(
                Expression.MemberInit(Expression.New(typeof(ObjectE)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            Assert.IsNotNull(obj.ListOfB);
            Assert.AreEqual(2, obj.ListOfB.Count());
        }
    }
}
