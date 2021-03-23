using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UltraNuke.Barasingha.Novel.API.Application.DTO
{
    /// <summary>
    /// 作品大类
    /// </summary>
    public class MainCategoryForGetSelectDTO
    {
        #region Public Properties
        [JsonProperty(PropertyName = "value")]
        public Guid Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Name { get; set; }
        /// <summary>
        /// 儿子节点
        /// </summary>
        public IList<SubCategoryForGetSelectDTO> children
        {
            get
            {
                if (SubCategories.Count > 0)
                {
                    return SubCategories;
                }
                return null;
            }
        }
        [JsonIgnore]
        public IList<SubCategoryForGetSelectDTO> SubCategories { get; set; }
        #endregion
    }
}
