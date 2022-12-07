using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    public static class ExtensionGenericList
    {
        public static void RemoveRepetido<T>(this GenericList<T> entity) where T : notnull
        {
            int contains = 0;
            for(int k = 0; k < entity.List.Count; k++)
            {
                var item = entity.List[k];
                if (entity.List.Contains(item))
                    ++contains;
                if (contains > 1)
                    entity.List.Remove(item);
            }
        }
    }
}
