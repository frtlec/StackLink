using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
        public static string ClaimUserName(this ClaimsPrincipal claimsPrincipal)
        {

            return claimsPrincipal != null ?
                        claimsPrincipal.Claims(ClaimTypes.Name).Count() > 0 ?

                         claimsPrincipal.Claims(ClaimTypes.Name).First()
                        : ""
                    :"";
        }

        public static string ClaimEmail(this ClaimsPrincipal claimsPrincipal)
        {

            return claimsPrincipal != null ?
                        claimsPrincipal.Claims(ClaimTypes.Email).Count() > 0 ?

                         claimsPrincipal.Claims(ClaimTypes.Email).First()
                        : ""
                    : "";
        }
    }
}
