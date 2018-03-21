using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IMicroIndex
    {
        SearchResult Search(string x, string y);
    }
}
