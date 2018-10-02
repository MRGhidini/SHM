using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Extensions
{
    public static class FunctionalExtensions
    {
        public static T With<T>(this T self, Action<T> act)
        {
            act?.Invoke(self);
            return self;
        }

        public static async Task<T> WithAsync<T>(this T self, Func<T, Task> act)
        {
            if (act == null) return self;
            await act(self);
            return self;
        }

        public static TTo As<TFrom, TTo>(this TFrom self, Func<TFrom, TTo> converter) => converter == null ? default(TTo) : converter(self);
        public static async Task<TTo> AsAsync<TFrom, TTo>(this TFrom self, Func<TFrom, Task<TTo>> asyncConverter) => asyncConverter == null ? default(TTo) : await asyncConverter(self);
    }
}
