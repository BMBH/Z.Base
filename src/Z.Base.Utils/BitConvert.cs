using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Z.Base.Utils
{
    /// <summary>
    /// 字节与其他类型转换
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class BitConvert
    {
        #region public static function

        #region ushort
        /// <summary>
        /// ushort
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

        #region Int16
        /// <summary>
        /// Int16
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

        #region Long Inverse
        /// <summary>
        /// Long Inverse
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

        #region Float Inverse
        /// <summary>
        /// Float Inverse
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

        #region Float 1032
        /// <summary>
        /// Float 1032
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

        #region Float
        /// <summary>
        /// Float
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

        #region 十六进制Int
        /// <summary>
        /// 十六进制Int
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>正常返回十六进制int值，否则返回0</returns>
        public static int ToIntH(this byte[] bytes)
        {
            if (bytes == null)
                return 0;
            string str = bytes.ToStringH();
            if (string.IsNullOrEmpty(str))
                return 0;
            if (!str.IsHexadecimal())
                return 0;
            return int.Parse(str, NumberStyles.AllowHexSpecifier);
        }
        #endregion

        #region 十进制Int
        /// <summary>
        /// 十进制Int
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>正常返回十进制int值，否则返回0</returns>
        public static int ToIntD(this byte[] bytes)
        {
            if (bytes == null)
                return 0;
            string str = bytes.ToStringH();
            if (string.IsNullOrEmpty(str))
                return 0;
            if (!str.IsNumber())
                return 0;
            return int.Parse(str);
        }
        #endregion

        #region 十六进制字符串
        /// <summary>
        /// 十六进制字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="space">字符串间隔</param>
        /// <returns>带间隔十六进制字符串</returns>
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
