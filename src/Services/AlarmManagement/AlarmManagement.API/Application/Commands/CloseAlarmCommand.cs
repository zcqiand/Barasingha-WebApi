using MediatR;
using System;
using UltraNuke.Barasingha.AlarmManagement.Domain.Common;

namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Commands
{
    public class CloseAlarmCommand : IRequest<bool>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 告警关闭方式
        /// </summary>
        public ClaimAndCloseMethod CloseMethod { get; set; }
        /// <summary>
        /// 告警关闭人员ID
        /// </summary>
        public Guid CloseUserId { get; set; }
        /// <summary>
        /// 告警关闭人员名称
        /// </summary>
        public string CloseUserName { get; set; }
        /// <summary>
        /// 告警原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 处理情况
        /// </summary>
        public string Handling { get; set; }
    }

}
