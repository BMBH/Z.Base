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
    ///这是 ParserTest 的测试类，旨在
    ///包含所有 ParserTest 单元测试
    ///</summary>
    ///<remarks>
    ///作者：北冥冰皇
    ///创建日期：2018-12-13
    ///</remarks>
    [TestClass()]
    public class ParserTests
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

        #region TryToDatetime 的测试
        /// <summary>
        ///TryToDatetime 的测试
        ///</summary>
        [TestMethod()]
        public void TryToDatetimeTest()
        {
            string value = "2018-12-13";
            string date_format = string.Empty;
            DateTime expected = new DateTime(2018, 12, 13);

            DateTime actual = Parser.TryToDatetime(value, date_format);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region TryToDecimal 的测试
        /// <summary>
        ///TryToDecimal 的测试
        ///</summary>
        [TestMethod()]
        public void TryToDecimalTest()
        {
            double value = 1.01;
            string format = string.Empty;
            Decimal expected = 1.01M;

            Decimal actual = Parser.TryToDecimal(value.ToString(), format);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region TryToDecimalStr 的测试
        /// <summary>
        ///TryToDecimalStr 的测试
        ///</summary>
        [TestMethod()]
        public void TryToDecimalStrTest()
        {
            string value = "1.010";
            string format = "0.000";
            string expected = "1.010";

            string actual = Parser.TryToDecimalStr(value, format);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region TryToDouble 的测试
        /// <summary>
        ///TryToDouble 的测试
        ///</summary>
        [TestMethod()]
        public void TryToDoubleTest()
        {
            double value = 1.01;
            string format = "0.000";
            double expected = 1.01;

            double actual = Parser.TryToDouble(value.ToString(), format);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region TryToDoubleStr 的测试
        /// <summary>
        ///TryToDoubleStr 的测试
        ///</summary>
        [TestMethod()]
        public void TryToDoubleStrTest()
        {
            string value = "1.011";
            string format = string.Empty;
            string expected = "1.01";

            string actual = Parser.TryToDoubleStr(value, format);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region TryToFloat 的测试
        /// <summary>
        ///TryToFloat 的测试
        ///</summary>
        [TestMethod()]
        public void TryToFloatTest()
        {
            float value = 1.011f;
            string format = string.Empty;
            float expected = 1.01f;

            float actual = Parser.TryToFloat(value.ToString(), format);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region TryToFloatStr 的测试
        /// <summary>
        ///TryToFloatStr 的测试
        ///</summary>
        [TestMethod()]
        public void TryToFloatStrTest()
        {
            string value = "1.0111";
            string format = "0.000";
            string expected = "1.011";

            string actual = Parser.TryToFloatStr(value, format);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region TryToInt 的测试
        /// <summary>
        ///TryToInt 的测试
        ///</summary>
        [TestMethod()]
        public void TryToIntTest()
        {
            int value = 99;
            int expected = 99;

            int actual = Parser.TryToInt(value.ToString());
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

    }
}