using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> self, Action<T> act)
        {
            if (self == null || act == null) return self;
            foreach (var item in self)
                act(item);
            return self;
        }

        public static async Task<IEnumerable<T>> ForEachAsync<T>(this IEnumerable<T> self, Func<T, Task> act)
        {
            if (self == null || act == null) return self;
            foreach (var item in self)
                await act(item);
            return self;
        }
    }
}
