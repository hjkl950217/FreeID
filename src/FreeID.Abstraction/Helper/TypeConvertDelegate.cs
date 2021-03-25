using System.Text;
using static FreeID.Abstraction.FpMethod.FpMethod;

namespace System
{
    public static partial class TypeConvertDelegate2
    {
        //以后迁移到cktools中

        #region 基础转换

        #region To Long

        public static Func<string, long> stringToLong = long.Parse;
        public static Func<byte[], long> bytesToLong = bytes => BitConverter.ToInt64(bytes, 0);

        public static Func<byte[]?, long> tryBytesToLong = bytes =>
         {
             return bytes switch
             {
                 null => 0L,
                 byte[] _ when bytes.Length == 8 => bytesToLong(bytes),
                 byte[] _ when bytes.Length > 8 => bytesToLong(bytes[0..8]),
                 byte[] _ when bytes.Length < 8 => bytesToLong(leftReplace(zeroBytes_8)(bytes)),
                 _ => 0L,
             };
         };

        #endregion To Long

        #region To Ulong

        public static Func<string, ulong> stringToULong = System.Convert.ToUInt64;
        public static Func<byte[], ulong> bytesToULong = bytes => BitConverter.ToUInt64(bytes, 0);

        public static Func<byte[]?, ulong> tryBytesToULong = bytes =>
        {
            return bytes switch
            {
                null => 0L,
                byte[] _ when bytes.Length == 8 => bytesToULong(bytes),
                byte[] _ when bytes.Length > 8 => bytesToULong(bytes[0..8]),
                byte[] _ when bytes.Length < 8 => bytesToULong(leftReplace(zeroBytes_8)(bytes)),
                _ => 0L,
            };
        };

        #endregion To Ulong

        #region To Bytes

        public static Func<long, byte[]> longToBytes = BitConverter.GetBytes;
        public static Func<ulong, byte[]> ulongToBytes = BitConverter.GetBytes;

        #endregion To Bytes

        #region To Format String

        #region Byte to String

        /// <summary>
        /// 将byte转换为对应进制的字符串
        /// </summary>
        internal static Func<int, Func<byte, string>> byteToBaseString = tobase => b => Convert.ToString(b, tobase);

        /// <summary>
        /// 将byte转换为2进制的字符串
        /// </summary>
        public static Func<byte, string> byteToBitString = byteToBaseString(2);

        /// <summary>
        /// 将byte转换为8进制的字符串
        /// </summary>
        public static Func<byte, string> byteToOctalString = byteToBaseString(8);

        /// <summary>
        /// 将byte转换为10进制的字符串
        /// </summary>
        public static Func<byte, string> byteToDecimalString = byteToBaseString(10);

        /// <summary>
        /// 将byte转换为16进制的字符串
        /// </summary>
        public static Func<byte, string> byteToHexString = byteToBaseString(16);

        #endregion Byte to String

        #endregion To Format String

        #endregion 基础转换

        #region 组合转换

        #region To Format String

        /// <summary>
        /// 格式化byte数组成字符串<para></para>
        /// 第一个参数:分隔符<para></para>
        /// 第二个参数:格式化方法<para></para>
        /// 返回:转换方法
        /// </summary>
        public static Func<
            Func<string>, Func<
            Func<int, Func<byte, string>>,
            Func<byte[], string>>> bytesToString = symbol => format => bytes =>
            {
                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0 ; i < bytes.Length ; i++)
                {
                    stringBuilder.Append(format(bytes[i]));
                }
                return stringBuilder.ToString();
            };

        #endregion To Format String

        #endregion 组合转换
    }
}