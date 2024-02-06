using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims); //ilgili kulanıcı için veri tabanına gidecek veri tabanından bu kulanıcının claimlerini bulucak jwt(token) üretecek api ve login kısmına verecek 
    }
}
