using Microsoft.AspNetCore.Mvc.Filters;
using SportInfo_Back.Enums;
using SportInfo_Back.Models;

namespace SportInfo_Back.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<RoleEnum> roles;

        public RoleAttribute(params RoleEnum[] roles)
        {
            this.roles = roles ?? Array.Empty<RoleEnum>();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous) return;
            var user = context.HttpContext.Items["User"];
            if (user != null)
            {
                var currentUser = (User)user;
                if(roles.Any() && !roles.Contains(currentUser.Role))
                {
                    throw new Exception("Vous n'avez pas les droits ...");
                }
            }
        }
    }
}
