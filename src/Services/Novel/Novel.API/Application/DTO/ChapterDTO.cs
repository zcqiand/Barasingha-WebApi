using System;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.Novel.Domain.AggregatesModel;

namespace UltraNuke.Barasingha.Novel.API.Application.DTO
{
    /// <summary>
    /// 作品章节
    /// </summary>
    [Table("N_Chapter")]
    public class ChapterDTO
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
        /// 作品分卷
        /// </summary>
        public Segment Segment { get; set; }
        /// <summary>
        /// 章节名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 章节内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? ReleaseTime { get; set; }
        #endregion        
    }
}
