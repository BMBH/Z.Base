using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Z.Base.Log
{
    /// <summary>
    /// Log4Net 日志框架类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-24
    /// 依赖：log4net.config日志配置文件
    /// </remarks>
    public static class Log4Net
    {
        #region private static var
        /// <summary>
        /// 获取一个日志记录器;
        /// </summary>
        private static log4net.ILog logs = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region public static function

        #region 初始化log4net
        /// <summary>
        /// 初始化log4net
        /// </summary>
        public static void InitLog4Net()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(logCfg);
        }
        #endregion

        #region Error级别日志
        /// <summary>
        /// Error级别日志
        /// </summary>
        /// <param name="msg">信息</param>
        public static void Error(string msg)
        {
            logs.Error(msg);
        }
        #endregion

        #region Error级别日志
        /// <summary>
        /// Error级别日志
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="ex">异常对象</param>
        public static void Error(string msg, Exception ex)
        {
            logs.Error(msg, ex);
        }
        #endregion

        #endregion
    }
}
