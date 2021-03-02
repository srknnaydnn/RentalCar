using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Jwt.Security
{
    public class TokenOptions
    {
        //configrasyon dosyasındaki propertyler
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }

    }
}
