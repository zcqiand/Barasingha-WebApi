using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警通知
    /// </summary>
    [Table("AM_Notification")]
    public class Notification : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; protected set; }
        /// <summary>
        /// 通知人ID
        /// </summary>
        public Guid UserId { get; protected set; }
        /// <summary>
        /// 通知人名称
        /// </summary>
        public string UserName { get; protected set; }
        /// <summary>
        /// 分派人集合
        /// </summary>
        public List<NotificationItem> NotificationItems { get; set; } = new List<NotificationItem>();
        #endregion        

        #region Public Methods
        #endregion
    }
}
