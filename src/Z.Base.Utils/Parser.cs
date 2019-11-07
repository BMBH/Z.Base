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

        #region 使用指定的格式，将 string 转换为它的等效单精度浮点数字
        /// <summary>
        /// 使用指定的格式，将 string 转换为它的等效单精度浮点数字
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>单精度浮点型值</returns>
        public static float TryToFloat(this string value, string format = value_format)
        {
            format = HandleFormat(format);//重置格式参数
            if (value.IsEmpty())
                value = format;

            float temp = 0f;
            bool result = float.TryParse(value.Trim(), out temp);
            if (result)
                return temp;

            return default(float);
        }
        #endregion

        #region 使用指定的格式，将 string 转换为单精度浮点型的字符串表示形式
        /// <summary>
        /// 使用指定的格式，将 string 转换为单精度浮点型的字符串表示形式
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>字符串</returns>
        public static string TryToFloatStr(this string value, string format = value_format)
        {
            format = HandleFormat(format);//重置格式参数
            if (value.IsEmpty())
                value = format;

            float temp = value.TryToFloat(format);
            return temp.ToString(format);
        }
        #endregion

        #region 使用指定的格式，将单精度浮点数字转换为等效字符串表示形式
        /// <summary>
        /// 使用指定的格式，将单精度浮点数字转换为等效字符串表示形式
        /// </summary>
        /// <param name="value">单精度浮点数字</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>字符串</returns>
        public static string TryToFloatStr(this float value, string format = value_format)
        {
            format = HandleFormat(format);
            return value.ToString(format);
        }
        #endregion

        #region 使用指定的格式，将 string 转换为它的等效双精度浮点数字
        /// <summary>
        /// 使用指定的格式，将 string 转换为它的等效双精度浮点数字
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>双精度浮点型值</returns>
        public static double TryToDouble(this string value, string format = value_format)
        {
            format = HandleFormat(format);//重置格式参数
            if (value.IsEmpty())
                value = format;

            double temp = 0;
            bool result = double.TryParse(value.Trim(), out temp);
            if (result)
                return temp;

            return default(double);
        }
        #endregion

        #region 使用指定的格式，将 string 转换为双精度浮点型的字符串表示形式
        /// <summary>
        /// 使用指定的格式，将 string 转换为双精度浮点型的字符串表示形式
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>字符串</returns>
        public static string TryToDoubleStr(this string value, string format = value_format)
        {
            format = HandleFormat(format);//重置格式参数
            if (value.IsEmpty())
                value = format;

            double temp = value.TryToDouble(format);
            return temp.ToString(format);
        }
        #endregion

        #region 使用指定的格式，将双精度浮点型值转换为等效的字符串表示形式
        /// <summary>
        /// 使用指定的格式，将双精度浮点型值转换为等效的字符串表示形式
        /// </summary>
        /// <param name="value">双精度浮点型值</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>字符串</returns>
        public static string TryToDoubleStr(this double value, string format = value_format)
        {
            format = HandleFormat(format);//重置格式参数
            return value.ToString(format);
        }
        #endregion

        #region 使用指定的格式，将 string 转换为十进制数
        /// <summary>
        /// 使用指定的格式，将 string 转换为十进制数
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>十进制数</returns>
        public static decimal TryToDecimal(this string value, string format = value_format)
        {
            format = HandleFormat(format);//重置格式参数
            if (value.IsEmpty())
                value = format;

            decimal temp = 0;
            bool result = decimal.TryParse(value.Trim(), out temp);
            if (result)
                return temp;

            return default(decimal);
        }
        #endregion

        #region 使用指定的格式，将 string 转换为十进制数的表示形式
        /// <summary>
        /// 使用指定的格式，将 string 转换为十进制数的表示形式
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>十进制数文本</returns>
        public static string TryToDecimalStr(this string value, string format = value_format)
        {
            format = HandleFormat(format);//重置格式参数
            if (value.IsEmpty())
                value = format;

            decimal temp = value.TryToDecimal(format);
            return temp.ToString(format);
        }
        #endregion

        #region 使用指定的格式，将十进制数转换为等效字符串形式
        /// <summary>
        /// 使用指定的格式，将十进制数转换为等效字符串形式
        /// </summary>
        /// <param name="value">十进制数</param>
        /// <param name="format">数值格式(可选参数)</param>
        /// <returns>十进制数文本</returns>
        public static string TryToDecimalStr(this decimal value, string format = value_format)
        {
            format = HandleFormat(format);//重置格式参数
            return value.ToString(format);
        }
        #endregion

        #region 将 string 转换为它的等效32位有符号整数
        /// <summary>
        /// 将 string 转换为它的等效32位有符号整数
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>32位有符号整数</returns>
        public static int TryToInt(this string value)
        {
            int temp = default(int);
            if (value.IsEmpty())
                return temp;
            if (!value.Trim().Contains("."))
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

        #region 将 string 转换为它的指定枚举 枚举值
        /// <summary>
        /// 将 string 转换为它的指定枚举 枚举值
        /// </summary>
        /// <typeparam name="TEnum">泛型结构体</typeparam>
        /// <param name="value">字符串值</param>
        /// <returns>正常返回 枚举值，否则返回默认枚举值</returns>
        public static TEnum TryToEnum<TEnum>(this string value, TEnum defaultVal = default(TEnum)) where TEnum : struct
        {
            TEnum temp = defaultVal;
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
        public static TEnum TryToEnum<TEnum>(this int value, TEnum defaultVal = default(TEnum)) where TEnum : struct
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

        #region 使用指定的格式，将 string 转换为 DateTime
        /// <summary>
        /// 使用指定的格式，将 string 转换为 DateTime
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="date_format">日期格式文本(可选参数)</param>
        /// <returns>DateTime</returns>
        public static DateTime TryToDatetime(this string value, string date_format = date_format)
        {
            DateTime date = DateTime.Now;
            date_format = HandleDateFormat(date_format);
            if (value.IsEmpty())
                value = time_stamp;

            if (value.Length > date_format.Length)
                value = value.Left(date_format.Length);

            bool result = DateTime.TryParse(value, out date);
            if (result)
                return date;
            return default(DateTime);
        }
        #endregion

        #region 使用指定的格式，将 string 转换为 DateTime?
        /// <summary>
        /// 使用指定的格式，将 string 转换为 DateTime?
        /// </summary>
        /// <param name="value">object实例</param>
        /// <param name="date_format">日期格式文本(可选参数)</param>
        /// <returns>正常返回DateTime,否则返回NULL</returns>
        public static DateTime? TryToDateTimeNull(this string value, string date_format = date_format)
        {
            if (value.IsEmpty())
                return null;

            DateTime date = DateTime.Now;
            date_format = HandleDateFormat(date_format);

            bool result = DateTime.TryParse(value, out date);
            if (result)
                return DateTime.Parse(date.ToString(date_format));

            return null;
        }
        #endregion

        #endregion

        #region private function

        #region 处理指定的 format
        /// <summary>
        ///  处理指定的 format 
        /// </summary>
        /// <param name="format">格式文本</param>
        /// <returns>正常返回参数，否则返回默认value_format</returns>
        private static string HandleFormat(string format)
        {
            if (string.IsNullOrEmpty(format))
                return value_format;
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
                return date_format;
            return format;
        }
        #endregion

        #endregion
    }
}
