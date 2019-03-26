using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Base.Utils
{
    /// <summary>
    /// 类型转换类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class Parser
    {

        #region private const
        /// <summary>
        /// 默认数值格式
        /// </summary>
        private const string value_format = "0.00";
        /// <summary>
        /// 默认时间格式
        /// </summary>
        private const string date_format = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// 默认时间戳常量
        /// </summary>
        private const string time_stamp = "1970-01-01 00:00:00";
        #endregion

        #region public static function

        #region object转换为float扩展方法
        /// <summary>
        /// object转换为float
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>正常返回float，否则返回0f</returns>
        public static float TryToFloat(this object value, string format = value_format)
        {
            return float.Parse(Parser.TryToFloatStr(value, format));
        }
        #endregion

        #region object转换为float字符串扩展方法
        /// <summary>
        /// object转换为float字符串
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>正常返回float字符串，否则返回format字符串</returns>
        public static string TryToFloatStr(this object value, string format = value_format)
        {
            format = Parser.HandleFormat(format);//重置格式参数
            if (!Parser.IsValue(value))
                return format;
            float temp = 0f;
            bool result = float.TryParse(value.ToString().Trim(), out temp);
            if (result)
                return temp.ToString(format);
            return format;
        }
        #endregion

        #region object转换为double扩展方法
        /// <summary>
        /// object转换为double
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>正常返回double，否则返回0</returns>
        public static double TryToDouble(this object value, string format = value_format)
        {
            return double.Parse(Parser.TryToDoubleStr(value, format));
        }
        #endregion

        #region object转换为double字符串扩展方法
        /// <summary>
        /// object转换为double字符串
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>正常返回double字符串，否则返回format字符串</returns>
        public static string TryToDoubleStr(this object value, string format = value_format)
        {
            format = Parser.HandleFormat(format);//重置格式参数
            if (!Parser.IsValue(value))
                return format;
            double temp = 0;
            bool result = double.TryParse(value.ToString().Trim(), out temp);
            if (result)
                return temp.ToString(format);
            return format;
        }
        #endregion

        #region object转换为decimal扩展方法
        /// <summary>
        /// object转换为decimal
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>正常返回double，否则返回0</returns>
        public static decimal TryToDecimal(this object value, string format = value_format)
        {
            return decimal.Parse(Parser.TryToDecimalStr(value, format));
        }
        #endregion

        #region object转换为decimal字符串扩展方法
        /// <summary>
        /// object转换为decimal字符串
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>正常返回decimal字符串，否则返回format字符串</returns>
        public static string TryToDecimalStr(this object value, string format = value_format)
        {
            format = Parser.HandleFormat(format);//重置格式参数
            if (!Parser.IsValue(value))
                return format;
            decimal temp = 0;
            bool result = decimal.TryParse(value.ToString().Trim(), out temp);
            if (result)
                return temp.ToString(format);
            return format;
        }
        #endregion

        #region object转换为int扩展方法
        /// <summary>
        /// object转换为int
        /// </summary>
        /// <param name="value">object对象</param>
        /// <returns>正常返回小数位忽略int值，否则返回0</returns>
        public static int TryToInt(this object value)
        {
            int temp = 0;
            if (!IsValue(value))
                return temp;
            if (!value.ToString().Trim().Contains("."))
            {
                bool result = int.TryParse(value.ToString(), out temp);
                if (result)
                    return temp;
            }
            else
            {
                double d = TryToDouble(value.ToString(), null);
                temp = (int)d;//double类型丢失精度
            }
            return temp;
        }
        #endregion

        #region object转换为int字符串扩展方法
        /// <summary>
        /// object转换为int字符串
        /// </summary>
        /// <param name="value">object字符串</param>
        /// <returns>正常返回小数位忽略int字符串，否则返回"0"</returns>
        public static string TryToIntStr(this object value)
        {
            return TryToInt(value).ToString();
        }
        #endregion

        #region object转换为DateTime扩展方法
        /// <summary>
        /// object转换为DateTime
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="date_format">日期格式(可选参数)</param>
        /// <returns>正常按格式返回DateTime,否则返回默认时间戳</returns>
        public static DateTime TryToDatetime(this object value, string date_format = date_format)
        {
            DateTime date = DateTime.Now;
            date_format = Parser.HandleDateFormat(date_format);
            if (!Parser.IsValue(value))
                value = Parser.time_stamp;
            bool result = DateTime.TryParse(value.ToString(), out date);
            if (!result)
                date = DateTime.Parse(Parser.time_stamp);
            return DateTime.Parse(date.ToString(date_format));
        }
        #endregion

        #region object转换为DateTime字符串扩展方法
        /// <summary>
        /// object转换为DateTime字符串
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="date_format">日期格式(可选参数)</param>
        /// <returns>正常按格式返回DateTime字符串,否则返回默认时间戳字符串</returns>
        public static string TryToDatetimeStr(this object value, string date_format = date_format)
        {
            return TryToDatetime(value, date_format).ToString(date_format);
        }
        #endregion

        #endregion

        #region private function

        #region value参数判断
        /// <summary>
        /// value参数判断
        /// </summary>
        /// <param name="value">object对象</param>
        /// <returns>object可用返回true，否则返回false</returns>
        private static bool IsValue(object value)
        {
            if (value == null)
                return false;
            if (string.IsNullOrEmpty(value.ToString()))
                return false;
            return true;
        }
        #endregion

        #region format参数处理
        /// <summary>
        /// format参数处理
        /// </summary>
        /// <param name="format">数值格式</param>
        /// <returns>传参正常返回参数，否则返回默认format</returns>
        private static string HandleFormat(string format)
        {
            if (string.IsNullOrEmpty(format))
                return Parser.value_format;
            return format;
        }
        #endregion

        #region date format参数处理
        /// <summary>
        /// date format参数处理
        /// </summary>
        /// <param name="format">数值格式</param>
        /// <returns>传参正常返回参数，否则返回默认date format</returns>
        private static string HandleDateFormat(string format)
        {
            if (string.IsNullOrEmpty(format))
                return Parser.date_format;
            return format;
        }
        #endregion

        #endregion
    }
}
