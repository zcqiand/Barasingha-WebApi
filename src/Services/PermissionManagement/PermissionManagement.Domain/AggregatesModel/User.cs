using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.PermissionManagement.Domain.Common;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("PM_User")]
    public class User : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; protected set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; protected set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; protected set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; protected set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; protected set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; protected set; }
        /// <summary>
        /// 已停用
        /// </summary>
        public bool Disabled { get; protected set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; protected set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUser { get; protected set; }
        /// <summary>
        /// 角色集合
        /// </summary>
        public IList<Role> Roles { get; protected set; } = new List<Role>();
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建用户
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="userName">用户名称</param>
        /// <param name="password">用户密码</param>
        /// <param name="nickName">昵称</param>
        /// <param name="gender">性别</param>
        /// <param name="avatarUrl">头像</param>
        /// <returns>用户对象</returns>
        public static User Create(
            int no,
            string userName,
            string password,
            string nickName,
            Gender gender,
            string avatarUrl,
            IList<Role> roles)
        {
            var o = new User();

            o.Id = SequentialGuid.NewId();
            o.No = no;
            o.UserName = userName;
            o.Password = password;
            o.NickName = nickName;
            o.Gender = gender;
            o.AvatarUrl = avatarUrl;
            o.Roles = roles;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="userName">用户名称</param>
        /// <param name="nickName">昵称</param>
        /// <param name="gender">性别</param>
        /// <param name="avatarUrl">头像</param>
        /// <param name="disabled">已停用</param>
        public void Update(
            int no,
            string userName,
            string nickName,
            Gender gender,
            string avatarUrl,
            bool disabled,
            IList<Role> roles)
        {
            No = no;
            AvatarUrl = avatarUrl;
            NickName = nickName;
            Gender = gender;
            UserName = userName;
            Disabled = disabled;
            Roles = roles;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role">角色</param>
        public void AddRole(Role role)
        {
            Roles.Add(role);
        }

        /// <summary>
        /// 移除角色
        /// </summary>
        /// <param name="role">角色</param>
        public void RemoveRole(Role role)
        {
            Roles.Remove(role);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
