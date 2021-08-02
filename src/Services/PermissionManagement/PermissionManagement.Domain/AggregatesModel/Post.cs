using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 部门
    /// </summary>
    [Table("PM_Department")]
    public class Department : AggregateRoot
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
        /// 部门名称
        /// </summary>
        public string Name { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建部门
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">部门名称</param>
        /// <returns>部门对象</returns>
        public static Department Create(int no,
            string name)
        {
            var o = new Department();

            o.Id = SequentialGuid.NewId();
            o.No = no;
            o.Name = name;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">部门名称</param>
        public void Update(
            int no,
            string name)
        {
            No = no;
            Name = name;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
