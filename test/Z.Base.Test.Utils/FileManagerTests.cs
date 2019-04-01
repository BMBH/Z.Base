using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.Base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Z.Base.Test.Utils
{
    /// <summary>
    ///这是 FileManagerTest 的测试类，旨在
    ///包含所有 FileManagerTest 单元测试
    ///</summary>
    ///<remarks>
    ///作者：北冥冰皇
    ///创建日期：2018-12-13
    ///</remarks>
    [TestClass()]
    public class FileManagerTests
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

        #region BaseDirectory 的测试
        /// <summary>
        ///BaseDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void BaseDirectoryTest()
        {
            //string expected = @"E:\Work\Demo\ZBase.Utils\ZBase.Utils.Test\bin\Debug";
            string expected = AppDomain.CurrentDomain.BaseDirectory;

            string actual = FileManager.BaseDirectory();
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region CreateBaseDirectory 的测试
        /// <summary>
        ///CreateBaseDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void CreateBaseDirectoryTest()
        {
            string dirName = "test";
            string expected = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dirName);

            string actual = FileManager.CreateBaseDirectory(dirName);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region CreateBaseFile 的测试
        /// <summary>
        ///CreateBaseFile 的测试
        ///</summary>
        [TestMethod()]
        public void CreateBaseFileTest()
        {
            string dir = "test";
            string fileFullName = "test.test";
            string expected = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir, fileFullName);

            string actual = FileManager.CreateBaseFile(dir, fileFullName);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region CreateBaseFile 的测试
        /// <summary>
        ///CreateBaseFile 的测试
        ///</summary>
        [TestMethod()]
        public void CreateBaseFileTest1()
        {
            string dir = "test1";
            string fileName = "test1";
            string postfix = "test1";
            string expected = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir,
                string.Format("{0}.{1}", fileName, postfix));

            string actual = FileManager.CreateBaseFile(dir, fileName, postfix);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region CreateDirectory 的测试
        /// <summary>
        ///CreateDirectory 的测试
        ///</summary>
        [TestMethod()]
        public void CreateDirectoryTest()
        {
            string directory = @"E:\test2";
            bool expected = true;

            bool actual = FileManager.CreateDirectory(directory);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion

        #region CreateFile 的测试
        /// <summary>
        ///CreateFile 的测试
        ///</summary>
        [TestMethod()]
        public void CreateFileTest()
        {
            string filePath = @"E:\test\test.test";
            bool expected = true;

            bool actual = FileManager.CreateFile(filePath);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
        #endregion
    }
}