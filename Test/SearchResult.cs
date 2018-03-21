using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SearchResult
    {
        public int NumberOfWordsMatching { get; set; }
        public List<string> Positions { get; set; }

        public SearchResult()
        {
            NumberOfWordsMatching = default(int);
            Positions = new List<string>();
        }
    }
}
