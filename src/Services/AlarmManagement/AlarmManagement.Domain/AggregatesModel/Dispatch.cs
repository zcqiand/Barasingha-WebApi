using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警分派
    /// </summary>
    [Table("AM_Dispatch")]
    public class Dispatch : AggregateRoot
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
        /// 名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 分派人升级时间
        /// </summary>
        public int WaitTime { get; protected set; }
        /// <summary>
        /// 分派条件集合
        /// </summary>
        public List<DispatchCondition> DispatchConditions { get; set; } = new List<DispatchCondition>();
        /// <summary>
        /// 分派人集合
        /// </summary>
        public List<DispatchUser> DispatchUsers { get; set; } = new List<DispatchUser>();
        #endregion        

        #region Public Methods
        #endregion
    }
}
