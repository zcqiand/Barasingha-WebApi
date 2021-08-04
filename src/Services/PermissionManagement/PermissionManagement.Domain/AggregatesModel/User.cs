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
        /// 昵称
        /// </summary>
        public string NickName { get; protected set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; protected set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; protected set; }
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
        /// 角色集合
        /// </summary>
        public IList<Role> Roles { get; protected set; } = new List<Role>();
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建用户
        /// </summary>
        public static User Create(
            string nickName,
            string userName,
            string password)
        {
            var o = new User();

            o.Id = SequentialGuid.NewId();
            o.NickName = nickName;
            o.UserName = userName;
            o.Password = password;
            o.Gender = Gender.未知;
            o.CreateTime = DateTime.Now;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        public void Update(
            int no,
            string nickName,
            Gender gender,
            string avatarUrl,
            bool disabled,
            IList<Role> roles)
        {
            No = no;
            NickName = nickName;
            AvatarUrl = avatarUrl;
            Gender = gender;
            Disabled = disabled;
            Roles = roles;
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
