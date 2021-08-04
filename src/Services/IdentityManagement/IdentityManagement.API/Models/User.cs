using System;

namespace UltraNuke.Barasingha.IdentityManagement.API.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        #region Public Properties
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        #endregion        
    }
}
