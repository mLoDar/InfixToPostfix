using System.Text;





namespace InfixToPostfix
{
    internal class Program
    {
        static void Main()
        {
        LabelMethodEntry:

            Console.Title = "InfixToPostfix";
            Console.OutputEncoding = Encoding.UTF8;
            
            Console.Clear();
            Console.SetCursorPosition(0, 4);



            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("              ┳  ┏•    ┏┳┓    ┏┓    ┏•               ");
            Console.WriteLine("              ┃┏┓╋┓┓┏   ┃ ┏┓  ┃┃┏┓┏╋╋┓┓┏             ");
            Console.WriteLine("              ┻┛┗┛┗┛┗   ┻ ┗┛  ┣┛┗┛┛┗┛┗┛┗             ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("             ───────────────────────────────         ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                     ");
            Console.WriteLine("             ┌ Please enter an infix term:           ");
            Console.WriteLine("             └────────────────────────────┐          ");
            Console.WriteLine("                                                     ");
            Console.Write("             > ");

            string inputInfixTerm = Console.ReadLine() ?? string.Empty;

            



            goto LabelMethodEntry;
        }
    }
}