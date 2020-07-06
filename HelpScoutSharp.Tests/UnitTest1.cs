using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(Environment.GetEnvironmentVariable("MY_ENV_VAR"));
            Assert.IsTrue(Environment.GetEnvironmentVariable("MY_ENV_VAR").Length > 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.Fail("Test fail");
        }
    }
}
