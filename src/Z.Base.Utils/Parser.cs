using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Base.Utils
{
    /// <summary>
    /// 将基础数据类型与 object 相互转换
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class Parser
    {

        #region private const
        /// <summary>
        /// 默认数值格式文本
        /// </summary>
        private const string value_format = "0.00";
        /// <summary>
        /// 默认时间格式文本
        /// </summary>
        private const string date_format = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// 默认时间戳常量文本
        /// </summary>
        private const string time_stamp = "1970-01-01 00:00:00";
        #endregion

        #region public static function

        #region 使用指定的格式，将 object 转换为它的等效单精度浮点数字
        /// <summary>
        /// 使用指定的格式，将 object 转换为它的等效单精度浮点数字
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="format">单精度浮点型数值格式文本(可选参数)</param>
        /// <returns>正常返回单精度浮点型值，否则返回0f</returns>
        public static float TryToFloat(this object value, string format = value_format)
        {
            return float.Parse(Parser.TryToFloatStr(value, format));
        }
        #endregion

        #region 使用指定的格式，将 object 转换为单精度浮点型的等效字符串表示形式
        /// <summary>
        /// 使用指定的格式，将 object 转换为单精度浮点型的等效字符串表示形式
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="format">单精度浮点型数值格式文本(可选参数)</param>
        /// <returns>正常返回单精度浮点型的文本，否则返回单精度浮点型数值格式文本</returns>
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

        #region 使用指定的格式，将 object 转换为它的等效双精度浮点数字
        /// <summary>
        /// 使用指定的格式，将 object 转换为它的等效双精度浮点数字
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="format">双精度浮点型数值格式文本(可选参数)</param>
        /// <returns>正常返回双精度浮点型值，否则返回0f</returns>
        public static double TryToDouble(this object value, string format = value_format)
        {
            return double.Parse(Parser.TryToDoubleStr(value, format));
        }
        #endregion

        #region 使用指定的格式，将 object 转换为双精度浮点型的等效字符串表示形式
        /// <summary>
        /// 使用指定的格式，将 object 转换为双精度浮点型的等效字符串表示形式
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="format">双精度浮点型数值格式文本(可选参数)</param>
        /// <returns>正常返回双精度浮点型的文本，否则返回双精度浮点型数值格式文本</returns>
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

        #region 使用指定的格式，将 object 转换为十进制数
        /// <summary>
        /// 使用指定的格式，将 object 转换为十进制数
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="format">十进制数值格式文本(可选参数)</param>
        /// <returns>正常返回十进制数，否则返回0</returns>
        public static decimal TryToDecimal(this object value, string format = value_format)
        {
            return decimal.Parse(Parser.TryToDecimalStr(value, format));
        }
        #endregion

        #region 使用指定的格式，将 object 转换为十进制数的等效字符串表示形式
        /// <summary>
        /// 使用指定的格式，将 object 转换为十进制数的等效字符串表示形式
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="format">十进制数值格式文本(可选参数)</param>
        /// <returns>正常返回十进制数文本，否则返回十进制数值格式文本</returns>
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

        #region 将 object 转换为它的等效 32 位有符号整数
        /// <summary>
        /// 将 object 转换为它的等效 32 位有符号整数
        /// </summary>
        /// <param name="value">object实例</param>
        /// <returns>正常返回32 位有符号整数，否则返回0</returns>
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

        #region 将 object 转换为它的等效 32 位有符号整数的字符串形式
        /// <summary>
        /// 将 object 转换为它的等效 32 位有符号整数的字符串形式
        /// </summary>
        /// <param name="value">object实例</param>
        /// <returns>正常返回32 位有符号整数的字符串形式，否则返回"0"</returns>
        public static string TryToIntStr(this object value)
        {
            return TryToInt(value).ToString();
        }
        #endregion

        #region 将 string 转换为它的指定枚举 枚举值
        /// <summary>
        /// 将 string 转换为它的指定枚举 枚举值
        /// </summary>
        /// <typeparam name="TEnum">泛型结构体</typeparam>
        /// <param name="value">字符串值</param>
        /// <returns>正常返回 枚举值，否则返回默认枚举值</returns>
        public static TEnum TryToEnum<TEnum>(this string value) where TEnum : struct
        {
            TEnum temp = default(TEnum);
            bool result = Enum.TryParse<TEnum>(value, out temp);
            if (result)
            {
                bool isDefined = Enum.IsDefined(typeof(TEnum), temp);
                if (isDefined)
                    return temp;
            }
            return temp;
        }
        #endregion

        #region 将 int 转换为它的指定枚举 枚举值
        /// <summary>
        /// 将 int 转换为它的指定枚举 枚举值
        /// </summary>
        /// <typeparam name="TEnum">泛型结构体</typeparam>
        /// <param name="value">整型值</param>
        /// <returns>正常返回 枚举值，否则返回默认枚举值</returns>
        public static TEnum TryToEnum<TEnum>(this int value) where TEnum : struct
        {
            TEnum temp = default(TEnum);
            bool isDefined = Enum.IsDefined(typeof(TEnum), value);
            if (isDefined)
                return (TEnum)Enum.ToObject(typeof(TEnum), value);
            return temp;
        }
        #endregion

        #region 将 TEnum 转换为它的等效 字符串形式
        /// <summary>
        /// 将 TEnum 转换为它的等效 字符串形式
        /// </summary>
        /// <param name="value">泛型结构体</param>
        /// <returns>正常返回 字符串形式，否则返回null</returns>
        public static string TryToEnumStr<TEnum>(this TEnum value) where TEnum : struct
        {
            return Enum.GetName(value.GetType(), value);
        }
        #endregion
            
        #region 使用指定的格式，将 object 转换为 DateTime
        /// <summary>
        /// 使用指定的格式，将 object 转换为 DateTime
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="date_format">日期格式文本(可选参数)</param>
        /// <returns>正常返回DateTime,否则返回默认时间戳</returns>
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

        #region 使用指定的格式，将 object 转换为 DateTime 等效的字符串表示形式
        /// <summary>
        /// 使用指定的格式，将 object 转换为 DateTime 等效的字符串表示形式
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="date_format">日期格式文本(可选参数)</param>
        /// <returns>正常返回 DateTime 等效的字符串表示形式,否则返回默认时间戳字符串</returns>
        public static string TryToDatetimeStr(this object value, string date_format = date_format)
        {
            return TryToDatetime(value, date_format).ToString(date_format);
        }
        #endregion

        #endregion

        #region private function

        #region 指示指定的 value 是否可用
        /// <summary>
        /// 指示指定的 value 是否可用
        /// </summary>
        /// <param name="value">object实例</param>
        /// <returns>可用返回true，否则返回false</returns>
        private static bool IsValue(object value)
        {
            if (value == null)
                return false;
            if (string.IsNullOrEmpty(value.ToString()))
                return false;
            return true;
        }
        #endregion

        #region 处理指定的 format
        /// <summary>
        ///  处理指定的 format 
        /// </summary>
        /// <param name="format">格式文本</param>
        /// <returns>正常返回参数，否则返回默认value_format</returns>
        private static string HandleFormat(string format)
        {
            if (string.IsNullOrEmpty(format))
                return Parser.value_format;
            return format;
        }
        #endregion

        #region 处理指定的日期 format
        /// <summary>
        /// 处理指定的日期 format
        /// </summary>
        /// <param name="format">格式文本</param>
        /// <returns>正常返回参数，否则返回默认date_format</returns>
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
