using System;
using System.Collections.Generic;

namespace FreeID.Snowflake
{
    public sealed class SnowflakeIDOptionBuilder
    {
        private readonly Dictionary<string, byte> TempConfig;

        public SnowflakeIDOptionBuilder()
        {
            this.TempConfig = new Dictionary<string, byte>();
        }

        public SnowflakeIDOptionBuilder Config_Reserve(byte length)
        {
            this.TempConfig.AddOrUpdate(SnowflakeIDConst.Lbl_WorkingMachineID, length);

            return this;
        }

        public SnowflakeIDOptionBuilder Config_TimeStamp(byte length)
        {
            this.TempConfig.AddOrUpdate(SnowflakeIDConst.Lbl_TimeStamp, length);

            return this;
        }

        public SnowflakeIDOptionBuilder Config_WorkingMachineID(byte length)
        {
            this.TempConfig.AddOrUpdate(SnowflakeIDConst.Lbl_WorkingMachineID, length);
            return this;
        }

        public SnowflakeIDOptionBuilder Config_SerialNumber(byte length)
        {
            this.TempConfig.AddOrUpdate(SnowflakeIDConst.Lbl_SerialNumber, length);
            return this;
        }

        public SnowflakeIDOption Build()
        {
            //检查
            this.CheckCountWithExcption();
            this.CheckLengthWithExcption();

            //计算取值范围
            List<Range> config = new List<Range>();
            byte tempMinIndex = 0;
            foreach (KeyValuePair<string, byte> item in this.TempConfig)
            {
                switch (item.Key)
                {
                    case SnowflakeIDConst.Lbl_Reserve:
                        config.Add(new Range(tempMinIndex, tempMinIndex += item.Value));
                        break;

                    case SnowflakeIDConst.Lbl_TimeStamp:
                        config.Add(new Range(tempMinIndex, tempMinIndex += item.Value));
                        break;

                    case SnowflakeIDConst.Lbl_WorkingMachineID:
                        config.Add(new Range(tempMinIndex, tempMinIndex += item.Value));
                        break;

                    case SnowflakeIDConst.Lbl_SerialNumber:
                        config.Add(new Range(tempMinIndex, tempMinIndex += item.Value));
                        break;

                    default:
                        break;
                }
            }

            //生成结果
            return new SnowflakeIDOption()
            {
                SourceConfig = this.TempConfig,
                Config = config
            };
        }

        /// <summary>
        /// 检查个数，不为4时抛出异常
        /// </summary>
        private void CheckCountWithExcption()
        {
            if (this.TempConfig.Count != SnowflakeIDConst.Key_Count)
            {
                throw new ArgumentException(SnowflakeIDConst.Msg.InitKeyCountError);
            }
        }

        /// <summary>
        /// 检查长度.异常时抛出异常
        /// </summary>
        private void CheckLengthWithExcption()
        {
            byte totalLength = this.TempConfig.Values.Sum();

            if (totalLength != SnowflakeIDConst.Key_Length)
            {
                throw new ArgumentException(SnowflakeIDConst.Msg.InitKeyLgenthError);
            }
        }
    }
}