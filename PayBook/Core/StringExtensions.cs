using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayBook
{
    public static class StringExtensions
    {
        public static int IndexOfFirstLowerCase(this string str)
        {
            for (int ctr = 0; ctr < str.Length; ctr++)
            {
                if (Char.IsLower(str[ctr]))
                {
                    return ctr;
                }
            }
            return -1;
        }

        public static string ToPascalCase(this string the_string)
        {
            // If there are 0 or 1 characters, just return the string.   
            if (the_string == null) return the_string;
            if (the_string.Length < 2) return the_string.ToUpper();
            
            // Split the string into words. 
            string[] words = the_string.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            
            // Combine the words.   
            string result = "";
     
            foreach (string word in words)
            {
                result += String.Format("{0}{1} ", word.Substring(0, 1).ToUpper(), word.Substring(1).ToLower());
            }
            return result;
        }
    }
}
