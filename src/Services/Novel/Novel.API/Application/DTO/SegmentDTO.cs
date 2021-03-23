using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraNuke.Barasingha.Novel.API.Application.DTO
{
    /// <summary>
    /// 作品分卷
    /// </summary>
    [Table("N_Segment")]
    public class SegmentDTO
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 作品ID
        /// </summary>
        public Guid BookId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 分卷名称
        /// </summary>
        public string Name { get; set; }
        #endregion                
    }
}
