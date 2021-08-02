using MediatR;
using System;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;

namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Commands
{
    public class ClaimAlarmCommand : IRequest<bool>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 告警认领方式
        /// </summary>
        public ClaimAndCloseMethod ClaimMethod { get; set; }
        /// <summary>
        /// 告警认领人员ID
        /// </summary>
        public Guid ClaimUserId { get; set; }
        /// <summary>
        /// 告警认领人员名称
        /// </summary>
        public string ClaimUserName { get; set; }
    }

}
