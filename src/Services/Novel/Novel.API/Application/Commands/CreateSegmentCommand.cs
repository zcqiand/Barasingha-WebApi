using MediatR;
using System;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class CreateSegmentCommand : IRequest<Guid>
    {
        #region Public Properties
        /// <summary>
        /// 作品
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
