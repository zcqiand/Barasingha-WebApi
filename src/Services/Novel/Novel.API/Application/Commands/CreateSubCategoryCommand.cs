using MediatR;
using System;

namespace UltraNuke.Barasingha.Novel.API.Application.Commands
{
    public class CreateSubCategoryCommand : IRequest<Guid>
    {
        #region Public Properties
        /// <summary>
        /// 作品大类ID
        /// </summary>
        public Guid MainCategoryId { get; set; }
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
