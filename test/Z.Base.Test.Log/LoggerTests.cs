using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.Base.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Base.Test.Utils
{
    /// <summary>
    ///这是 LoggerTest 的测试类，旨在
    ///包含所有 LoggerTest 单元测试
    ///</summary>
    ///<remarks>
    ///作者：北冥冰皇
    ///创建日期：2018-12-13
    ///</remarks>
    [TestClass()]
    public class LoggerTests
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

        #region All 的测试
        /// <summary>
        ///All 的测试
        ///</summary>
        [TestMethod()]
        public void AllTest()
        {
            string text = "all";
            string file = "all";
            string dir = "test";
            bool expected = true;

            bool actual = Logger.All(text, file, dir);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region Debug 的测试
        /// <summary>
        ///Debug 的测试
        ///</summary>
        [TestMethod()]
        public void DebugTest()
        {
            string text = "debug";
            string file = "debug";
            string dir = "debug";
            bool expected = true;

            bool actual = Logger.Debug(text, file, dir);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region Error 的测试
        /// <summary>
        ///Error 的测试
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            string text = "error";
            string file = "error";
            string dir = "error";
            bool expected = true;

            bool actual = Logger.Error(text, file, dir);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region Fatal 的测试
        /// <summary>
        ///Fatal 的测试
        ///</summary>
        [TestMethod()]
        public void FatalTest()
        {
            string text = "fatal";
            string file = "fatal";
            string dir = "fatal";
            bool expected = true;

            bool actual = Logger.Fatal(text, file, dir);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region Info 的测试
        /// <summary>
        ///Info 的测试
        ///</summary>
        [TestMethod()]
        public void InfoTest()
        {
            string text = "info";
            string file = "info";
            string dir = "info";
            bool expected = true;

            bool actual = Logger.Info(text, file, dir);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region None 的测试
        /// <summary>
        ///None 的测试
        ///</summary>
        [TestMethod()]
        public void NoneTest()
        {
            string text = "none";
            string file = "none";
            string dir = "none";
            bool expected = true;

            bool actual = Logger.None(text, file, dir);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region Warn 的测试
        /// <summary>
        ///Warn 的测试
        ///</summary>
        [TestMethod()]
        public void WarnTest()
        {
            string text = "warn";
            string file = "warn";
            string dir = "warn";
            bool expected = true;

            bool actual = Logger.Warn(text, file, dir);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

    }
}