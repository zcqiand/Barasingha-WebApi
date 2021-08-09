using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.Novel.Domain.Common;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.Novel.Domain.AggregatesModel
{
    /// <summary>
    /// 作品
    /// </summary>
    [Table("N_Book")]
    public class Book : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 作品小类
        /// </summary>
        public SubCategory SubCategory { get; protected set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; protected set; }
        /// <summary>
        /// 作品封面
        /// </summary>
        public string Logo { get; protected set; }
        /// <summary>
        /// 作品名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 作品作者ID
        /// </summary>
        public Guid AuthorId { get; protected set; }
        /// <summary>
        /// 作品介绍
        /// </summary>
        public string Introduction { get; protected set; }
        /// <summary>
        /// 给读者的话
        /// </summary>
        public string MessageToReader { get; protected set; }
        /// <summary>
        /// 作品字数
        /// </summary>
        public int WordCount { get; protected set; }
        /// <summary>
        /// 收藏
        /// </summary>
        public int Favorites { get; protected set; }
        /// <summary>
        /// 作品状态
        /// </summary>
        public BookStatus BookStatus { get; protected set; }
        /// <summary>
        /// 连载状态
        /// </summary>
        public SerialStatus SerialStatus { get; protected set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建作品
        /// </summary>
        /// <param name="subCategory">作品小类</param>
        /// <param name="no">序号</param>
        /// <param name="logo">作品封面</param>
        /// <param name="name">作品名称</param>
        /// <param name="author">作品作者</param>
        /// <param name="introduction">作品介绍</param>
        /// <param name="messageToReader">给读者的话</param>
        /// <returns>作品对象</returns>
        public static Book Create(
            SubCategory subCategory,
            int no,
            string logo,
            string name,
            Guid authorId,
            string introduction,
            string messageToReader)
        {
            var o = new Book();

            o.Id = SequentialGuid.NewId();
            o.SubCategory = subCategory;
            o.No = no;
            o.Logo = logo;
            o.Name = name;
            o.AuthorId = authorId;
            o.Introduction = introduction;
            o.MessageToReader = messageToReader;
            o.WordCount = 0;
            o.Favorites = 0;
            o.BookStatus = BookStatus.审核未通过;
            o.SerialStatus = SerialStatus.连载;
            o.CreateTime = DateTime.Now;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新作品信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品名称</param>
        public void Update(
            SubCategory subCategory,
            int no,
            string logo,
            string name,
            Guid authorId,
            string introduction,
            string messageToReader)
        {
            SubCategory = subCategory;
            No = no;
            Logo = logo;
            Name = name;
            AuthorId = authorId;
            Introduction = introduction;
            MessageToReader = messageToReader;
        }

        /// <summary>
        /// 删除作品
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
