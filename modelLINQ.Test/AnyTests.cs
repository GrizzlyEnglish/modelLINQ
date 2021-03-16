using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static modelLINQ.Test.TestClasses;

namespace modelLINQ.Test
{
    [TestClass]
    public class AnyTests
    {
        private List<ObjectD> Objects { get; set; }

        [TestInitialize]
        public void Init()
        {
            Objects = new List<ObjectD>
            {
                new ObjectD
                {
                    Id = 1,
                    ListOfA = new List<ObjectA>
                    {
                        new ObjectA
                        {
                            Id = 1
                        }
                    }
                },
                new ObjectD
                {
                    Id = 2
                }
            };
        }

        /// <summary>
        /// Tests any method call against a list of objects
        /// </summary>
        [TestMethod]
        public void TestAny()
        {
            // Setup the source param
            ParameterExpression sourceParam = Expression.Parameter(typeof(ObjectD), "source");

            // Setup the model bindings
            MemberAssignment[] assignments = new MemberAssignment[]
            {
                sourceParam.DirectBind<ObjectF>(nameof(ObjectF.Id)),
                sourceParam.BindHasAny<ObjectF, ObjectA>(nameof(ObjectF.HasChildren), (param) => {
                    return Expression.Equal(
                        Expression.Property(param, nameof(ObjectA.Id)),
                        Expression.Constant(1)
                        );
                }, nameof(ObjectD.ListOfA))
            };

            // Select the objectF from the objectD list
            ObjectF obj = Objects
                .Select(Expression.Lambda<Func<ObjectD, ObjectF>>(
                    Expression.MemberInit(Expression.New(typeof(ObjectF)), assignments)
                , sourceParam).Compile()).FirstOrDefault();

            // Verify data
            Assert.IsNotNull(obj);
            Assert.IsTrue(obj.HasChildren);
            Assert.AreEqual(1, obj.Id);
        }
    }
}
