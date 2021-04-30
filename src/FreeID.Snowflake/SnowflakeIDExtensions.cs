namespace FreeID.Snowflake
{
    /// <summary>
    /// 雪花ID扩展
    /// </summary>
    public static class SnowflakeIDExtensions
    {
        /// <summary>
        /// 从<paramref name="snowflakeID"/>中获取<see cref="ulong"/>型的雪花ID
        /// </summary>
        /// <param name="snowflakeID">雪花ID对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static ulong GetIDOrDefault(
            this SnowflakeID? snowflakeID,
            ulong defaultValue = SnowflakeIDConst.NullID)
        {
            return snowflakeID?.ResultID ?? defaultValue;
        }
    }
}