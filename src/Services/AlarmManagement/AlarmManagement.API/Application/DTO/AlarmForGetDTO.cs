using System;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;

namespace UltraNuke.Barasingha.AlarmManagement.API.Application.DTO
{
    public class AlarmForGetDTO
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
        /// 告警类别
        /// </summary>
        public Guid CategoryId { get; set; }
        /// <summary>
        /// 告警级别
        /// </summary>
        public Guid LevelId { get; set; }
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
        /// 外部事件ID
        /// </summary>
        public string EventId { get; set; }
        /// <summary>
        /// 累计告警次数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 告警认领方式
        /// </summary>
        public ClaimAndCloseMethod ClaimMethod { get; set; }
        /// <summary>
        /// 告警认领时间
        /// </summary>
        public DateTime? ClaimTime { get; set; }
        /// <summary>
        /// 告警认领人员ID
        /// </summary>
        public Guid? ClaimUserId { get; set; }
        /// <summary>
        /// 告警认领人员名称
        /// </summary>
        public string ClaimUserName { get; set; }
        /// <summary>
        /// 告警关闭方式
        /// </summary>
        public ClaimAndCloseMethod CloseMethod { get; set; }
        /// <summary>
        /// 告警关闭时间
        /// </summary>
        public DateTime? CloseTime { get; set; }
        /// <summary>
        /// 告警关闭人员ID
        /// </summary>
        public Guid? CloseUserId { get; set; }
        /// <summary>
        /// 告警关闭人员名称
        /// </summary>
        public string CloseUserName { get; set; }
        /// <summary>
        /// 告警原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 处理情况
        /// </summary>
        public string Handling { get; set; }
        /// <summary>
        /// 告警状态
        /// </summary>
        public State State { get; set; }
    }
}
