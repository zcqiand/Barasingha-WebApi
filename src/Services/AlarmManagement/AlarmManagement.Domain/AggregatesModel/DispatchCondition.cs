using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;
using UltraNuke.CommonMormon.DDD;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警分派条件
    /// </summary>
    [Table("AM_DispatchCondition")]
    public class DispatchCondition : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 告警分派
        /// </summary>
        public Dispatch AlarmDispatch { get; protected set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; protected set; }
        /// <summary>
        /// 条件字段
        /// </summary>
        public DispatchConditionField ConditionField { get; protected set; }
        /// <summary>
        /// 条件判断
        /// </summary>
        public DispatchConditionLogical ConditionLogical { get; protected set; }
        /// <summary>
        /// 字段值
        /// </summary>
        public string ConditionValue { get; protected set; }
        /// <summary>
        /// 并且与或者
        /// </summary>
        public DispatchConditionAndOr ConditionAndOr { get; protected set; }
        #endregion        

        #region Public Methods
        #endregion
    }
}
