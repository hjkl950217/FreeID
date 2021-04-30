using System;
using System.Collections.Generic;

namespace FreeID.Snowflake
{
    /// <summary>
    /// 雪花ID
    /// </summary>
    public sealed partial class SnowflakeID : EqualityComparer<SnowflakeID>
    {
        //这个文件包含 定义和重载方法  逻辑部分在SnowflakeID.cs

        #region 雪花ID组件字段

        /// <summary>
        /// 预留位[默认第1个]
        /// </summary>
        public byte Reserve { get; private set; }

        /// <summary>
        /// 时间戳[默认第2个]
        /// </summary>
        public ulong TimeStamp { get; private set; }

        /// <summary>
        /// 工作机器ID[默认第3个]
        /// </summary>
        public UInt16 WorkingMachineID { get; private set; }

        /// <summary>
        /// 序列号[默认第4个]
        /// </summary>
        public UInt16 SerialNumber { get; private set; }

        #endregion 雪花ID组件字段

        #region 其它字段

        /// <summary>
        /// 雪花ID
        /// </summary>
        public ulong ResultID { get; private set; }

        /// <summary>
        /// 生成雪花ID时的配置
        /// </summary>
        public SnowflakeIDOption Option { get; private set; }

        /// <summary>
        /// 空ID
        /// </summary>
        public static ulong NullID { get => SnowflakeIDConst.NullID; }

        /// <summary>
        /// 空ID
        /// </summary>
        public static SnowflakeID Null { get => new SnowflakeID(); }

        #endregion 其它字段

        #region 构造方法

        /// <summary>
        /// 用于构造空的雪花ID对象
        /// </summary>
        internal SnowflakeID()
        {
        }

        /// <summary>
        /// 从<see cref="ulong"/>的雪花ID中构造<see cref="SnowflakeID"/>对象
        /// </summary>
        /// <param name="snowflakeID">已有的<see cref="long"/>型雪花ID</param>
        public SnowflakeID(ulong snowflakeID) : this(snowflakeID, SnowflakeIDOption.Default)
        {
            //这里的this跳到SnowflakeID.cs的代码
        }

        #endregion 构造方法

        #region 符号重载

        public static bool operator ==(SnowflakeID v1, SnowflakeID v2)
        {
            return EqualityComparer<ulong>.Default.Equals(
                v1.GetIDOrDefault(),
                v2.GetIDOrDefault());
        }

        public static bool operator !=(SnowflakeID v1, SnowflakeID v2)
        {
            return !EqualityComparer<ulong>.Default.Equals(
                v1.GetIDOrDefault(),
                v2.GetIDOrDefault());
        }

        #region 隐式转换

        public static implicit operator SnowflakeID(ulong value)
        {
            return new(value);
        }

        public static implicit operator ulong(SnowflakeID value)
        {
            return value.GetIDOrDefault();
        }

        #endregion 隐式转换

        //不需要显式转换，因为:ID->long long->ID 都有对应的隐式转换

        #endregion 符号重载

        #region Obejct方法重载

        public override bool Equals(object obj)
        {
            return obj switch
            {
                SnowflakeID obj2 => this.ResultID == obj2.ResultID,
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return this.ResultID.GetHashCode();
        }

        #endregion Obejct方法重载

        #region EqualityComparer接口实现

        public override bool Equals(SnowflakeID x, SnowflakeID y)
        {
            return EqualityComparer<ulong>.Default.Equals(
                x.GetIDOrDefault(),
                y.GetIDOrDefault());
        }

        public override int GetHashCode(SnowflakeID obj)
        {
            return obj.GetIDOrDefault().GetHashCode();
        }

        #endregion EqualityComparer接口实现
    }
}