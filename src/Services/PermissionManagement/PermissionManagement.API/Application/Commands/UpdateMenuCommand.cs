using MediatR;
using System;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.Commands
{
    public class UpdateMenuCommand : IRequest<bool>
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 父菜单主键
        /// </summary>
        public Guid ParentNodeId { get; set; }
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
        #endregion

    }

}
