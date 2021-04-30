namespace FreeID.Snowflake
{
    /// <summary>
    /// 雪花ID常量
    /// </summary>
    public static class SnowflakeIDConst
    {
        #region 雪花ID常量

        /// <summary>
        /// 顺序号-预留位
        /// </summary>
        public const byte Order_Reserve = 0;

        /// <summary>
        /// 顺序号-时间戳
        /// </summary>
        public const byte Order_TimeStamp = 1;

        /// <summary>
        /// 顺序号-工作机器ID
        /// </summary>
        public const byte Order_WorkingMachineID = 2;

        /// <summary>
        /// 顺序号-序列号
        /// </summary>
        public const byte Order_SerialNumber = 3;

        /// <summary>
        /// 长度-预留位
        /// </summary>
        public const byte Length_Reserve = 1;

        /// <summary>
        /// 长度-时间戳
        /// </summary>
        public const byte Length_TimeStamp = 41;

        /// <summary>
        /// 长度-工作机器ID
        /// </summary>
        public const byte Length_WorkingMachineID = 10;

        /// <summary>
        /// 长度-序列号
        /// </summary>
        public const byte Length_SerialNumber = 12;

        /// <summary>
        /// 长度-雪花ID最大二进制长度
        /// </summary>
        public const byte Key_Length = 64;

        /// <summary>
        /// 个数-雪花ID最大配置数
        /// </summary>
        public const byte Key_Count = 4;

        /// <summary>
        /// 空雪花ID
        /// </summary>
        public const ulong NullID = 0L;

        #endregion 雪花ID常量

        #region 文本信息常量

        public const string Lbl_Reserve = "预留位";
        public const string Lbl_TimeStamp = "时间戳";
        public const string Lbl_WorkingMachineID = "机器ID";
        public const string Lbl_SerialNumber = "序列号";

        /// <summary>
        /// 文本信息常量
        /// </summary>
        public static class Msg
        {
            public static string InitKeyLgenthError = $"参数错误,所有配置长度相加必须等于{SnowflakeIDConst.Key_Length}";

            public const string InitKeyCountError = "参数错误,请检查！配置项目一共有4个";
        }

        #endregion 文本信息常量
    }
}