using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphingSoftware
{
    public abstract class Function
    {
        public abstract decimal getValue(decimal val);
        public abstract decimal getBoundary(decimal val1, decimal val2);
        public abstract Function getIntegral();
        public abstract Function getDerivative();
        public abstract void draw();
    }
}
