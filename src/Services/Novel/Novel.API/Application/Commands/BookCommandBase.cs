using System;
using UltraNuke.Barasingha.Novel.Domain.Common;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    /// <summary>
    /// BookCommand基类
    /// </summary>
    public class BookCommandBase
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
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
        /// <summary>
        /// 作品字数
        /// </summary>
        public int WordCount { get; set; }
        /// <summary>
        /// 收藏
        /// </summary>
        public int Favorites { get; set; }
        /// <summary>
        /// 作品状态
        /// </summary>
        public BookStatus BookStatus { get; set; }
        /// <summary>
        /// 连载状态
        /// </summary>
        public SerialStatus SerialStatus { get; set; }
        #endregion        
    }

}
