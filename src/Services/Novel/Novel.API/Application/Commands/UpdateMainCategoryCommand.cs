using MediatR;
using System;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class UpdateMainCategoryCommand : IRequest<bool>
    {
        #region Public Properties
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }
        #endregion        
    }

}
