using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Base.Log
{
    /// <summary>
    /// 管理静态的日志文本的队列
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-05-24
    /// </remarks>
    public static class LogQueue
    {
        #region private static var
        /// <summary>
        /// 文本队列
        /// </summary>
        private static Queue<string> queue = new Queue<string>();
        #endregion

        #region private static properties
        /// <summary>
        /// 获取队列空间值
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

        #region 移除并返回位于队列开始处的文本
        /// <summary>
        /// 移除并返回位于队列开始处的文本
        /// </summary>
        /// <returns>返回队列开始处的文本，无信息返回string.Empty</returns>
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

        #region 将文本添加到队列结尾处
        /// <summary>
        /// 将文本添加到队列结尾处
        /// </summary>
        /// <param name="txt">文本</param>
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

        #region 将应用程序执行发生的错误对象文本添加到队列结尾处
        /// <summary>
        /// 将应用程序执行错误文本添加到队列结尾处
        /// </summary>
        /// <param name="name">错误名称</param>
        /// <param name="ex">应用程序执行发生的错误对象</param>
        public static void WriteLine(string name, Exception ex)
        {
            lock (LogQueue.queue)
            {
                if (LogQueue.queue.Count >= LogQueue.Size)
                    LogQueue.queue.Dequeue();
                LogQueue.queue.Enqueue(LogFormat.ErrorStr(name, ex));
            }
        }
        #endregion

        #endregion
    }
}
