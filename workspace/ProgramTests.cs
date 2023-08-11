using System;
using System.IO;
using HelloWorld;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorldTest
{
    [TestClass]
    public class ProgramTests
    {
        private StringWriter stringWriter;
        private StringReader stringReader;

        [TestInitialize]
        public void SetUp()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            stringReader = new StringReader(stringWriter.ToString());
            Console.SetIn(stringReader);
        }

        [TestCleanup]
        public void TearDown()
        {
            stringWriter.Close();
            stringReader.Close();
        }

        [TestMethod]
        public void TestPrintMessage()
        {
            Program.PrintMessage();
            string expected = string.Format("Hello, World!{0}", Environment.NewLine);
            Assert.AreEqual(expected, stringWriter.ToString());
        }
    }
}
