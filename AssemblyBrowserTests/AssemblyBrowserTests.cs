using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AssemblyBrowser;
using System.Collections.Generic;

namespace AssemblyBrowserTests
{
    [TestClass]
    public class AssemblyBrowserTests
    {
        private static string Path = "E:\\5сем\\SPP\\MPP_lab2\\MPP_lab2\\bin\\Debug\\FakerLib.dll";
        private static List<TreeNode> targetData = new List<TreeNode>();

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            targetData.Add(AssemblyBrowser.AssemblyBrowser.BrowseFile(Path));
        }

        [TestMethod]
        public void TestFieldItem()
        {
            var testField = targetData[0].childs[0].childs[0].childs[0];
            Assert.AreEqual("Fields", testField.name);
        }
        [TestMethod]
        public void TestPropertyItem()
        {
            var testProperty = targetData[0].childs[0].childs[0].childs[1];
            Assert.AreEqual("Properties", testProperty.name);
        }
        [TestMethod]
        public void TestMethodItem()
        {
            var testMethod = targetData[0].childs[0].childs[0].childs[2];
            Assert.AreEqual("Methods", testMethod.name);
        }
        [TestMethod]
        public void TestCtorItem()
        {
            var testCtor = targetData[0].childs[0].childs[0].childs[3];
            Assert.AreEqual("Constructors", testCtor.name);
        }
        [TestMethod]
        public void TestNamespace()
        {
            var testNamespace = targetData[0].childs[0];
            Assert.AreEqual("FakerLib", testNamespace.name);
        }
        [TestMethod]
        public void TestClassName()
        {
            var testClass = targetData[0].childs[0].childs[0];
            Assert.AreEqual("Faker", testClass.name);
        }
        [TestMethod]
        public void TestMethodName()
        {
            var testMethod = targetData[0].childs[0].childs[0].childs[2].childs[1];
            Assert.AreEqual("T : Create", testMethod.name);
        }
        [TestMethod]
        public void TestMethodParam()
        {
            var testParam = targetData[0].childs[0].childs[0].childs[2].childs[3].childs[0];
            Assert.AreEqual("System.Reflection.ConstructorInfo : cInfo", testParam.name);
        }
        [TestMethod]
        public void TestCtorName()
        {
            var testCtor = targetData[0].childs[0].childs[0].childs[3].childs[1];
            Assert.AreEqual(".ctor", testCtor.name);
        }
        [TestMethod]
        public void TestCtorParam()
        {
            var testParam = targetData[0].childs[0].childs[0].childs[3].childs[1].childs[0];
            Assert.AreEqual("FakerLib.FakerConfig : config", testParam.name);
        }
    }
}
