using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using UltraNuke.Barasingha.PermissionManagement.Domain.Common;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.DTO
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserForGetDTO
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
        public string GenderName
        {
            get
            {
                return Gender.ToString();
            }
        }
        public Gender Gender { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 已停用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 角色Id集合
        /// </summary>
        public Guid[] RoleIds
        {
            get
            {
                return Roles?.Select(s => s.Id).ToArray();
            }
        }

        /// <summary>
        /// 角色集合
        /// </summary>
        [JsonIgnore]
        public IList<RoleForGetDTO> Roles { get; set; } = new List<RoleForGetDTO>();
        #endregion        
    }
}
