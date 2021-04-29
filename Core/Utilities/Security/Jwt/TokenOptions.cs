using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; } //kullanıcı kitlesi
        public string Issuer { get; set; }//imzalayan
        public int AccessTokenExpiration { get; set; } //tokenin omru
        public string SecurityKey { get; set; }
    }
}
