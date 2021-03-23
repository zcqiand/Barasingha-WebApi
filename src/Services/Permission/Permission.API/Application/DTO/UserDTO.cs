using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using UltraNuke.Barasingha.Permission.Domain.Common;

namespace UltraNuke.Barasingha.Permission.API.Application.DTO
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("S_User")]
    public class UserDTO
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
        /// 密码提示问题
        /// </summary>
        public string PasswordQuestion { get; set; }
        /// <summary>
        /// 密码提示回答
        /// </summary>
        public string PasswordAnswer { get; set; }
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
        public IList<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
        #endregion        
    }
}
