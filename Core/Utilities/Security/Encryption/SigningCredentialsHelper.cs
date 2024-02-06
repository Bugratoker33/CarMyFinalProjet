using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public  class SigningCredentialsHelper
    {//anahtarımızı imzalatıoruz 
        //creddentiol giriş bilgilerin ;
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            // asp nete diyoruz ki anahtar olarak SecurityKey kulan şifreleme olarak da güvenlik algoritmalardınan sha512 kulan 

        }
    }
}
