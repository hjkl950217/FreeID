#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

using System;
using System.Collections.Generic;

namespace FreeID.Snowflake
{
    /// <summary>
    /// 雪花ID配置对象
    /// </summary>
    public partial class SnowflakeIDOption
    {
        /// <summary>
        /// 原始配置（key:配置名 value:长度）,顺序为业务项目配置的
        /// </summary>
        public Dictionary<string, byte> SourceConfig { get; internal set; }

        /// <summary>
        /// 存放要使用的配置
        /// </summary>
        /// <remarks>
        /// 1.顺序在<see cref="SnowflakeIDConst"/>中查看
        /// </remarks>
        public List<Range> Config { get; internal set; }
    }
}

#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。