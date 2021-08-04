using System;
using System.Collections.Generic;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.DTO
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuForGetTreeTableDTO
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 连接地址
        /// </summary>
        public string NavigateUrl { get; set; }
        /// <summary>
        /// 组件路径
        /// </summary>
        public string ComponentPath { get; set; }
        /// <summary>
        /// 儿子节点
        /// </summary>
        public IList<MenuForGetTreeTableDTO> ChildNodes { get; set; }
        #endregion
    }
}
