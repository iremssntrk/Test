using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloneClass
{
    public static class Clone
    {
        public static void CopyTo(this object Source, object Destination)
        {
            foreach (var pS in Source.GetType().GetProperties())
            {
                foreach (var pT in Destination.GetType().GetProperties())
                {
                    if (pT.Name != pS.Name) continue;
                    (pT.GetSetMethod()).Invoke(Destination, new object[]
                    { pS.GetGetMethod().Invoke(Source, null ) });
                    break;
                }
            };
        }
    }
}
