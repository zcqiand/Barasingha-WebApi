using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.DTO
{
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleForGetDTO
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
        /// <summary>
        /// 菜单ID集合
        /// </summary>
        public Guid[] MenuIds 
        { 
            get 
            {
                return Menus?.Select(s => s.Id).ToArray();
            }
        }

        /// <summary>
        /// 用户集合
        /// </summary>
        [JsonIgnore]
        public IList<UserForGetDTO> Users { get; set; } = new List<UserForGetDTO>();

        /// <summary>
        /// 菜单集合
        /// </summary>
        [JsonIgnore]
        public IList<MenuForGetDTO> Menus { get; set; } = new List<MenuForGetDTO>();
        #endregion        
    }
}
