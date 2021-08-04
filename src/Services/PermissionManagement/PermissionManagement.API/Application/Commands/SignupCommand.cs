using MediatR;
using System;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    /// <summary>
    /// 新建用户
    /// </summary>
    public class SignupCommand : IRequest<Guid>
    {
        #region Public Properties
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
        #endregion        
    }

}
