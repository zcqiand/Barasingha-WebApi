using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraNuke.Barasingha.Novel.API.Application.DTO
{
    /// <summary>
    /// 作品大类
    /// </summary>
    public class MainCategoryDTO
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
        /// 类别名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 作品小类集合
        /// </summary>
        public IList<SubCategoryForGetDTO> SubCategories { get; set; }
        #endregion                
    }
}
