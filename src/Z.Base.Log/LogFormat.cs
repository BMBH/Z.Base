using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.Base.Utils;

namespace Z.Base.Log
{
    /// <summary>
    /// 提供应用程序执行错误日志、信息日志、传输字节日志获取文本的静态方法
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class LogFormat
    {
        #region 按应用程序执行发生的错误获取日志文本
        /// <summary>
        /// 按应用程序执行发生的错误获取日志文本
        /// </summary>
        /// <param name="name">错误名称</param>
        /// <param name="ex">应用程序执行发生的错误对象</param>
        /// <returns>日志文本</returns>
        public static string ErrorStr(string name, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            if (name != null)
            {
                sb.Append("\r\n" + name + ":");
            }
            if (ex != null)
            {
                sb.Append("\r\n" + "<ErrorType>" + ex.GetType().FullName + "<ErrorType>");
                sb.Append("\r\n" + "<OccurTime>" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "<OccurTime>");
                sb.Append("\r\n" + "<ErrorMessage>" + ex.Message + "<ErrorMessage>");
                sb.Append("\r\n" + "<StackTrace>");
                sb.Append("\r\n" + ex.StackTrace);
                sb.Append("\r\n" + "<StackTrace>");
                sb.Append("\r\n" + "<ErrorSource>" + ex.Source + "<ErrorSource>");
            }
            return sb.ToString();
            //return ex.StackTrace;
        }
        #endregion

        #region 按信息获取日志文本
        /// <summary>
        /// 信息日志文本
        /// </summary>
        /// <param name="txt">信息文本</param>
        /// <returns>日志文本</returns>
        public static string InfoStr(string txt)
        {
            if (txt == null)
                return string.Empty;
            return "<" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ">:" + txt;
        }
        #endregion

        #region 按传输的字节数组型获取日志文本
        /// <summary>
        /// 按传输的字节数组型获取日志文本
        /// </summary>
        /// <param name="cmd">命令名称</param>
        /// <param name="bytes">字节数组</param>
        /// <returns>日志文本</returns>
        public static string CommStr(string cmd, byte[] bytes)
        {
            if (cmd == null)
                return string.Empty;
            return cmd + "\r\n"
                + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n"
                + BitConvert.ToStringH(bytes, " ") + "\r\n";
        }
        #endregion
    }
}
