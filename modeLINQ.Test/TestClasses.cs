using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace modelLINQ.Test
{
    public class TestClasses
    {
        /// <summary>
        /// The "source" object of all our tests
        /// </summary>
        public class ObjectA
        {
            public int Id { get; set; }
            public ObjectA SubLevel { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// The mapped object of our tests
        /// </summary>
        public class ObjectB
        {
            public int Id { get; set; }
            public ObjectC Object { get; set; }

            /// <summary>
            /// A mapping assignment for objectB
            /// </summary>
            public static Func<Expression, MemberAssignment[]> FromObjectA = param =>
                new MemberAssignment[]
                {
                    param.DirectBind<ObjectB>("Id")
                };
        }

        /// <summary>
        /// The sub mapped object of our tests
        /// </summary>
        public class ObjectC
        {
            public string Name { get; set; }
        }

        /// <summary>
        /// Object D has a list of Object A we can select off of
        /// </summary>
        public class ObjectD
        {
            public int Id { get; set; }
            public List<ObjectA> ListOfA { get; set; }
        }

        /// <summary>
        /// Object E is a mapped object with a list of Object B to 
        /// use with Object D
        /// </summary>
        public class ObjectE
        {
            public int Id { get; set; }
            public List<ObjectB> ListOfB { get; set; }
            public ObjectB ObjectB { get; set; }
        }

    }
}
