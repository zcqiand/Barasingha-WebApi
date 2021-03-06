using MediatR;
using System;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
    }

}
