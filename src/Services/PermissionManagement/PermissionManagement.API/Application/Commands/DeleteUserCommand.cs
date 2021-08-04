using MediatR;
using System;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
    }

}
