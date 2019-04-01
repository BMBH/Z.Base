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
    ///这是 RuleManagerTest 的测试类，旨在
    ///包含所有 RuleManagerTest 单元测试
    ///</summary>
    [TestClass()]
    public class RuleManagerTest
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

        #region IsHexadecimal 的测试
        /// <summary>
        ///IsHexadecimal 的测试
        ///</summary>
        [TestMethod()]
        public void IsHexadecimalTest()
        {
            //string str = "0f";
            //bool expected = true;

            string str = "0fo";
            bool expected = false;

            bool actual = RuleManager.IsHexadecimal(str);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region IsLetter 的测试
        /// <summary>
        ///IsLetter 的测试
        ///</summary>
        [TestMethod()]
        public void IsLetterTest()
        {
            //string str = "abcd";
            //bool expected = true;

            string str = "aa12";
            bool expected = false;

            bool actual = RuleManager.IsLetter(str);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region IsNumber 的测试
        /// <summary>
        ///IsNumber 的测试
        ///</summary>
        [TestMethod()]
        public void IsNumberTest()
        {
            //string str = "123456";
            //bool expected = true;

            string str = "abc123";
            bool expected = false;

            bool actual = RuleManager.IsNumber(str);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region IsNumberOrLetter 的测试
        /// <summary>
        ///IsNumberOrLetter 的测试
        ///</summary>
        [TestMethod()]
        public void IsNumberOrLetterTest()
        {
            //string str = "a1";
            //bool expected = true;

            string str = "a1.";
            bool expected = false;

            bool actual = RuleManager.IsNumberOrLetter(str);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion
    }
}