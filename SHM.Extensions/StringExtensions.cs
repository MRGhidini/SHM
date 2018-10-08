using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Extensions
{
    public static class StringExtensions
    {
        public const string UnknownCharacter = "�";

        public static string ClearUnknownCharacters(this string self) => self.Replace(UnknownCharacter, string.Empty);
        public static TEnum ToEnum<TEnum>(this string self) where TEnum : struct
        {
            TEnum t;
            return Enum.TryParse(self, out t) ? t : default(TEnum);
        }
    }
}
