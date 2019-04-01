using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Z.Base.Utils
{
    /// <summary>
    /// 提供判断数字、字母、十六进制的静态方法
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class RuleManager
    {
        #region public static function

        #region 指示指定的 str 是否由数字或字母组成
        /// <summary>
        ///  指示指定的 str 是否由数字或字母组成
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>正确返回true，错误返回false</returns>
        public static bool IsNumberOrLetter(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            try
            {
                Regex reg = new Regex(@"^[A-Za-z0-9]+$");
                return reg.IsMatch(str);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 指示指定的 str 是否由数字组成
        /// <summary>
        /// 指示指定的 str 是否由数字组成
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>正确返回true，错误返回false</returns>
        public static bool IsNumber(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            try
            {
                Regex reg = new Regex(@"^[0-9]+$");
                return reg.IsMatch(str);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 指示指定的 str 是否由字母组成
        /// <summary>
        /// 指示指定的 str 是否由字母组成
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>正确返回true，错误返回false</returns>
        public static bool IsLetter(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            try
            {
                Regex reg = new Regex(@"^[A-Za-z]+$");
                return reg.IsMatch(str);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 指示指定的 str 是否由十六进制字符组成
        /// <summary>
        /// 指示指定的 str 是否由十六进制字符组成
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>正确返回true，错误返回false</returns>
        public static bool IsHexadecimal(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            try
            {
                Regex reg = new Regex(@"^[A-Fa-f0-9]+$");
                return reg.IsMatch(str);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #endregion
    }
}
