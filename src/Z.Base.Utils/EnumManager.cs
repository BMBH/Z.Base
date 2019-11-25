#region AUTHOR
/*******************************
**  AUTHOR:     ZHANGYP
**    TIME:     2019/11/25 9:59:09
** VERSION:     V1.0.0
**    GUID:     11463c84-fd1c-460b-a8c5-156fa1c57c62
*******************************/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Z.Base.Utils
{
    /// <summary>
    /// 枚举类型与基础数据类型转换
    /// </summary>
    public static class EnumManager
    {
        #region 将 string 转换为它的指定TEnum 枚举值
        /// <summary>
        /// 将 string 转换为它的指定TEnum 枚举值
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

        #region 将 int 转换为它的指定TEnum 枚举值
        /// <summary>
        /// 将 int 转换为它的指定TEnum 枚举值
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

        #region 获取 TEnum的Description文本
        /// <summary>
        /// 获取 TEnum的Description文本
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
        #endregion
    }
}
