using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Z.Base.Utils
{
    /// <summary>
    /// 规则管理类
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-12-13
    /// </remarks>
    public static class RuleManager
    {
        #region public static function

        #region 判断是否数字或字母
        /// <summary>
        /// 判断是否数字或字母
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

        #region 判断是否数字
        /// <summary>
        /// 判断是否数字
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

        #region 判断是否字母
        /// <summary>
        /// 判断是否字母
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

        #region 判断是否十六进制字符
        /// <summary>
        /// 判断是否十六进制字符
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
