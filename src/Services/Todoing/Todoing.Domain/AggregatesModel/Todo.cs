using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UltraNuke.Barasingha.Todoing.Domain.Events;
using UltraNuke.CommonMormon.DDD;
using UltraNuke.CommonMormon.Utils.Core;

namespace UltraNuke.Barasingha.Todoing.Domain.AggregatesModel
{
    /// <summary>
    /// 待办事项
    /// </summary>
    [Table("T_Todo")]
    public class Todo : AggregateRoot
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public override Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; protected set; }
        #endregion        

        #region Public Methods
        /// <summary>
        /// 新建待办事项
        /// </summary>
        /// <param name="name">应用名称</param>
        /// <returns>应用对象</returns>
        public static Todo Create(string name)
        {
            var o = new Todo();

            o.Id = SequentialGuid.NewId();
            o.Name = name;

            o.AggregateState = AggregateState.Added;
            return o;
        }

        /// <summary>
        /// 更新待办事项
        /// </summary>
        /// <param name="name">应用名称</param>
        public void Update(
            string name)
        {
            Name = name;
            AddDomainEvent(new TodoUpdatedDomainEvent(this));
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
