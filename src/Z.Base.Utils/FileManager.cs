using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Z.Base.Utils
{
    /// <summary>
    /// 文件管理类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class FileManager
    {
        #region public static function

        #region 创建基目录文件
        /// <summary>
        /// 创建基目录文件
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="fileFullName">文件名</param>
        /// <returns>创建成功返回文件路径</returns>
        public static string CreateBaseFile(string dir, string fileFullName)
        {
            if (string.IsNullOrEmpty(dir) ||
                string.IsNullOrEmpty(fileFullName) ||
                !RuleManager.IsNumberOrLetter(dir))
                return string.Empty;

            string baseDir = FileManager.CreateBaseDirectory(dir);
            string filePath = Path.Combine(baseDir, fileFullName);
            FileManager.CreateFile(filePath);
            return filePath;
        }
        #endregion

        #region 创建基目录文件
        /// <summary>
        /// 创建基目录文件
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="fileName">文件名</param>
        /// <param name="postfix">文件后缀</param>
        /// <returns>创建成功返回文件路径</returns>
        public static string CreateBaseFile(string dir, string fileName, string postfix)
        {
            if (string.IsNullOrEmpty(dir) ||
                string.IsNullOrEmpty(fileName) ||
                string.IsNullOrEmpty(postfix) ||
                !RuleManager.IsNumberOrLetter(dir) ||
                !RuleManager.IsNumberOrLetter(postfix))
                return string.Empty;

            string fileFullName = string.Format("{0}.{1}", fileName, postfix);
            return FileManager.CreateBaseFile(dir, fileFullName);
        }
        #endregion

        #region 创建基目录目录
        /// <summary>
        /// 创建基目录目录
        /// </summary>
        /// <param name="dirName">目录名称</param>
        /// <returns>目录路径</returns>
        public static string CreateBaseDirectory(string dirName)
        {
            if (string.IsNullOrEmpty(dirName) ||
                !RuleManager.IsNumberOrLetter(dirName))
                return string.Empty;

            string dir = Path.Combine(FileManager.BaseDirectory(), dirName);
            bool result = FileManager.CreateDirectory(dir);
            return dir;
        }
        #endregion

        #region 创建目录
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="directory">目录路径</param>
        /// <returns>已存在返回false;创建成功返回true</returns>
        public static bool CreateDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                return false;
            }
            else
            {
                Directory.CreateDirectory(directory);
                return true;
            }
        }
        #endregion

        #region 创建文件
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>已存在返回false;创建成功返回true</returns>
        public static bool CreateFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return false;
            }
            else
            {
                string dir = FileManager.HigherDir(filePath);
                FileManager.CreateDirectory(dir);
                FileStream NewFile = new FileStream(filePath, FileMode.CreateNew);
                NewFile.Close();
                NewFile.Dispose();
                return true;
            }
        }
        #endregion

        #region 应用程序基目录
        /// <summary>
        /// 应用程序基目录
        /// </summary>
        /// <returns>返回基目录，不带符号“\”</returns>
        public static string BaseDirectory()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (HttpContext.Current == null)//WindowsForms应用
            {
                //return path.Substring(0, path.LastIndexOf("\\"));
                return path.TrimEnd('\\');//经单元测试，此处错误 by北冥冰皇 since 2018-12-13
            }
            else//Web应用
            {
                return path + @"bin";
            }
        }
        #endregion

        #endregion

        #region private static function

        #region 上一级目录
        /// <summary>
        /// 上一级目录
        /// </summary>  
        /// <param name="dir">路径</param>
        /// <returns></returns>
        private static string HigherDir(string dir)
        {
            string highdir = "";//上一级目录
            dir = dir.TrimEnd('\\');//去掉尾部/符号
            int index = dir.LastIndexOf(@"\");//计算最后一次/符号位置
            if (index > -1)
                highdir = dir.Substring(0, index);
            return highdir;
        }
        #endregion 

        #endregion
    }
}
