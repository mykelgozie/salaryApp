using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryApp.SalaryLib.utility
{
    public class ValidateClass
    {

        public static string CheckEmptyString(string text)
        {

            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Invlaid input");
            }

            return text;
        }

        internal static object CheckEmptyString(object text)
        {
            throw new NotImplementedException();
        }
    }
}
