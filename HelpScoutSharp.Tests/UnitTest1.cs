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
            Console.WriteLine($"Env var = {Environment.GetEnvironmentVariable("MY_ENV_VAR")}");
        }
    }
}
