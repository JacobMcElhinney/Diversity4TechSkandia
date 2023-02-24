namespace DefensiveProgrammingSolid.Interfaces
{
    public interface IConsoleHelper
    {
        public enum Color
        {
            Red, 
            Green,
            Blue,
        }

        public void PrintInColor(string message, Color? color = null);

    }
}