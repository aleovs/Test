using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IStringSum
    {
        string TryGetSum(string x, string y, out bool success);
    }
}
