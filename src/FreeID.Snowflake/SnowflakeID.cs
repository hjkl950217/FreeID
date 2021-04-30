namespace FreeID.Snowflake
{
    /// <summary>
    /// 雪花ID
    /// </summary>
    public sealed partial class SnowflakeID
    {
        //这个文件包含 实现雪花ID核心编码，定义和重载在 SnowflakeID.Common.cs

        /// <summary>
        /// 从<see cref="ulong"/>的雪花ID中构造<see cref="SnowflakeID"/>对象
        /// </summary>
        /// <param name="snowflakeID">已有的<see cref="ulong"/>型雪花ID</param>
        /// <param name="option">雪花ID配置</param>
        public SnowflakeID(ulong snowflakeID, SnowflakeIDOption option)
        {
            //todo 从现有的雪花ID中分裂出4部分

            this.ResultID = snowflakeID;
            this.Option = option;
        }
    }
}