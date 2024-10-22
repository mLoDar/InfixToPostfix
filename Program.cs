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


            
            if (InfixHandler.InfixTermIsValid(inputInfixTerm) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                                     ");
                Console.WriteLine("             An invalid infix term was provided!     ");

                Thread.Sleep(3000);

                goto LabelMethodEntry;
            }

            string postfixTerm = InfixHandler.InfixTermToPostfix(inputInfixTerm);



            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                     ");
            Console.Write("             Postfix term: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(postfixTerm);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.Write("             Press any key to contiue ...");

            Console.ReadKey();



            goto LabelMethodEntry;
        }
    }
}