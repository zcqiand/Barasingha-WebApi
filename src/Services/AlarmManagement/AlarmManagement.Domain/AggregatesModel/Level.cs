using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警级别
    /// </summary>
    [Table("AM_Level")]
    public class Level : AggregateRoot
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
        #endregion        

        #region Public Methods
        #endregion
    }
}
