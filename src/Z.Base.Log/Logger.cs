using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Z.Base.Log
{

    /// <summary>
    /// 日志类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// 依赖：logger.config日志配置文件
    /// </remarks>
    public static class Logger
    {
        #region  private enum 
        /// <summary>
        /// 日志级别
        /// 由低到高：ALL,DEBUG,INFO,WARN,ERROR,FATAL,None
        /// </summary>
        private enum LogLevel
        {
            /// <summary>
            /// 全部级别
            /// </summary>
            ALL = 0,
            /// <summary>
            /// 调试级别
            /// </summary>
            DEBUG = 1,
            /// <summary>
            /// 信息级别
            /// </summary>
            INFO = 2,
            /// <summary>
            /// 告警级别
            /// </summary>
            WARN = 3,
            /// <summary>
            /// 错误级别
            /// </summary>
            ERROR = 4,
            /// <summary>
            /// 严重级别
            /// </summary>
            FATAL = 5,
            /// <summary>
            /// 关闭级别
            /// </summary>
            None = 6
        }
        #endregion

        /// <summary>
        /// 日志锁
        /// </summary>
        private static object log_lock = new object();

        #region private const
        /// <summary>
        /// 默认文件夹，如果配置文件获取错误则使用该常量
        /// </summary>
        private const string DEFAULT_DIRECTORY = "Log";
        /// <summary>
        /// 默认时间格式，如果配置文件获取错误则使用该常量
        /// </summary>
        private const string DEFAULT_DATE_FORMAT = "yyyy-MM-dd";
        /// <summary>
        /// 默认文件名后缀，如果配置文件获取错误则使用该常量
        /// </summary>
        private const string DEFAULT_POSTFIX = "txt";
        #endregion

        #region private static properties

        #region 配置文件夹
        /// <summary>
        /// 配置文件夹
        /// </summary>
        private static string DefaultDir
        {
            get
            {
                string dir = Utils.ConfigManager.StringVal("directory", "logger.config");
                if (string.IsNullOrEmpty(dir))
                    return Logger.DEFAULT_DIRECTORY;
                return dir;
            }
        }
        #endregion

        #region 配置时间格式
        /// <summary>
        /// 配置时间格式
        /// </summary>
        private static string DateFormat
        {
            get
            {
                string format = Utils.ConfigManager.StringVal("format", "logger.config");
                if (string.IsNullOrEmpty(format))
                    return Logger.DEFAULT_DATE_FORMAT;
                return format;
            }
        }
        #endregion

        #region 配置文件后缀
        /// <summary>
        /// 配置文件后缀
        /// </summary>
        private static string Postfix
        {
            get
            {
                string postfix = Utils.ConfigManager.StringVal("postfix", "logger.config");
                if (string.IsNullOrEmpty(postfix))
                    return Logger.DEFAULT_POSTFIX;
                return postfix;
            }
        }
        #endregion

        #region 配置日志级别
        /// <summary>
        /// 配置日志级别
        /// </summary>
        private static LogLevel Level
        {
            get
            {
                int level = Utils.ConfigManager.IntVal("level", "logger.config");
                if (level > 6 || level < 0)
                    return LogLevel.ALL;
                return (LogLevel)level;
            }
        }
        #endregion

        #endregion

        #region public static function

        #region ALL级别日志
        /// <summary>
        /// ALL级别日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="file">文件名:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool All(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.ALL);
        }
        #endregion

        #region DEBUG级别日志
        /// <summary>
        /// DEBUG级别日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="file">文件名:可以为空，默认使用日期格式</param>
        /// <param name="files">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Debug(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.DEBUG);
        }
        #endregion

        #region INFO级别日志
        /// <summary>
        /// INFO级别日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="file">文件名:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Info(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.INFO);
        }
        #endregion

        #region WARN级别日志
        /// <summary>
        /// WARN级别日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="file">文件名:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Warn(string text, string file, string dir)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.WARN);
        }
        #endregion

        #region ERROR级别日志
        /// <summary>
        /// ERROR级别日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="file">文件名:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Error(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.ERROR);
        }
        #endregion

        #region FATAL级别日志
        /// <summary>
        /// FATAL级别日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="file">文件名:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Fatal(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.FATAL);
        }
        #endregion

        #region None级别日志
        /// <summary>
        /// None级别日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="name">文件名:可以为空，默认使用日期格式</param>
        /// <param name="files">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>默认true</returns>
        public static bool None(string text, string file = null, string dir = null)
        {
            return true;
        }
        #endregion

        #endregion

        #region private static function

        #region 日志文件名称
        /// <summary>
        /// 日志文件名称
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <returns>正常返回组合文件名称，如果参数异常或组合异常则返回日期格式名称</returns>
        private static string LogName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return DateTime.Now.ToString(Logger.DateFormat);
                return string.Format("{0} {1}", name, DateTime.Now.ToString(Logger.DateFormat));
            }
            catch
            {
                return DateTime.Now.ToString(Logger.DateFormat);
            }
        }
        #endregion

        #region 创建日志文件
        /// <summary>
        /// 创建日志文件
        /// </summary>
        /// <param name="fileName">文件名:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>创建成功返回字符串，否则返回null</returns>
        private static string CreateLog(string fileName, string dir)
        {
            try
            {
                if (string.IsNullOrEmpty(dir))
                    dir = Logger.DefaultDir;//文件夹
                string logName = Logger.LogName(fileName);//组合文件名
                string postfix = Logger.Postfix;//文件名后缀

                if (!Utils.RuleManager.IsNumberOrLetter(dir) || !Utils.RuleManager.IsNumberOrLetter(postfix))
                    return null;//判断名称是否合法

                return Utils.FileManager.CreateBaseFile(dir, logName, postfix);//创建文件，返回文件路径
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 写入日志
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="filePath">日志文件</param>
        /// <param name="text">文本</param>
        /// <returns>写入成功返回true，否则返回false</returns>
        private static bool WriteLine(string filePath, string text)
        {
            lock (log_lock)
            {
                StreamWriter SW = File.AppendText(filePath);
                try
                {
                    SW.WriteLine(text);
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    SW.Flush();
                    SW.Close();
                    SW.Dispose();
                }
            }
        }
        #endregion

        #region 根据日志级别写入日志
        /// <summary>
        /// 根据日志级别写入日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="file">文件名:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <param name="level">日志级别</param>
        /// <returns>返回写入结果，否则返回false</returns>
        private static bool LogByLevel(string text, string file, string dir, LogLevel level)
        {
            try
            {
                if (string.IsNullOrEmpty(text) || Level > level)
                    return false;//日志级别低则返回false

                string filePath = Logger.CreateLog(file, dir);
                if (string.IsNullOrEmpty(filePath))
                    return false;//判断创建是否成功
                return Logger.WriteLine(filePath, text);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #endregion


    }
}
