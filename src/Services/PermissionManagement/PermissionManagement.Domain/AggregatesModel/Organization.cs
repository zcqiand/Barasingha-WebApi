using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 组织机构
    /// </summary>
    [Table("PM_Organization")]
    public class Organization : AggregateRoot
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
        /// 组织机构名称
        /// </summary>
        public string Name { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建组织机构
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">组织机构名称</param>
        /// <returns>组织机构对象</returns>
        public static Organization Create(int no,
            string name)
        {
            var o = new Organization();

            o.Id = SequentialGuid.NewId();
            o.No = no;
            o.Name = name;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新组织机构信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">组织机构名称</param>
        public void Update(
            int no,
            string name)
        {
            No = no;
            Name = name;
        }

        /// <summary>
        /// 删除组织机构
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
