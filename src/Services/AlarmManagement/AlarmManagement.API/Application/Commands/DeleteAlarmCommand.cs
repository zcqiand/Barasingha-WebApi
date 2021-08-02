using MediatR;
using System;

namespace UltraNuke.Barasingha.AlarmManagement.API.Application.Commands
{
    public class DeleteAlarmCommand : IRequest<bool>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
    }

}
