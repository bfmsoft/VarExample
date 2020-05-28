using System;
using Xunit;

namespace DotNetCoreNullable
{
    internal class SomeReallyLongClassNameThatIsDescriptive
    {
        public string Str1;
        public int Int1;
        public string? Str2; // that can be null (no warning)
        public int? Int2; // that can be null (no warning)
        public string Str3 = null!; // tell compiler I know shouldn't be null but I know what Im doing
        public int Int3 = default; // can't set to null! because int isn't nullable so has to be 0 
        // BTW - default - is the keyword that the compiler uses to find the cudrrent default for a type (in this case 0 for int)
    }

    public class UnitTest1
    {
        [Fact]
        public void TestWithoutVar()
        {
            // notice compiler warning below?  When Nullable checking enabled get a warning you are doing something dangerous
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
        public void TestWithVar()
        {
            // can't do this as var variables HAVE have a right assignment for compiler to determine type (uncomment to see)
            // so by using var it avoids nulls in one case
            //var c2;

            var c2 = new SomeReallyLongClassNameThatIsDescriptive();
            Assert.NotNull(c2);
            // notice type of variable is the correct type
            Assert.IsType<SomeReallyLongClassNameThatIsDescriptive>(c2);
        }


        [Fact]
        // var in C# means have compiler determine type from right part of statement.  So 'string x = "abc";' and 'var x = "abc";' are exactly the same
        public void DecomipleExample()
        {
            // no difference in code generated
            SomeReallyLongClassNameThatIsDescriptive c1 = new SomeReallyLongClassNameThatIsDescriptive();
            //00007FF860BEBBC0 mov         rcx,7FF8602BC8D8h
            //00007FF860BEBBCA call        CORINFO_HELP_NEWSFAST(07FF8BF6F7240h)
            //00007FF860BEBBCF mov         qword ptr[rbp + 30h], rax
            //00007FF860BEBBD3 mov         rcx,qword ptr[rbp + 30h]
            //00007FF860BEBBD7 call        CLRStub[MethodDescPrestub]@7ff86012a000(07FF86012A000h)
            //00007FF860BEBBDC mov         rcx,qword ptr[rbp + 30h]
            //00007FF860BEBBE0 mov         qword ptr[rbp + 40h], rcx
            var c2 = new SomeReallyLongClassNameThatIsDescriptive();
            //00007FF860BEBBE4 mov         rcx,7FF8602BC8D8h
            //00007FF860BEBBEE call        CORINFO_HELP_NEWSFAST(07FF8BF6F7240h)
            //00007FF860BEBBF3 mov         qword ptr[rbp + 28h], rax
            //00007FF860BEBBF7 mov         rcx,qword ptr[rbp + 28h]
            //00007FF860BEBBFB call        CLRStub[MethodDescPrestub]@7ff86012a000(07FF86012A000h)
            //00007FF860BEBC00 mov         rax,qword ptr[rbp + 28h]
            //00007FF860BEBC04 mov         qword ptr[rbp + 38h], rax

            // il of code see no difference notice class name in code (compiler replaces at compile time)
            //IL_0000: nop
            //SomeReallyLongClassNameThatIsDescriptive c1 = new SomeReallyLongClassNameThatIsDescriptive();
            //IL_0001:  newobj instance void DotNetCoreNullable.SomeReallyLongClassNameThatIsDescriptive::.ctor()
            //IL_0006: stloc.0
            //var c2 = new SomeReallyLongClassNameThatIsDescriptive();
            //IL_0007: newobj instance void DotNetCoreNullable.SomeReallyLongClassNameThatIsDescriptive::.ctor()
            //IL_000c: stloc.1
            //IL_000d: ret
        }

        [Fact]
        // var in C# means have compiler determine type from right part of statement.  So 'string x = "abc";' and 'var x = "abc";' are exactly the same
        public void ClassCreation()
        {
                // old way
                var c3 = new SomeReallyLongClassNameThatIsDescriptive();
            c3.Str1 = "111";
            c3.Int1 = 1;
            c3.Str2 = "222";
            c3.Int2 = 2;
            c3.Str3 = "333";
            c3.Int3 = 3;
            Assert.Equal("111", c3.Str1);

            // new way
            var c4 = new SomeReallyLongClassNameThatIsDescriptive {
                Str1 = "111",
                Int1 = 1,
                Str2 = "222",
                Int2 = 2,
                Str3 = "333",
                Int3 = 3,
            };
            Assert.Equal("111", c4.Str1);
        }
    }
}
