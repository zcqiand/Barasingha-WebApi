using System;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class ChapterCommandBase
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 作品分卷ID
        /// </summary>
        public Guid SegmentId { get; protected set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; protected set; }
        /// <summary>
        /// 章节名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 章节内容
        /// </summary>
        public string Content { get; protected set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; protected set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? ReleaseTime { get; protected set; }
        #endregion
    }

}
