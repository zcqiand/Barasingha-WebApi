using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Table("PM_Menu")]
    public class Menu : TreeAggregateRoot<Menu>
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; protected set; }
        /// <summary>
        /// 连接地址
        /// </summary>
        public string NavigateUrl { get; protected set; }
        /// <summary>
        /// 组件路径
        /// </summary>
        public string ComponentPath { get; protected set; }
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
        public static Menu Create(Menu parentNode, int no, string icon, string name, string navigateUrl, string componentPath, string description)
        {
            var o = new Menu();

            o.Id = SequentialGuid.NewId();
            o.ParentNode = parentNode;
            o.ParentNodeId = parentNode.Id;
            o.No = no;
            o.Icon = icon;
            o.Name = name;
            o.NavigateUrl = navigateUrl;
            o.ComponentPath = componentPath;
            o.Description = description;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        public void Update(Menu parentNode, int no, string icon, string name, string navigateUrl, string componentPath, string description)
        {
            ParentNode = parentNode;
            ParentNodeId = parentNode.Id;
            No = no;
            Icon = icon;
            Name = name;
            NavigateUrl = navigateUrl;
            ComponentPath = componentPath;
            Description = description;
        }

        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
