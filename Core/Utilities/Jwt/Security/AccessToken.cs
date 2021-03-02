using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Jwt.Security
{
    public class AccessToken
    {
        //token üretilen class
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
