using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Extensions
{
    public static class StringExtensions
    {
        public static TEnum ToEnum<TEnum>(this string self) where TEnum : struct
        {
            TEnum t;
            return Enum.TryParse(self, out t) ? t : default(TEnum);
        }
    }
}
