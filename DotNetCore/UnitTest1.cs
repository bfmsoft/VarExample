using System;
using Xunit;

namespace DotNetCore
{
    internal class SomeReallyLongClassNameThatIsDescriptive {
        public string Str1;
        public int Int1;
    }

    public class UnitTest1
    {
        [Fact]
        public void TestWithoutVar()
        {
            // this is the dangerous one to do.  c1 is null here (why var is used and nullable was added to project type)
            SomeReallyLongClassNameThatIsDescriptive c1 = null;
            // have to assign to null because compiler wont allow you to use an unassigned variable
            Assert.Null(c1);

            // can't test type here because variable is null (uncomment to see)
            //Assert.IsType<SomeReallyLongClassNameThatIsDescriptive>(c1);

            c1 = new SomeReallyLongClassNameThatIsDescriptive();
            // because you never assigned to Str1 and Int1 both null (you get compiler warnings)
            Assert.NotNull(c1);
            Assert.IsType<SomeReallyLongClassNameThatIsDescriptive>(c1);
        }

        [Fact]
        // var in C# means have compiler determine type from right part of statement.  So 'string x = "abc";' and 'var x = "abc";' are exactly the same
        public void TestWithVar() {
            // can't do this as var variables HAVE have a right assignment for compiler to determine type (uncomment to see)
            // so by using var it avoids nulls in one case
            //var c2;

            var c2 = new SomeReallyLongClassNameThatIsDescriptive();
            Assert.NotNull(c2);
            Assert.IsType<SomeReallyLongClassNameThatIsDescriptive>(c2);
        }
    }
}
