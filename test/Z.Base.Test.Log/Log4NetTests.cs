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
    ///这是 Log4NetTest 的测试类，旨在
    ///包含所有 Log4NetTest 单元测试
    ///</summary>
    ///<remarks>
    ///作者：北冥冰皇
    ///创建时间：2018-12-13
    ///</remarks>
    [TestClass()]
    public class Log4NetTests
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

        #region InitLog4Net 的测试
        /// <summary>
        ///InitLog4Net 的测试
        ///</summary>
        [TestMethod()]
        public void InitLog4NetTest()
        {
            Log4Net.LoadConfig();
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }
        #endregion

        #region Error 的测试
        /// <summary>
        ///Error 的测试
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            string msg = "test";
            Log4Net.Error(msg);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }
        #endregion

        #region Error 的测试
        /// <summary>
        ///Error 的测试
        ///</summary>
        [TestMethod()]
        public void ErrorTest1()
        {
            string msg = "test";
            Exception ex = null;
            Log4Net.Error(msg, ex);
            //Assert.Inconclusive("无法验证不返回值的方法。");
        }
        #endregion
    }
}