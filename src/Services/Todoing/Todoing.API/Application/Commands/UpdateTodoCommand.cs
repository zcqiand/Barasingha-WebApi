using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace UltraNuke.Barasingha.Todoing.API.Application.Commands
{
    public class UpdateTodoCommand : IRequest<bool>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }
    }

}
