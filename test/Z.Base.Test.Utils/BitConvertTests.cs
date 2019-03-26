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
    ///这是 BitConvertTest 的测试类，旨在
    ///包含所有 BitConvertTest 单元测试
    ///</summary>
    ///<remarks>
    ///作者：北冥冰皇
    ///创建日期：2018-12-13
    ///</remarks>
    [TestClass()]
    public class BitConvertTests
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

        #region ToFloat 的测试
        /// <summary>
        ///ToFloat 的测试
        ///</summary>
        [TestMethod()]
        public void ToFloatTest()
        {
            int startIndex = 0;
            float expected = 10.21f;
            byte[] bytes = BitConverter.GetBytes(expected);

            float actual = BitConvert.ToFloat(bytes, startIndex);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region ToFloat1032 的测试
        /// <summary>
        ///ToFloat1032 的测试
        ///</summary>
        [TestMethod()]
        public void ToFloat1032Test()
        {
            int startIndex = 0;
            float expected = 18.32f;

            byte[] tmp = BitConverter.GetBytes(expected);
            byte[] bytes = new byte[] { tmp[1], tmp[0], tmp[3], tmp[2] };

            float actual = BitConvert.ToFloat1032(bytes, startIndex);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region ToFloatInverse 的测试
        /// <summary>
        ///ToFloatInverse 的测试
        ///</summary>
        [TestMethod()]
        public void ToFloatInverseTest()
        {
            int startIndex = 0;
            float expected = 0F;

            byte[] tmp = BitConverter.GetBytes(expected);
            byte[] bytes = { tmp[3], tmp[2], tmp[1], tmp[0] };

            float actual = BitConvert.ToFloatInverse(bytes, startIndex);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region ToInt16 的测试
        /// <summary>
        ///ToInt16 的测试
        ///</summary>
        [TestMethod()]
        public void ToInt16Test()
        {
            int startIndex = 0;
            int expected = 256;

            byte[] bytes = BitConverter.GetBytes(expected);

            int actual = BitConvert.ToInt16(bytes, startIndex);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region ToIntD 的测试
        /// <summary>
        ///ToIntD 的测试
        ///</summary>
        [TestMethod()]
        public void ToIntDTest()
        {
            byte[] bytes = { 0x10, 0x10 };
            int expected = 1010;

            int actual = BitConvert.ToIntD(bytes);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region ToIntH 的测试
        /// <summary>
        ///ToIntH 的测试
        ///</summary>
        [TestMethod()]
        public void ToIntHTest()
        {
            byte[] bytes = { 0x0A };
            int expected = 10;

            int actual = BitConvert.ToIntH(bytes);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region ToLongInverse 的测试
        /// <summary>
        ///ToLongInverse 的测试
        ///</summary>
        [TestMethod()]
        public void ToLongInverseTest()
        {
            int startIndex = 0;
            long expected = 987654L;

            byte[] tmp = BitConverter.GetBytes(expected);
            byte[] bytes = { tmp[3], tmp[2], tmp[1], tmp[0] };

            long actual = BitConvert.ToLongInverse(bytes, startIndex);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region ToStringH 的测试
        /// <summary>
        ///ToStringH 的测试
        ///</summary>
        [TestMethod()]
        public void ToStringHTest()
        {
            string space = string.Empty;
            string expected = "0A0B0C0D0E0F";
            byte[] bytes = { 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f };

            string actual = BitConvert.ToStringH(bytes, space);
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region ToUInt16 的测试
        /// <summary>
        ///ToUInt16 的测试
        ///</summary>
        [TestMethod()]
        public void ToUInt16Test()
        {
            int startIndex = 0; //初始化为适当的值
            ushort expected = 16;
            byte[] bytes = BitConverter.GetBytes(expected);

            ushort actual = BitConvert.ToUInt16(bytes, startIndex);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion
    }
}