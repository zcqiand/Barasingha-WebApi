using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.Novel.Domain.AggregatesModel
{
    /// <summary>
    /// 作品大类
    /// </summary>
    [Table("N_MainCategory")]
    public class MainCategory : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
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
        /// <summary>
        /// 作品小类集合
        /// </summary>
        public IList<SubCategory> SubCategories { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建作品大类
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品大类名称</param>
        /// <returns>作品大类对象</returns>
        public static MainCategory Create(
            int no,
            string name)
        {
            var o = new MainCategory();

            o.Id = SequentialGuid.NewId();
            o.No = no;
            o.Name = name;
            o.CreateTime = DateTime.Now;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新作品大类信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">作品大类名称</param>
        public void Update(
            int no,
            string name)
        {
            No = no;
            Name = name;
        }

        /// <summary>
        /// 删除作品大类
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
