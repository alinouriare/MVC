using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace User.Infrastructures
{
    public class LocationClaimsProvider : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
       

            if (principal != null && !principal.HasClaim(c => c.Type == ClaimTypes.PostalCode))
            {

                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                if (identity != null && identity.IsAuthenticated && identity.Name != null)
                {
                    if (identity.Name.ToLower() == "ali")
                    {
                        identity.AddClaims(new Claim[] {
                        CreateClaim(ClaimTypes.PostalCode, "TH 10036"),
                        CreateClaim(ClaimTypes.StateOrProvince, "Tehran")
                        });
                }
            }
            }
            return
               Task.FromResult(principal);
        }


        private static Claim CreateClaim(string type, string value)
        {

            return new Claim(type, value, ClaimValueTypes.String, "Add Admin");
        }
    }






}
