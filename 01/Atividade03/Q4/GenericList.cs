using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    public class GenericList<T>
    {
        
        public List<T> List;
        public GenericList()
        {
            List = new List<T>();
        }
        public void Add(T input)
        {
            List.Add(input);
        }
    }
}
