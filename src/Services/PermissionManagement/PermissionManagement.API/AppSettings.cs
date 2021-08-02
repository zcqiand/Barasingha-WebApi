namespace UltraNuke.Barasingha.PermissionManagement.API
{
    public class AppSettings
    {
        /// <summary>
        /// 签名秘钥
        /// </summary>
        public string TokenSecret { get; set; }

        /// <summary>
        /// 颁发者
        /// </summary>
        public string TokenIssuer { get; set; }

        /// <summary>
        /// 接收者
        /// </summary>
        public string TokenAudience { get; set; }

        /// <summary>
        /// AccessToken超时时间，单位（分钟）
        /// </summary>
        public int AccessTokenExpiresIn { get; set; }

        /// <summary>
        /// RefreshToken超时时间，单位（天）
        /// </summary>
        public int RefreshTokenExpiresIn { get; set; }
    }
}
