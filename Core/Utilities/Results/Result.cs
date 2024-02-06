using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResults
    {
        //tek parametrede turu or false göndeririz tek parametreli cator çaılışr vey iki parmetre olarak sucsses ve message göndeririz iki parametre çaıştığında this ile diyer catoru çalıştırırz
        //sadece get yaptığızda read only olur ama catorla set de edebiliriz 
        public Result(bool succeess,string message):this(succeess)
        {
            Message = message;

        }
        public Result(bool succeess)
        {
            Succeess = succeess;
            
        }
        public bool Succeess { get; }

        public string Message { get; }
    }
}
