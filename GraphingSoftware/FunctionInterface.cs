using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphingSoftware
{
    public interface FunctionInterface
    {
        decimal getValue(decimal val);
        decimal getBoundary(decimal val1, decimal val2);
        
    }
}
