using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.AlarmManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 告警
    /// </summary>
    [Table("AM_Alarm")]
    public class Alarm : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 告警发生时间
        /// </summary>
        public DateTime OccurrenceTime { get; protected set; }
        /// <summary>
        /// 告警类别
        /// </summary>
        public Category Category { get; protected set; }
        /// <summary>
        /// 告警级别
        /// </summary>
        public Level Level { get; protected set; }
        /// <summary>
        /// 告警名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 告警描述
        /// </summary>
        public string Content { get; protected set; }
        /// <summary>
        /// 告警详情
        /// </summary>
        public string Details { get; protected set; }
        /// <summary>
        /// 外部事件ID
        /// </summary>
        public string EventId { get; protected set; }
        /// <summary>
        /// 累计告警次数
        /// </summary>
        public int Count { get; protected set; }
        /// <summary>
        /// 告警认领方式
        /// </summary>
        public ClaimAndCloseMethod ClaimMethod { get; protected set; }
        /// <summary>
        /// 告警认领时间
        /// </summary>
        public DateTime? ClaimTime { get; protected set; }
        /// <summary>
        /// 告警认领人员ID
        /// </summary>
        public Guid? ClaimUserId { get; protected set; }
        /// <summary>
        /// 告警认领人员名称
        /// </summary>
        public string ClaimUserName { get; protected set; }
        /// <summary>
        /// 告警关闭方式
        /// </summary>
        public ClaimAndCloseMethod CloseMethod { get; protected set; }
        /// <summary>
        /// 告警关闭时间
        /// </summary>
        public DateTime? CloseTime { get; protected set; }
        /// <summary>
        /// 告警关闭人员ID
        /// </summary>
        public Guid? CloseUserId { get; protected set; }
        /// <summary>
        /// 告警关闭人员名称
        /// </summary>
        public string CloseUserName { get; protected set; }
        /// <summary>
        /// 告警原因
        /// </summary>
        public string Reason { get; protected set; }
        /// <summary>
        /// 处理情况
        /// </summary>
        public string Handling { get; protected set; }
        /// <summary>
        /// 告警状态
        /// </summary>
        public State State { get; protected set; }
        /// <summary>
        /// 告警证据集合
        /// </summary>
        public List<AlarmEvidence> Evidences { get; set; } = new List<AlarmEvidence>();
        /// <summary>
        /// 告警待办人员集合
        /// </summary>
        public List<AlarmWaitingStaff> WaitingStaffs { get; set; } = new List<AlarmWaitingStaff>();
        #endregion        

        #region Public Methods
        public static Alarm Create(DateTime occurrenceTime, Category category, Level level,string name, string content, string details, string eventId)
        {
            var o = new Alarm();

            o.Id = SequentialGuid.NewId();
            o.OccurrenceTime = occurrenceTime;
            o.Category = category;
            o.Level = level;
            o.Name = name;
            o.Content = content;
            o.Details = details;
            o.EventId = eventId;
            o.Count = 1;
            o.State = State.待认领;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        public void Claim(ClaimAndCloseMethod claimMethod,Guid claimUserId,string claimUserName)
        {
            this.ClaimMethod = claimMethod;
            this.ClaimTime = DateTime.Now;
            this.ClaimUserId = claimUserId;
            this.ClaimUserName = claimUserName;
            this.State = State.已认领;
        }

        public void Close(ClaimAndCloseMethod closeMethod, Guid closeUserId, string closeUserName, string reason, string handling)
        {
            this.CloseMethod = closeMethod;
            this.CloseTime = DateTime.Now;
            this.CloseUserId = closeUserId;
            this.CloseUserName = closeUserName;
            this.Reason = reason;
            this.Handling = handling;
            this.State = State.已关闭;
        }

        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
