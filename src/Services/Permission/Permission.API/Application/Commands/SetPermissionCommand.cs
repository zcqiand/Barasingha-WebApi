using MediatR;
using System;
using UltraNuke.Barasingha.Permission.API.Application.DTO;

namespace UltraNuke.Barasingha.Permission.API.Application.Commands
{
    public class SetPermissionCommand : IRequest<RoleDTO>
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 菜单Id集合
        /// </summary>
        public Guid[] MenuIds { get; set; }
        #endregion        
    }

}
