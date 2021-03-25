using System;

namespace FreeID.Abstraction.FpMethod
{
    /// <summary>
    /// 定义一些用于FP使用的方法
    /// </summary>
    public static class FpMethod
    {
        #region 常量

        /// <summary>
        /// 8长度的byte，内容全为0
        /// </summary>
        public static Func<byte[]> zeroBytes_8 = () => new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// 下划线
        /// </summary>
        public static Func<string> underline = () => "_";

        #endregion 常量

        #region 替换

        /// <summary>
        /// 从左开始替换
        /// </summary>
        /// <remarks>
        /// 用于字节操作时补位使用，第一个参数为样本数组,第二个参数为需要补位的数组.从左开始替换。<para></para>
        /// 如: 11->1000->1100
        /// </remarks>
        public static Func<Func<byte[]>, Func<byte[], byte[]>> leftReplace = sampleBytes => sourceBytes =>
         {
             byte[] sample = sampleBytes();

             byte[] result = new byte[sample.Length];
             sample.CopyTo(result, 0);//创建目标数组的副本，以免影响样本数组

             //从左开始替换
             for (int i = 0 ; i < sourceBytes.Length ; i++)
             {
                 result[i] = sourceBytes[i];
             }

             return result;
         };

        /// <summary>
        /// 从右开始替换
        /// </summary>
        /// <remarks>
        /// 用于字节操作时补位使用，第一个参数为样本数组,第二个参数为需要补位的数组.从左开始替换。<para></para>
        /// 如: 11->1000->1100
        /// </remarks>
        public static Func<Func<byte[]>, Func<byte[], byte[]>> rightReplace = sampleBytes => sourceBytes =>
        {
            byte[] sample = sampleBytes();

            byte[] result = new byte[sample.Length];
            sample.CopyTo(result, 0);//创建目标数组的副本，以免影响样本数组

            //从右开始替换
            for (int i = 1 ; i < sourceBytes.Length + 1 ; i++)
            {
                result[^i] = sourceBytes[^i];
            }

            return result;
        };

        #endregion 替换
    }
}