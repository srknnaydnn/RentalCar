using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Jwt.Security
{
    public interface ITokenHelper
    {
        //access token interface
        AccessToken CreateAccessToken(User user,List<OperationClaim> operationClaims);
    }
}
