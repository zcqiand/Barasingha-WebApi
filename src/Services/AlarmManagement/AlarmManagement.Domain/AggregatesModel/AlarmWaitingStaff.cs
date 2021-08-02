using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;
using UltraNuke.CommonMormon.DDD;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警待办人员
    /// </summary>
    [Table("AM_AlarmWaitingStaff")]
    public class AlarmWaitingStaff : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 告警
        /// </summary>
        public Alarm Alarm { get; protected set; }
        /// <summary>
        /// 类型
        /// </summary>
        public EvidenceType Type { get; protected set; }
        /// <summary>
        /// 待办人员ID
        /// </summary>
        public Guid UserId { get; protected set; }
        /// <summary>
        /// 待办人员名称
        /// </summary>
        public string UserName { get; protected set; }
        #endregion        

        #region Public Methods
        #endregion
    }
}
