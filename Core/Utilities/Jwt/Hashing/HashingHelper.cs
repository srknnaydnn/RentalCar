using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Jwt.Hashing
{
    public class HashingHelper
    {

        public static void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != passwordSalt[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

    }
}
