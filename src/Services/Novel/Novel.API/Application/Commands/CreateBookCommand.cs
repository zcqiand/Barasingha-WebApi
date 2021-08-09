using MediatR;
using System;
using UltraNuke.Barasingha.Novel.API.Application.DTO;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class CreateBookCommand : IRequest<Guid>
    {
        #region Public Properties
        /// <summary>
        /// 作品小类ID
        /// </summary>
        public Guid SubCategoryId { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 作品封面
        /// </summary>
        public string Logo { get; set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 作品作者ID
        /// </summary>
        public Guid AuthorId { get; set; }
        /// <summary>
        /// 作品介绍
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 给读者的话
        /// </summary>
        public string MessageToReader { get; set; }
        #endregion        
    }

}
