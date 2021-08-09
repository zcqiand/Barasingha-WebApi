using MediatR;
using System;
using UltraNuke.Barasingha.Novel.API.Application.DTO;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class CreateChapterCommand : IRequest<Guid>
    {
        #region Public Properties
        /// <summary>
        /// 作品分卷ID
        /// </summary>
        public Guid SegmentId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 章节名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 章节内容
        /// </summary>
        public string Content { get; set; }
        #endregion
    }

}
