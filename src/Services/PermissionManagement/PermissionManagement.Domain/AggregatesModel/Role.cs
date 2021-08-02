using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 角色
    /// </summary>
    [Table("PM_Role")]
    public class Role : AggregateRoot
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
        /// 角色名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 用户集合
        /// </summary>
        public List<User> Users { get; set; } = new List<User>();
        /// <summary>
        /// 菜单集合
        /// </summary>
        public List<Menu> Menus { get; set; } = new List<Menu>();
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建角色
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">角色名称</param>
        /// <returns>角色对象</returns>
        public static Role Create(int no,
            string name)
        {
            var o = new Role();

            o.Id = SequentialGuid.NewId();
            o.No = no;
            o.Name = name;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">角色名称</param>
        public void Update(
            int no,
            string name)
        {
            No = no;
            Name = name;
        }

        /// <summary>
        /// 配置菜单权限
        /// </summary>
        /// <param name="菜单集合">menus</param>
        public void SetPermission(
            List<Menu> menus)
        {
            Menus = menus;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
