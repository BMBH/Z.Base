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
    ///这是 LogQueueTest 的测试类，旨在
    ///包含所有 LogQueueTest 单元测试
    ///</summary>
    ///<remarks>
    ///作者：北冥冰皇
    ///创建日期：2018-12-13
    ///</remarks>
    [TestClass()]
    public class LogQueueTests
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

        #region WriteLine 的测试
        /// <summary>
        ///WriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineTest()
        {
            string txt = string.Empty;
            Exception ex = null;
            LogQueue.WriteLine(txt, ex);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }
        #endregion

        #region WriteLine 的测试
        /// <summary>
        ///WriteLine 的测试
        ///</summary>
        [TestMethod()]
        public void WriteLineTest1()
        {
            string txt = string.Empty;
            LogQueue.WriteLine(txt);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }
        #endregion
    }
}