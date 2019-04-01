using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Base.Utils.Check
{
    /// <summary>
    /// 提供字节数组异或计算静态方法
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-08-10
    /// </remarks>
    public static class Xor
    {
        #region 将指定数目的字节从起始于特定偏移量的源数组进行异或计算
        /// <summary>
        /// 将指定数目的字节从起始于特定偏移量的源数组进行异或计算
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <returns>int值</returns>
        public static byte Byte(byte[] bytes, int offset, int count)
        {
            if (bytes == null ||
                bytes.Length <= 0 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 0)
                return 0;

            int xor = 0;
            byte[] temp = new byte[count];
            Buffer.BlockCopy(bytes, offset, temp, 0, count);

            for (int i = 0; i < temp.Length; i++)
            {
                xor = xor ^ temp[i];
            }
            return (byte)xor;
        }
        #endregion

        #region 将指定数目的字节从起始于特定偏移量的源数组进行异或校验
        /// <summary>
        /// 将指定数目的字节从起始于特定偏移量的源数组进行异或校验
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <param name="xor">异或值</param>
        /// <returns>校验结果布尔值</returns>
        public static bool CheckOR(byte[] bytes, int offset, int count, byte xor)
        {
            if (bytes == null ||
                bytes.Length <= 0 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 0)
                return false;

            return (xor == Xor.Byte(bytes, offset, count));
        }
        #endregion
    }
}
