using System;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.Novel.Domain.Common;

namespace UltraNuke.Barasingha.Novel.API.Application.DTO
{
    /// <summary>
    /// 作品
    /// </summary>
    public class BookForGetDTO
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 作品小类
        /// </summary>
        public string SubCategoryName { get; set; }
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
        /// 作品作者
        /// </summary>
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
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
        public string BookStatusName
        {
            get
            {
                return BookStatus.ToString();
            }
        }
        /// <summary>
        /// 连载状态
        /// </summary>
        public SerialStatus SerialStatus { get; set; }
        public string SerialStatusName
        {
            get
            {
                return SerialStatus.ToString();
            }
        }
        #endregion                
    }
}
