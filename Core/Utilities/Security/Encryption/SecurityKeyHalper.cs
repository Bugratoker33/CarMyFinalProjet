using Microsoft.IdentityModel.Tokens;//comfigigdeki security key 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{//şifreleme olan herşeyde byte array tipinde tutmamız lazım 
    //asp netin jwt anlayacağı dilden yazmamız gerekir 
    //encriptiona parametre geçemeyiz security key halper bunu byte dönüştürüyor 
    public  class SecurityKeyHalper
    {
        public static SecurityKey CreatSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }

    }
}
