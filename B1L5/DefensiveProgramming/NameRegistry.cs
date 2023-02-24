using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefensiveProgramming.Guards;
using DefensiveProgramming.Helpers;

namespace DefensiveProgramming
{
    internal static class NameRegistry
    {
        private static List<string> _registeredNames = new();

        public static void RegisterNewName(string name)
        {

            if (name == null || name == String.Empty)
            {
                throw new NullReferenceException("Failed to register new name");
            }

            _registeredNames.Add(name);
            
            ConsoleHelper.PrintInColor($"New name registered: \t{name}", ConsoleHelper.Color.Blue);

        }

        public static string GetRegisteredName(string name) 
        {
            string? registeredName = _registeredNames.FirstOrDefault(name => name.Equals(name));
            if (registeredName == null) { throw new NullReferenceException("Failed to get name"); };
            return registeredName;
        }
    }
}
