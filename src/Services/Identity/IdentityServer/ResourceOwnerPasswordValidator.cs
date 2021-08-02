using IdentityServer4.Validation;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        //public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        //{
        //    try
        //    {
        //        //get your user model from db (by username - in my case its email)
        //        var user = await _userRepository.FindAsync(1241);
        //        if (user != null)
        //        {
        //            //check if password match - remember to hash password if stored as hash in db
        //            if (true)
        //            {
        //                //set the result
        //                context.Result = new GrantValidationResult(
        //                    subject: user.Id.ToString(),
        //                    authenticationMethod: "custom",
        //                    claims: GetUserClaims(user));

        //                return;
        //            }

        //            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
        //            return;
        //        }
        //        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
        //    }
        //}
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
