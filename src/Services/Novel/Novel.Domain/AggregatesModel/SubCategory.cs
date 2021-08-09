using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.Novel.Domain.AggregatesModel
{
    /// <summary>
    /// 作品小类
    /// </summary>
    [Table("N_SubCategory")]
    public class SubCategory : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 作品大类
        /// </summary>
        public MainCategory MainCategory { get; protected set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; protected set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建作品小类
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品小类名称</param>
        /// <param name="mainCategory">作品大类</param>
        /// <returns>作品小类对象</returns>
        public static SubCategory Create(
            int no,
            string name,
            MainCategory mainCategory)
        {
            var o = new SubCategory();

            o.Id = SequentialGuid.NewId();
            o.No = no;
            o.Name = name;
            o.MainCategory = mainCategory;
            o.CreateTime = DateTime.Now;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新作品小类信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品小类名称</param>
        /// <param name="mainCategory">作品大类</param>
        public void Update(
            int no,
            string name,
            MainCategory mainCategory)
        {
            No = no;
            Name = name;
            MainCategory = mainCategory;
        }

        /// <summary>
        /// 删除作品小类
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
