using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.Novel.Domain.AggregatesModel
{
    /// <summary>
    /// 作品分卷
    /// </summary>
    [Table("N_Segment")]
    public class Segment : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 作品
        /// </summary>
        public Book Book { get; protected set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; protected set; }
        /// <summary>
        /// 分卷名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建作品分卷
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品分卷名称</param>
        /// <returns>作品分卷对象</returns>
        public static Segment Create(
            Book book,
            int no,
            string name)
        {
            var o = new Segment();

            o.Id = SequentialGuid.NewId();
            o.Book = book;
            o.No = no;
            o.Name = name;
            o.CreateTime = DateTime.Now;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新作品分卷信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品分卷名称</param>
        public void Update(
            int no,
            string name)
        {
            No = no;
            Name = name;
        }

        /// <summary>
        /// 删除作品分卷
        /// </summary>
        public void Delete()
        {
            this.AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
