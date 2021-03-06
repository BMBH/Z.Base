﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Z.Base.Utils
{
    public static class StringManager
    {
        #region 指示指定的字符串是否空引用或空字符串
        /// <summary>
        /// 指示指定的字符串是否空引用或空字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
                return true;
            return false;
        }
        #endregion

        #region 指示指定的字符串是否空引用或空字符串或问号/叹号
        /// <summary>
        /// 指示指定的字符串是否空引用或空字符串或问号/叹号
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsEmptyOrQuesEx(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;
            str = str.Trim();
            if (string.IsNullOrEmpty(str))
                return true;
            if ("?".Equals(str))
                return true;
            if ("!".Equals(str))
                return true;
            return false;
        }
        #endregion

        #region 指示指定的字符串是否数值字符串
        /// <summary>
        /// 指示指定的字符串是否数值字符串
        /// <para><remarks>无需判断字符串是否为空</remarks></para>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsNumeric(this string str)
        {
            return !str.IsEmpty() && Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$");
        }
        #endregion

        #region 指示指定的字符串是否整型字符串
        /// <summary>
        /// 指示指定的字符串是否整型字符串
        /// <para><remarks>无需判断字符串是否为空</remarks></para>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsNumber(this string str)
        {
            return !str.IsEmpty() && Regex.IsMatch(str, @"^[+-]?\d*$");
        }
        #endregion

        #region 指示指定的字符串是否无符号数值字符串
        /// <summary>
        /// 指示指定的字符串是否无符号数值字符串
        /// <para><remarks>无需判断字符串是否为空</remarks></para>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsUnsign(this string str)
        {
            return !str.IsEmpty() && Regex.IsMatch(str, @"^\d*[.]?\d*$");
        }
        #endregion

        #region 指示指定的字符串是否手机号字符串
        /// <summary>
        /// 指示指定的字符串是否手机号字符串
        /// <para><remarks>无需判断字符串是否为空</remarks></para>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsTel(this string str)
        {
            return !str.IsEmpty() && Regex.IsMatch(str, @"\d{3}-\d{8}|\d{4}-\d{7}");
        }
        #endregion

        #region 指定从字符串开始具有长度的字符串
        /// <summary>
        /// 指定从字符串开始具有长度的字符串
        /// <para><remarks>无需判断字符串是否为空</remarks></para>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="length">长度值</param>
        /// <returns></returns>
        public static string Left(this string str, int length)
        {
            if (str.IsEmpty() || length <= 0)
                return string.Empty;
            return str.Length >= length ? str.Substring(0, length) : string.Empty;
        }
        #endregion

        #region 指定从字符串末尾向开始具有长度的字符串
        /// <summary>
        /// 指定从字符串末尾向开始具有长度的字符串
        /// <para><remarks>无需判断字符串是否为空</remarks></para>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="length">长度值</param>
        /// <returns></returns>
        public static string Right(this string str, int length)
        {
            if (str.IsEmpty() || length <= 0)
                return string.Empty;

            return str.Length >= length ? str.Substring(str.Length - length, length) : string.Empty;
        }
        #endregion

        #region 字符串从指定的字符位置开始且具有指定的长度
        /// <summary>
        /// 字符串从指定的字符位置开始且具有指定的长度
        /// <para><remarks>无需判断字符串是否为空</remarks></para>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="startIndex">起始位置</param>
        /// <param name="length">字符串长度</param>
        /// <returns></returns>
        public static string Mid(this string str, int startIndex, int length)
        {
            if (str.IsEmpty() || startIndex < 0 || length <= 0)
                return string.Empty;

            return str.Length >= startIndex + length ? str.Substring(startIndex, length) : string.Empty;
        }
        #endregion

        #region 字符串从指定的字符位置开始
        /// <summary>
        /// 字符串从指定的字符位置开始
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="startIndex">起始位置</param>
        /// <returns></returns>
        public static string Mid(this string str, int startIndex)
        {
            if (str.IsEmpty() || startIndex < 0)
                return string.Empty;

            return str.Substring(startIndex);
        }
        #endregion

        #region 指示指定的字符串是否由数字或字母组成
        /// <summary>
        ///  指示指定的字符串是否由数字或字母组成
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsNumberOrLetter(this string str)
        {
            return !str.IsEmpty() && Regex.IsMatch(str, @"^[A-Za-z0-9]+$");
        }
        #endregion

        #region 指示指定的字符串是否由字母组成
        /// <summary>
        /// 指示指定的字符串是否由字母组成
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsLetter(this string str)
        {
            return !str.IsEmpty() && Regex.IsMatch(str, @"^[A-Za-z]+$");
        }
        #endregion

        #region 指示指定的字符串是否由十六进制字符组成
        /// <summary>
        /// 指示指定的字符串是否由十六进制字符组成
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>true/false</returns>
        public static bool IsHexadecimal(this string str)
        {
            return !str.IsEmpty() && Regex.IsMatch(str, @"^[A-Fa-f0-9]+$");
        }
        #endregion
    }
}
