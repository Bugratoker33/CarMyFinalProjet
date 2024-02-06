using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorrResult:Result
    {
       public ErrorrResult(string messages):base(false,messages) //sadece mesajı yazarız çünkü base biz false gönderdik 
        {

        }
        public ErrorrResult() : base(false)
        {


        }

    }
}
