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