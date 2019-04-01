using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z.Base.Utils.Check
{
    /// <summary>
    /// 提供字节数组CRC16计算方法
    /// </summary>
    /// <remarks>
    /// 作者：北冥冰皇
    /// 创建日期：2018-08-10
    /// </remarks>
    public static class CRC16
    {

        #region public static function

        #region 将指定数目的字节从起始于特定偏移量的源数组进行CRC16计算，获取UInt值(低位)
        /// <summary>
        /// 将指定数目的字节从起始于特定偏移量的源数组进行CRC16计算，获取UInt值(低位)
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <returns>UInt16值，否则抛出异常</returns>
        public static UInt16 UIntLo(byte[] bytes, int offset, int count)
        {
            if (bytes == null ||
                bytes.Length <= 0 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 0)
                return 0;

            CRC crc = new CRC();

            byte[] temp = new byte[count];
            Buffer.BlockCopy(bytes, offset, temp, 0, count);

            return crc.Crc16(temp, temp.Length);
        }
        #endregion

        #region 将指定数目的字节从起始于特定偏移量的源数组进行CRC16计算，获取UInt值(高位)
        /// <summary>
        /// 将指定数目的字节从起始于特定偏移量的源数组进行CRC16计算，获取UInt值(高位)
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <returns>UInt16值，否则抛出异常</returns>
        public static UInt16 UIntHi(byte[] bytes, int offset, int count)
        {
            if (bytes == null ||
                bytes.Length <= 0 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 0)
                return 0;

            byte[] temp = new byte[count];
            Buffer.BlockCopy(bytes, offset, temp, 0, count);

            return CRC16.Crc16(temp);
        }
        #endregion

        #region 将指定数目的字节从起始于特定偏移量的源数组进行CRC16计算，获取结果字节数组(低位)
        /// <summary>
        /// 将指定数目的字节从起始于特定偏移量的源数组进行CRC16计算，获取结果字节数组(低位)
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <returns>正常返回长度2的字节数组，否则返回null，异常抛出处理</returns>
        public static byte[] BytesLo(byte[] bytes, int offset, int count)
        {
            if (bytes == null ||
                bytes.Length <= 0 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 0)
                return null;

            UInt16 crc16 = CRC16.UIntLo(bytes, offset, count);
            return BitConverter.GetBytes(crc16);
        }
        #endregion

        #region 将指定数目的字节从起始于特定偏移量的源数组进行CRC16计算，获取结果字节数组(高位)
        /// <summary>
        /// 将指定数目的字节从起始于特定偏移量的源数组进行CRC16计算，获取结果字节数组(高位)
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <returns>正常返回长度2的字节数组，否则返回null，异常抛出处理</returns>
        public static byte[] BytesHi(byte[] bytes, int offset, int count)
        {
            if (bytes == null ||
                bytes.Length <= 0 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 0)
                return null;

            UInt16 crc16 = CRC16.UIntHi(bytes, offset, count);
            return BitConverter.GetBytes(crc16);
        }
        #endregion

        #region 将指定数目的字节从起始于特定偏移量的源数组进行CRC16 循环冗余校验(低位)
        /// <summary>
        /// 将指定数目的字节从起始于特定偏移量的源数组进行CRC16 循环冗余校验(低位)
        /// Cyclic Redundancy Check
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <returns>正常返回校验结果，否则返回false</returns>
        public static bool CheckLo(byte[] bytes, int offset, int count)
        {
            if (bytes == null ||
                bytes.Length <= 2 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 2)
                return false;

            byte[] crc16s = CRC16.BytesLo(bytes, offset, count - 2);
            if (crc16s == null ||
                crc16s.Length < 2)
                return false;

            return (crc16s[0] == bytes[offset + count - 2]
                && crc16s[1] == bytes[offset + count - 1]);
        }
        #endregion

        #region 将指定数目的字节从起始于特定偏移量的源数组进行CRC16 循环冗余校验(高位)
        /// <summary>
        /// 将指定数目的字节从起始于特定偏移量的源数组进行CRC16 循环冗余校验(高位)
        /// Cyclic Redundancy Check
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="offset">从零开始的字节偏移量</param>
        /// <param name="count">计算字节个数</param>
        /// <returns>正常返回校验结果，否则返回false</returns>
        public static bool CheckHi(byte[] bytes, int offset, int count)
        {
            if (bytes == null ||
                bytes.Length <= 2 ||
                bytes.Length < offset + count ||
                offset < 0 || count <= 2)
                return false;

            byte[] crc16s = CRC16.BytesHi(bytes, offset, count - 2);
            if (crc16s == null ||
                crc16s.Length < 2)
                return false;

            return (crc16s[0] == bytes[offset + count - 2]
                && crc16s[1] == bytes[offset + count - 1]);
        }
        #endregion

        #endregion

        #region private class
        /// <summary>
        /// Cyclic Redundancy Check
        /// 循环冗余校验
        /// </summary>
        /// <remarks>
        /// 作者：北冥冰皇
        /// 修改日期：2018-05-24
        /// </remarks>
        private class CRC
        {
            #region private var

            #region Table Of CRC Values for high-order byte
            /* Table Of CRC Values for high-order byte */
            private Byte[] auchCRCHi = {
                             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
                             0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
                             0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
                             0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
                             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81,
                             0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
                             0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
                             0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
                             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
                             0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
                             0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
                             0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
                             0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
                             0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
                             0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
                             0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
                             0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
                             0x40
                                 };
            #endregion

            #region Table of CRC values for low-order byte
            /* Table of CRC values for low-order byte */
            private Byte[] auchCRCLo = {
                                             0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4,
                                             0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
                                             0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD,
                                             0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
                                             0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7,
                                             0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
                                             0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE,
                                             0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
                                             0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2,
                                             0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
                                             0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB,
                                             0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
                                             0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91,
                                             0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
                                             0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88,
                                             0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
                                             0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80,
                                             0x40
                                         };
            #endregion

            #endregion

            #region public function

            #region  将指定的byte[]按指定的长度usDataLen进行CRC16计算，获取UInt16值(低位)
            /// <summary>
            /// 将指定的byte[]按指定的长度usDataLen进行CRC16计算，获取UInt16值(低位)
            /// </summary>
            /// <param name="puchMsg"></param>
            /// <param name="usDataLen"></param>
            /// <returns></returns>
            public UInt16 Crc16(Byte[] puchMsg, int usDataLen)
            {
                byte uchCRCHi = 0xFF; // high byte of CRC initialized
                byte uchCRCLo = 0xFF; // low byte of CRC initialized
                UInt16 uIndex = 0; // will index into CRC lookup table
                int i = 0;
                while (usDataLen-- > 0) // Pass through message buffer
                {
                    uIndex = Convert.ToUInt16(uchCRCHi ^ puchMsg[i]); // calculate the CRC
                    uchCRCHi = Convert.ToByte(uchCRCLo ^ auchCRCHi[uIndex]);
                    uchCRCLo = auchCRCLo[uIndex];
                    i++;
                }
                UInt16 t = Convert.ToUInt16((uchCRCLo) << 8);
                t |= Convert.ToUInt16(uchCRCHi);
                return t;
            }
            #endregion

            #endregion
        }
        #endregion

        #region private static function
        /// <summary>
        /// 将指定的byte[]进行CRC16计算(高位)
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static UInt16 Crc16(byte[] bytes)
        {
            UInt16 CRC16HiLo = 0xFFFF;//装16位寄存器
            UInt16 CHL = 0xA001;//多项式

            for (int i = 0; i < bytes.Length; i++)//循环校验串
            {
                CRC16HiLo = (UInt16)((CRC16HiLo >> 8) ^ bytes[i]);//被校验字节与寄存器高位字节进行异或
                for (int j = 0; j < 8; j++)//循环右移8位
                {
                    if ((CRC16HiLo & 1) == 1)//如果LSB为1，则与多项式码进行异或
                    {
                        CRC16HiLo = (UInt16)(CRC16HiLo >> 1);
                        CRC16HiLo = (UInt16)(CRC16HiLo ^ CHL);
                    }
                    else
                    {
                        CRC16HiLo = (UInt16)(CRC16HiLo >> 1);
                    }
                }
            }
            return CRC16HiLo;
        }
        #endregion
    }
}
