using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DefensiveProgramming.Guards
{
    /// <summary>
    /// Guard Clause Class
    /// </summary>
    internal static class StringGuard
    {
        public static string AgainstNullOrEmpty(this string? argument, string? errorMessage = null)
        {
            if (argument == null || argument == string.Empty) throw new NullReferenceException(errorMessage);
            return argument;
        }

        public static string AgainstExceedingWordCountLimit(this string argument, int wordCountLimit, string? errorMessage = null)
        {
            var numberOfWhiteSpaces = new String(argument.Where(character => Char.IsWhiteSpace(character)).ToArray());
            if (numberOfWhiteSpaces.Length >= wordCountLimit) throw new ArgumentException(errorMessage);
            return argument;
        }

        public static string AgainstInvalidInput(this string argument, string? errorMessage = null)
        {
            var regularExpression = new Regex("[a-zA-Z]+[\\s][a-zA-Z]+");
            if (!regularExpression.IsMatch(argument)){throw new ArgumentException(errorMessage);}
            return argument;
        }
    }
}
