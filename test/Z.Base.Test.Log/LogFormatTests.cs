using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.Base.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Base.Test.Log
{
    /// <summary>
    ///这是 LogFormatTest 的测试类，旨在
    ///包含所有 LogFormatTest 单元测试
    ///</summary>
    ///<remarks>
    ///作者：北冥冰皇
    ///创建日期：2018-12-13
    ///</remarks>
    [TestClass()]
    public class LogFormatTests
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

        #region CommStr 的测试
        /// <summary>
        ///CommStr 的测试
        ///</summary>
        [TestMethod()]
        public void CommStrTest()
        {
            string cmd = "发送：";
            byte[] bytes = { 0x01, 0x01 };
            string expected = "发送：\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + "01 01 " + "\r\n";

            string actual = LogFormat.CommStr(cmd, bytes);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region ErrorStr 的测试
        /// <summary>
        ///ErrorStr 的测试
        ///</summary>
        [TestMethod()]
        public void ErrorStrTest()
        {
            string name = "test";
            Exception ex = null;
            string expected = "\r\ntest:";

            string actual = LogFormat.ErrorStr(name, ex);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region InfoStr 的测试
        /// <summary>
        ///InfoStr 的测试
        ///</summary>
        [TestMethod()]
        public void InfoStrTest()
        {
            string txt = string.Empty;
            string expected = "<" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ">:" + txt;

            string actual = LogFormat.InfoStr(txt);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion
    }
}