namespace DefensiveProgramming.Helpers
{

    /// <summary>
    /// (helper) Provides methods for improving readability of console output.
    /// </summary>
    public static class ConsoleHelper
    {
        public enum Color
        {
            Red = 0,
            Green = 1,
            Blue = 2,
        }

        /// <summary>
        /// Output color coded message to console.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void PrintInColor(string message, Color? color = null) // [Optional] parameters must appear last.
        {
            if (color != null)
            {
                switch (color)
                {
                    case Color.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Color.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Color.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                }
            }

            Console.WriteLine(message);
            if (!Console.ForegroundColor.Equals(ConsoleColor.White)) Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

