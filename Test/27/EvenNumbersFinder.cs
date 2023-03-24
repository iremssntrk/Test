using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test._27
{
    public class EvenNumbersFinder
    {
        public IEnumerable<int> EvenNumber(List<int> numbers)
        {
            foreach (int n in numbers)
            {
                if (n % 2 ==0)
                {
                    yield return n;
                }
            }
            yield break;
        }
    }
}
