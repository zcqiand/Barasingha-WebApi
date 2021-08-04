using MediatR;
using System;
using UltraNuke.Barasingha.PermissionManagement.Domain.Common;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {

        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 已停用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 角色Id集合
        /// </summary>
        public Guid[] RoleIds { get; set; }
        #endregion        
    }

}
