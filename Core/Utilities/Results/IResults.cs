using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResults
    {//void için 
        bool Succeess { get; }
        string Message { get; }
    }
}
