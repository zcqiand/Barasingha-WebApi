using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.Novel.Domain.AggregatesModel
{
    /// <summary>
    /// 作品章节
    /// </summary>
    [Table("N_Chapter")]
    public class Chapter : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 作品分卷
        /// </summary>
        public Segment Segment { get; protected set; }
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
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; protected set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; protected set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? ReleaseTime { get; protected set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// 新建作品章节
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品章节名称</param>
        /// <returns>作品章节对象</returns>
        public static Chapter Create(
            Segment segment,
            int no,
            string name,
            string content)
        {
            var o = new Chapter();

            o.Id = SequentialGuid.NewId();
            o.Segment = segment;
            o.No = no;
            o.Name = name;
            o.Content = content;
            o.CreateTime = DateTime.Now;
            o.UpdateTime = DateTime.Now;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新作品章节信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品章节名称</param>
        public void Update(
            int no,
            string name,
            string content)
        {
            No = no;
            Name = name;
            Content = content;
            UpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 删除作品章节
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
