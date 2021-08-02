using System;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.DTO
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleForSetPermissionDTO
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 菜单Id集合
        /// </summary>
        public Guid[] MenuIds { get; set; }
        #endregion        
    }
}
