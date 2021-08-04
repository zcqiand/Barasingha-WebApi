using Dapper;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UltraNuke.Barasingha.IdentityManagement.API.Models;

namespace UltraNuke.Barasingha.IdentityManagement.API
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private string connectionString = string.Empty;
        public ResourceOwnerPasswordValidator(IConfiguration configuration)
        {
            var constr = configuration.GetConnectionString("PermissionManagementContext");
            connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            User user;
            using (var connection = OpenConnection())
            {
                const string query = "SELECT * FROM dbo.PM_User WHERE UserName = @UserName And Password = @Password And Disabled=0";
                user = connection.Query<User>(query, new { context.UserName, context.Password }).SingleOrDefault();
            }

            if (user!=null)
            {
                List<Claim> claimList = new List<Claim>();
                claimList.Add(new Claim(JwtClaimTypes.Name, user.NickName));
                claimList.Add(new Claim(JwtClaimTypes.Id, user.Id.ToString()));

                context.Result = new GrantValidationResult(
                 subject: context.UserName,
                 authenticationMethod: OidcConstants.AuthenticationMethods.Password,
                 claims: claimList);
            }
            else
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant,
                    "invalid custom credential"
                    );
            }
            return Task.FromResult(0);
        }
    }
}
