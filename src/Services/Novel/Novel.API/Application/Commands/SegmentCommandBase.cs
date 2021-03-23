using System;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class SegmentCommandBase
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 作品
        /// </summary>
        public Guid BookId { get; protected set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; protected set; }
        /// <summary>
        /// 分卷名称
        /// </summary>
        public string Name { get; protected set; }
        #endregion        
    }

}
