using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public  class AccessToken//yetki gerektiren bir iş ise acses token denir 
    {//kulanıcı sisteme giriş yapacak ve bi buna token vereceğiz 
        public string Token { get; set; } //senin token bilgilerin bu 
        public DateTime Expiration { get; set; }

    }
}
