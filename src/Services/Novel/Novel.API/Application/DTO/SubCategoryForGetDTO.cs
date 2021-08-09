using System;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Novel.API.Application.DTO
{
    /// <summary>
    /// 作品小类
    /// </summary>
    public class SubCategoryForGetDTO
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 作品大类
        /// </summary>
        public MainCategory MainCategory { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }
        #endregion                
    }
}
