using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Z.Base.Log
{

    /// <summary>
    /// 提供按等级记录日志的静态方法
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
        /// 日志等级
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
        /// 日志文件互斥锁对象
        /// </summary>
        private static object log_lock = new object();

        #region private const
        /// <summary>
        /// 默认文件夹文本，如果配置文件获取错误则使用该常量
        /// </summary>
        private const string DEFAULT_DIRECTORY = "Log";
        /// <summary>
        /// 默认时间格式文本，如果配置文件获取错误则使用该常量
        /// </summary>
        private const string DEFAULT_DATE_FORMAT = "yyyy-MM-dd";
        /// <summary>
        /// 默认文件名后缀文本，如果配置文件获取错误则使用该常量
        /// </summary>
        private const string DEFAULT_POSTFIX = "txt";
        #endregion

        #region private static properties

        #region 获取配置文件夹文本
        /// <summary>
        /// 获取配置文件夹文本
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

        #region 获取配置时间格式文本
        /// <summary>
        /// 获取配置时间格式文本
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

        #region 获取配置文件后缀文本
        /// <summary>
        /// 获取配置文件后缀文本
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

        #region 获取配置日志等级
        /// <summary>
        /// 获取配置日志等级
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

        #region 按ALL级别记录日志
        /// <summary>
        /// 按ALL级别记录日志
        /// </summary>
        /// <param name="text">日志文本</param>
        /// <param name="file">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool All(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.ALL);
        }
        #endregion

        #region 按DEBUG级别记录日志
        /// <summary>
        /// 按DEBUG级别记录日志
        /// </summary>
        /// <param name="text">日志文本</param>
        /// <param name="file">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="files">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Debug(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.DEBUG);
        }
        #endregion

        #region 按INFO级别记录日志
        /// <summary>
        /// 按INFO级别记录日志
        /// </summary>
        /// <param name="text">日志文本</param>
        /// <param name="file">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Info(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.INFO);
        }
        #endregion

        #region 按WARN级别记录日志
        /// <summary>
        /// 按WARN级别记录日志
        /// </summary>
        /// <param name="text">日志文本</param>
        /// <param name="file">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Warn(string text, string file, string dir)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.WARN);
        }
        #endregion

        #region 按ERROR级别记录日志
        /// <summary>
        /// 按ERROR级别记录日志
        /// </summary>
        /// <param name="text">日志文本</param>
        /// <param name="file">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Error(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.ERROR);
        }
        #endregion

        #region 按FATAL级别记录日志
        /// <summary>
        /// 按FATAL级别记录日志
        /// </summary>
        /// <param name="text">日志文本</param>
        /// <param name="file">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>返回写入结果，否则返回false</returns>
        public static bool Fatal(string text, string file = null, string dir = null)
        {
            return Logger.LogByLevel(text, file, dir, LogLevel.FATAL);
        }
        #endregion

        #region 按None级别记录日志
        /// <summary>
        /// 按None级别记录日志
        /// </summary>
        /// <param name="text">日志文本</param>
        /// <param name="name">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="files">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>默认true</returns>
        public static bool None(string text, string file = null, string dir = null)
        {
            return true;
        }
        #endregion

        #endregion

        #region private static function

        #region 按 name 获取日志文件名称
        /// <summary>
        /// 按 name 获取日志文件名称
        /// </summary>
        /// <param name="name">文件名称文本</param>
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

        #region 按 fileName 和 dir 创建日志文件
        /// <summary>
        /// 按 fileName 和 dir 创建日志文件
        /// </summary>
        /// <param name="fileName">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <returns>创建成功返回路径字符串，否则返回null</returns>
        private static string CreateLog(string fileName, string dir)
        {
            try
            {
                if (string.IsNullOrEmpty(dir))
                    dir = Logger.DefaultDir;//文件夹
                string logName = Logger.LogName(fileName);//组合文件名
                string postfix = Logger.Postfix;//文件名后缀

                if (!Utils.StringManager.IsNumberOrLetter(dir) || !Utils.StringManager.IsNumberOrLetter(postfix))
                    return null;//判断名称是否合法

                return Utils.FileManager.CreateBaseFile(dir, logName, postfix);//创建文件，返回文件路径
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 向 filePath 路径写入日志文本
        /// <summary>
        /// 向 filePath 路径写入日志文本
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

        #region 按 LogLevel 向相关路径中记录日志
        /// <summary>
        /// 按 LogLevel 向相关路径中记录日志
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="file">文件名文本:可以为空，默认使用日期格式</param>
        /// <param name="dir">文件夹名称:可以为空，默认使用配置文件设置</param>
        /// <param name="level">日志等级</param>
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
