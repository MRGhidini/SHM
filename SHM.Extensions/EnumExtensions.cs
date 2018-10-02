using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<TEnum> GetFlags<TEnum>(this TEnum self)
            where TEnum : struct
        {
            foreach (TEnum value in Enum.GetValues(self.GetType()).Cast<TEnum>())
                if ((self as Enum).HasFlag(value as Enum))
                    yield return value;
        }
    }
}
