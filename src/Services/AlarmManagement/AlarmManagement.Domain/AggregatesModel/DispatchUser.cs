using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警分派人
    /// </summary>
    [Table("AM_DispatchUser")]
    public class DispatchUser : AggregateRoot
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
        /// 立即分派人
        /// </summary>
        public bool Immediately { get; protected set; }
        /// <summary>
        /// 分派人ID
        /// </summary>
        public Guid UserId { get; protected set; }
        /// <summary>
        /// 分派人名称
        /// </summary>
        public string UserName { get; protected set; }
        #endregion        

        #region Public Methods
        #endregion
    }
}
