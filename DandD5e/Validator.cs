using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DandD5e
{
    internal class Validator
    {
        public static bool IsStringValid(string? stringInput)
        {
            if (String.IsNullOrEmpty(stringInput))
            {
                return false;
            }

            foreach (char c in stringInput)
            {
                if (!Char.IsLetter(c) && c != '/' && c != ' ')
                    return false;
            }

            return true;
        }
    }
}
