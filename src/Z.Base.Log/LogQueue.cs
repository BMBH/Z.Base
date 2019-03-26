using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Base.Log
{
    /// <summary>
    /// 日志管理器
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-24
    /// </remarks>
    public static class LogQueue
    {
        #region private static var
        /// <summary>
        /// 控制台字符串队列
        /// </summary>
        private static Queue<string> queue = new Queue<string>();
        #endregion

        #region private static properties
        /// <summary>
        /// 队列空间
        /// </summary>
        private static int Size
        {
            get
            {
                int size = Utils.ConfigManager.IntVal("queue", "logger.config");
                if (size < 10)
                    return 10;
                return size;
            }
        }
        #endregion

        #region public static function

        #region 信息字符串出列
        /// <summary>
        /// 信息字符串出列
        /// </summary>
        /// <returns>返回队列中信息，无信息返回string.Empty</returns>
        public static string ReadLine()
        {
            lock (LogQueue.queue)
            {
                if (LogQueue.queue.Count > 0)
                    return LogQueue.queue.Dequeue();
                return string.Empty;
            }
        }
        #endregion

        #region 信息字符串入列
        /// <summary>
        /// 信息字符串入列
        /// </summary>
        /// <param name="txt">信息文本</param>
        public static void WriteLine(string txt)
        {
            lock (LogQueue.queue)
            {
                if (LogQueue.queue.Count >= LogQueue.Size)
                    LogQueue.queue.Dequeue();
                LogQueue.queue.Enqueue(LogFormat.InfoStr(txt));
            }
        }
        #endregion

        #region 异常字符串入列
        /// <summary>
        /// 异常字符串入列
        /// </summary>
        /// <param name="txt">信息文本</param>
        /// <param name="ex">异常对象</param>
        public static void WriteLine(string txt, Exception ex)
        {
            lock (LogQueue.queue)
            {
                if (LogQueue.queue.Count >= LogQueue.Size)
                    LogQueue.queue.Dequeue();
                LogQueue.queue.Enqueue(LogFormat.ErrorStr(txt, ex));
            }
        }
        #endregion

        #endregion
    }
}
