using System;
using UltraNuke.Barasingha.Novel.Domain.Common;

namespace UltraNuke.Barasingha.Novel.API.Application.DTO
{
    /// <summary>
    /// 作品
    /// </summary>
    public class BookForQueryParamDTO
    {
        #region Public Properties
        /// <summary>
        /// 作品大类
        /// </summary>
        public Guid? MainCategoryId { get; set; }
        /// <summary>
        /// 作品小类
        /// </summary>
        public Guid[] SubCategoryIds { get; set; }
        /// <summary>
        /// 作品状态
        /// </summary>
        public BookStatus? BookStatusValue { get; set; }
        /// <summary>
        /// 连载状态
        /// </summary>
        public SerialStatus? SerialStatusValue { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize { get; set; }
        #endregion                
    }
}
