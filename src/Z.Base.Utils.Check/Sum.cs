using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Base.Utils.Check
{
    /// <summary>
    /// 校验和计算
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-08-10
    /// </remarks>
    public static class Sum
    {
        #region 校验和计算Byte
        /// <summary>
        /// 校验和计算Byte
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <returns>字节值</returns>
        public static byte Byte(byte[] bytes, int offset, int count)
        {
            if (bytes == null ||
                bytes.Length <= 0 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 0)
                return 0;

            byte[] temp = new byte[count];
            Buffer.BlockCopy(bytes, offset, temp, 0, count);

            int checksum = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                checksum += temp[i];
                if (checksum > 256)
                    checksum = checksum - 256;
            }
            return (byte)checksum;
        }
        #endregion

        #region 校验和校验
        /// <summary>
        /// 校验和校验
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <param name="sum">和值</param>
        /// <returns>校验结果布尔值</returns>
        public static bool CheckByte(byte[] bytes, int offset, int count, byte sum)
        {
            if (bytes == null ||
                bytes.Length <= 0 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 0)
                return false;

            return (sum == Sum.Byte(bytes, offset, count));
        }
        #endregion
    }
}
