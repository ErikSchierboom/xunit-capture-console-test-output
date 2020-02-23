using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TestProject.CSharp
{
    public static class TestedUnit1
    {
        public static bool Test()
        {
            Debug.WriteLine("From debug: " + new Random().Next());
            Trace.WriteLine("From trace: " + new Random().Next());
            Console.WriteLine("From console: " + new Random().Next());

            return true;
        }
    }

    public class UnitTest1 : IDisposable
    {
        [Fact]
        public void Test1()
        {
            Assert.True(TestedUnit1.Test());
        }

        [Fact]
        public void Test2()
        {
            Assert.True(TestedUnit1.Test());
        }

        public void Dispose()
        {
            _testOutput.WriteLine(_stringWriter.ToString());
        }
        
        private readonly ITestOutputHelper _testOutput;
        private readonly StringWriter _stringWriter;

        public UnitTest1(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _stringWriter = new StringWriter();
            
            Console.SetOut(_stringWriter);
            Console.SetError(_stringWriter);

            Trace.Listeners.Add(new ConsoleTraceListener());
        }
    }
}