using System;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;

namespace UltraNuke.Barasingha.AlarmManagement.API.Application.DTO
{
    public class AlarmForQueryDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 告警发生时间
        /// </summary>
        public DateTime OccurrenceTime { get; set; }
        /// <summary>
        /// 告警类别名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 告警级别名称
        /// </summary>
        public string LevelName { get; set; }
        /// <summary>
        /// 告警名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 告警描述
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 告警详情
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// 累计告警次数
        /// </summary>
        public string Count { get; set; }
        /// <summary>
        /// 告警状态
        /// </summary>
        public State State { get; set; }
        /// <summary>
        /// 告警状态名称
        /// </summary>
        public string StateName
        {
            get
            {
                return State.ToString();
            }
        }
    }
}
