using Microsoft.AspNetCore.Authorization;

namespace ResourceService.Config
{
    public class Policies
    {
        public const string Manager = "Manager";
        public const string Executive = "Executive";
        public const string Admin = "Admin";
        public static AuthorizationPolicy ManagerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Manager).Build();
        }
        public static AuthorizationPolicy ExecutivePolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Executive).Build();
        }

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }
    }

}
