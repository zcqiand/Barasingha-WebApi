using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraNuke.Barasingha.Todoing.API.Application.DTO
{
    /// <summary>
    /// 待办事项
    /// </summary>
    [Table("T_Todo")]
    public class TodoDTO
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        #endregion                
    }
}
