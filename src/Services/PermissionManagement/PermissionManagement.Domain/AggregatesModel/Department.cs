using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 职务
    /// </summary>
    [Table("PM_Post")]
    public class Post : AggregateRoot
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
        /// 职务名称
        /// </summary>
        public string Name { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建职务
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">职务名称</param>
        /// <returns>职务对象</returns>
        public static Post Create(int no,
            string name)
        {
            var o = new Post();

            o.Id = SequentialGuid.NewId();
            o.No = no;
            o.Name = name;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新职务信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">职务名称</param>
        public void Update(
            int no,
            string name)
        {
            No = no;
            Name = name;
        }

        /// <summary>
        /// 删除职务
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
