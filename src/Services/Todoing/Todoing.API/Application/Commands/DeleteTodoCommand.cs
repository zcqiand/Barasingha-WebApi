using MediatR;
using System;

namespace UltraNuke.Barasingha.Todoing.API.Application.Commands
{
    public class DeleteTodoCommand : IRequest<bool>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
    }

}
