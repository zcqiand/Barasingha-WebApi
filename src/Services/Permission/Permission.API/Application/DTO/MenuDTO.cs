﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UltraNuke.Barasingha.Permission.API.Application.DTO
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Table("S_Menu")]
    public class MenuDTO
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
        /// 菜单说明
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否根节点
        /// </summary>
        public bool IsRootNode { get; set; }
        /// <summary>
        /// 是否叶节点
        /// </summary>
        public bool IsLeafNode { get; set; }
        /// <summary>
        /// 树层数
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 全树排序号
        /// </summary>
        public double FullSortNo { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        [JsonIgnore]
        public MenuDTO ParentNode { get; set; }
        public Guid? ParentNodeId { get; set; }
        /// <summary>
        /// 儿子节点
        /// </summary>
        public IList<MenuDTO> ChildNodes { get; set; } = new List<MenuDTO>();
        /// <summary>
        /// 角色集合
        /// </summary>
        public IList<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
        #endregion
    }
}
