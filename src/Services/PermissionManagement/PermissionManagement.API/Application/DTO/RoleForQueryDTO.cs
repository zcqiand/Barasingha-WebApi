using System;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.DTO
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleForQueryDTO
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
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        #endregion        
    }
}
