using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.PermissionManagement.Domain.AggregatesModel
{
    /// <summary>
    /// 应用
    /// </summary>
    [Table("PM_App")]
    public class App : AggregateRoot
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
        /// 应用名称
        /// </summary>
        public string Name { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建应用
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">应用名称</param>
        /// <returns>应用对象</returns>
        public static App Create(int no,
            string name)
        {
            var o = new App();

            o.Id = SequentialGuid.NewId();
            o.No = no;
            o.Name = name;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新应用信息
        /// </summary>
        /// <param name="no">序号</param>
        /// <param name="name">应用名称</param>
        public void Update(
            int no,
            string name)
        {
            No = no;
            Name = name;
        }

        /// <summary>
        /// 删除应用
        /// </summary>
        public void Delete()
        {
            AggregateState = AggregateState.Deleted;
        }
        #endregion
    }
}
