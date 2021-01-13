using CalculateLib;
using System;
using System.Threading;
using Xunit;

namespace CalculatedLibTest
{
    [Collection("Test Collection #1")]
    public class SimpleCalculateTest
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }
    }

    [Collection("Test Collection #2")]
    public class SimpleCalculateTest2
    {
        [Fact]
        public void Test2()
        {
            Thread.Sleep(5000);
        }
    }
}
