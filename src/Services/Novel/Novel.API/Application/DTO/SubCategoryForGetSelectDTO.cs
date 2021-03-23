using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UltraNuke.Barasingha.Novel.API.Application.DTO
{
    /// <summary>
    /// 作品小类
    /// </summary>
    public class SubCategoryForGetSelectDTO
    {
        #region Public Properties
        [JsonProperty(PropertyName = "value")]
        public Guid Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Name { get; set; }
        #endregion
    }
}
