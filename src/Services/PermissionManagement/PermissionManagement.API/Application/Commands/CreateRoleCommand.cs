using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class CreateRoleCommand : IRequest<Guid>
    {
        #region Public Properties
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }
        #endregion        
    }

}
