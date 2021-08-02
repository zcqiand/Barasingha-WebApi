using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;
using UltraNuke.CommonMormon.DDD;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警证据
    /// </summary>
    [Table("AM_AlarmEvidence")]
    public class AlarmEvidence : AggregateRoot
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
        /// 名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; protected set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; protected set; }
        #endregion        

        #region Public Methods
        #endregion
    }
}
