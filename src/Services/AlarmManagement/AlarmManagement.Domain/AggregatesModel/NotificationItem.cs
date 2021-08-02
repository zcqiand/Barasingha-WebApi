using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;
using UltraNuke.CommonMormon.DDD;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警通知清单
    /// </summary>
    [Table("AM_NotificationItem")]
    public class NotificationItem : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 告警通知
        /// </summary>
        public Notification Notification { get; protected set; }
        /// <summary>
        /// 告警状态
        /// </summary>
        public Level Level { get; protected set; }
        /// <summary>
        /// 通知时间
        /// </summary>
        public NotificationTime NotificationTime { get; protected set; }
        /// <summary>
        /// 延迟策略
        /// </summary>
        public int DelayStrategy { get; protected set; }
        /// <summary>
        /// 告警状态
        /// </summary>
        public State AlarmState { get; protected set; }
        /// <summary>
        /// 通知方式
        /// </summary>
        public NotificationMode NotificationMode { get; protected set; }
        #endregion        

        #region Public Methods
        #endregion
    }
}
