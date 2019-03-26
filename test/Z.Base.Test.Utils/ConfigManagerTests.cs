using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Base.Test.Utils
{
    /// <summary>
    ///这是 ConfigManagerTest 的测试类，旨在
    ///包含所有 ConfigManagerTest 单元测试
    ///</summary>
    ///<remarks>
    ///作者：北冥冰皇
    ///创建日期：2018-12-13
    ///</remarks>
    [TestClass()]
    public class ConfigManagerTests
    {

        #region 获取或设置测试上下文，上下文提供有关当前测试运行及其功能的信息
        /// <summary>
        /// 获取或设置测试上下文，上下文提供
        /// 有关当前测试运行及其功能的信息
        /// </summary>
        private TestContext testContextInstance;
        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        #endregion

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #region BoolVal 的测试
        /// <summary>
        ///BoolVal 的测试
        ///</summary>
        [TestMethod()]
        public void BoolValTest()
        {
            string key = "Bool";
            string config = string.Empty;
            bool expected = true;

            bool actual = ConfigManager.BoolVal(key, config);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region Configuration 的测试
        /// <summary>
        ///Configuration 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Z.Base.Utils.dll")]
        public void ConfigurationTest()
        {
            string fileName = string.Empty;
            string dir = string.Empty;
            //Configuration expected = null;

            //Configuration actual = ConfigManager_Accessor.Configuration(fileName, dir);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region FloatVal 的测试
        /// <summary>
        ///FloatVal 的测试
        ///</summary>
        [TestMethod()]
        public void FloatValTest()
        {
            string key = "Float";
            string config = string.Empty;
            float expected = 1.0F;

            float actual = ConfigManager.FloatVal(key, config);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region IntVal 的测试
        /// <summary>
        ///IntVal 的测试
        ///</summary>
        [TestMethod()]
        public void IntValTest()
        {
            string key = "Int";
            string config = string.Empty;
            int expected = 1;

            int actual = ConfigManager.IntVal(key, config);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region StringVal 的测试
        /// <summary>
        ///StringVal 的测试
        ///</summary>
        [TestMethod()]
        public void StringValTest()
        {
            string key = "String";
            string config = string.Empty;
            string expected = "test";

            string actual = ConfigManager.StringVal(key, config);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion
    }
}