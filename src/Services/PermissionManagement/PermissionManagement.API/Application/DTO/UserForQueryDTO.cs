using System;
using UltraNuke.Barasingha.PermissionManagement.Domain.Common;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.DTO
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserForQueryDTO
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
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
        public string GenderName
        {
            get
            {
                return Gender.ToString();
            }
        }
        public Gender Gender { get; set; }
        /// <summary>
        /// 已停用
        /// </summary>
        public bool Disabled { get; set; }
        #endregion        
    }
}
