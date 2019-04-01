using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Z.Base.Utils
{
    /// <summary>
    /// 将基础数据类型与字节数组相互转换
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class BitConvert
    {
        #region public static function

        #region 返回由字节数组中指定位置的两个字节转换来的 16 位无符号整数
        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 16 位无符号整数
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="startIndex">bytes内的起始位置</param>
        /// <returns>由两个字节构成、从 startIndex 开始的 16 位无符号整数</returns>
        public static ushort ToUInt16(this byte[] bytes, int startIndex = 0)
        {
            //System.ArgumentNullException bytes为null
            //System.ArgumentOutOfRangeException startIndex小于0
            //System.ArgumentOutOfRangeException
            //System.ArgumentException 
            if (bytes == null ||
                startIndex < 0 ||
                startIndex >= bytes.Length - 1)
                return 0;

            return BitConverter.ToUInt16(bytes, startIndex);
        }
        #endregion

        #region 返回由字节数组中指定位置的两个字节转换来的 16 位有符号整数
        /// <summary>
        /// 返回由字节数组中指定位置的两个字节转换来的 16 位有符号整数
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="startIndex">bytes内的起始位置</param>
        /// <returns>由两个字节构成、从 startIndex 开始的 16 位有符号整数</returns>
        public static int ToInt16(this byte[] bytes, int startIndex = 0)
        {
            //System.ArgumentNullException bytes为null
            //System.ArgumentOutOfRangeException startIndex小于0
            //System.ArgumentOutOfRangeException
            //System.ArgumentException 
            if (bytes == null ||
                startIndex < 0 ||
                startIndex >= bytes.Length - 1)
                return 0;

            return BitConverter.ToInt16(bytes, 0);
        }
        #endregion

        #region Long Inverse 返回由字节数组中指定位置的四个字节转换来的 32 位有符号整数
        /// <summary>
        /// Long Inverse 返回由字节数组中指定位置的四个字节转换来的 32 位有符号整数
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="startIndex">bytes内的起始位置</param>
        /// <returns>由四个字节构成、从 startIndex 开始的 32 位有符号整数</returns>
        public static long ToLongInverse(this byte[] bytes, int startIndex = 0)
        {
            //System.ArgumentNullException bytes为null
            //System.ArgumentOutOfRangeException startIndex小于0
            //System.ArgumentOutOfRangeException
            //System.ArgumentException 
            if (bytes == null ||
                startIndex < 0 ||
                startIndex >= bytes.Length - 3)
                return 0;
            //to inverse 
            byte[] temp = new byte[4];
            temp[0] = bytes[3 + startIndex];
            temp[1] = bytes[2 + startIndex];
            temp[2] = bytes[1 + startIndex];
            temp[3] = bytes[0 + startIndex];
            return BitConverter.ToInt32(temp, 0);
        }
        #endregion

        #region Float Inverse 返回由字节数组中指定位置的四个字节转换来的单精度浮点数
        /// <summary>
        /// Float Inverse 返回由字节数组中指定位置的四个字节转换来的单精度浮点数
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="startIndex">bytes内的起始位置</param>
        /// <returns>由四个字节构成、从 startIndex 开始的单精度浮点数</returns>
        public static float ToFloatInverse(this byte[] bytes, int startIndex = 0)
        {
            //System.ArgumentNullException bytes为null
            //System.ArgumentOutOfRangeException startIndex小于0
            //System.ArgumentOutOfRangeException
            //System.ArgumentException 
            if (bytes == null ||
                startIndex < 0 ||
                startIndex >= bytes.Length - 3)
                return 0f;
            //to inverse 
            byte[] temp = new byte[4];
            temp[0] = bytes[3 + startIndex];
            temp[1] = bytes[2 + startIndex];
            temp[2] = bytes[1 + startIndex];
            temp[3] = bytes[0 + startIndex];
            return BitConverter.ToSingle(temp, 0);
        }
        #endregion

        #region Float 1032 返回由字节数组中指定位置的四个字节转换来的单精度浮点数
        /// <summary>
        /// Float 1032 返回由字节数组中指定位置的四个字节转换来的单精度浮点数
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>由四个字节构成、从 startIndex 开始的单精度浮点数</returns>
        public static float ToFloat1032(this byte[] bytes, int startIndex = 0)
        {
            //System.ArgumentNullException bytes为null
            //System.ArgumentOutOfRangeException startIndex小于0
            //System.ArgumentOutOfRangeException
            //System.ArgumentException 
            if (bytes == null ||
                startIndex < 0 ||
                startIndex >= bytes.Length - 3)
                return 0f;
            //to 1 0 3 2 
            byte[] temp = new byte[4];
            temp[0] = bytes[1 + startIndex];
            temp[1] = bytes[0 + startIndex];
            temp[2] = bytes[3 + startIndex];
            temp[3] = bytes[2 + startIndex];
            return BitConverter.ToSingle(temp, 0);
        }
        #endregion

        #region 返回由字节数组中指定位置的四个字节转换来的单精度浮点数
        /// <summary>
        /// 返回由字节数组中指定位置的四个字节转换来的单精度浮点数
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>由四个字节构成、从 startIndex 开始的单精度浮点数</returns>
        public static float ToFloat(this byte[] bytes, int startIndex = 0)
        {
            //System.ArgumentNullException bytes为null
            //System.ArgumentOutOfRangeException startIndex小于0
            //System.ArgumentOutOfRangeException
            //System.ArgumentException
            if (bytes == null ||
                startIndex < 0 ||
                startIndex >= bytes.Length - 3)
                return 0f;

            return BitConverter.ToSingle(bytes, startIndex);
        }
        #endregion

        #region 将byte[]转换的十六进制格式的字符串，按十六进制转换为等效的 32 位有符号整数
        /// <summary>
        /// 将byte[]转换的十六进制格式的字符串，按十六进制转换为等效的 32 位有符号整数
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>正常返回按十六进制转换为等效的 32 位有符号整数，否则返回-1</returns>
        public static int ToIntH(this byte[] bytes)
        {
            if (bytes == null)
                return -1;
            string str = bytes.ToStringH();
            if (string.IsNullOrEmpty(str))
                return -1;
            if (!str.IsHexadecimal())
                return -1;
            return int.Parse(str, NumberStyles.AllowHexSpecifier);
        }
        #endregion

        #region 将byte[]转换的十六进制格式的字符串，按十进制转换为等效的 32 位有符号整数
        /// <summary>
        /// 将byte[]转换的十六进制格式的字符串，按十进制转换为等效的 32 位有符号整数
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>正常返回按十进制转换为等效的 32 位有符号整数，否则返回-1</returns>
        public static int ToIntD(this byte[] bytes)
        {
            if (bytes == null)
                return -1;
            string str = bytes.ToStringH();
            if (string.IsNullOrEmpty(str))
                return -1;
            if (!str.IsNumber())
                return -1;
            return int.Parse(str);
        }
        #endregion

        #region 使用十六进制格式将byte[]转换为 间隔字符串space 的字符串表示形式
        /// <summary>
        /// 使用十六进制格式将byte[]转换为 间隔字符串space 的字符串表示形式
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="space">间隔字符串</param>
        /// <returns>带间隔字符串的十六进制格式的字符串</returns>
        public static string ToStringH(this byte[] bytes, string space = "")
        {
            if (bytes == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("X2") + space);
            }
            return sb.ToString();
        }
        #endregion

        #endregion
    }
}
