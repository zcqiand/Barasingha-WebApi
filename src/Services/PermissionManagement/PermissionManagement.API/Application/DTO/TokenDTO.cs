using Newtonsoft.Json;
using System;

namespace UltraNuke.Barasingha.PermissionManagement.API.Application.DTO
{
    /// <summary>
    /// 授权
    /// </summary>
    public class TokenDTO
    {
        #region Public Properties
        /// <summary>
        /// AccessToken
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// AccessToken超时时间，单位（分钟）
        /// </summary>
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 刷新AccessToken
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public Guid UserId { get; set; }
        #endregion                
    }
}
