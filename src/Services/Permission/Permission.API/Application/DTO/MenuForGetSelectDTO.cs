using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UltraNuke.Barasingha.Permission.API.Application.DTO
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuForGetSelectDTO
    {
        #region Public Properties
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Name { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        [JsonProperty(PropertyName = "children")]
        public IList<MenuForGetSelectDTO> ChildNodes { get; set; }
        #endregion
    }
}
