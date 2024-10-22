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



            if (RegexPatterns.AllWhitespaces().Replace(inputInfixTerm, string.Empty).Equals(string.Empty))
            {
                DisplayError("The provided input contains of only whitespaces!");

                goto LabelMethodEntry;
            }

            if (InfixHandler.InfixTermIsValid(inputInfixTerm) == false)
            {
                DisplayError("An invalid infix term was provided!");

                goto LabelMethodEntry;
            }



            string postfixTerm;
            double postfixResult;

            try
            {
                postfixTerm = InfixHandler.InfixTermToPostfix(inputInfixTerm);

                postfixResult = InfixHandler.CalculatePostfixResult(postfixTerm);
                postfixResult = Math.Round(postfixResult, 2);
            }
            catch (Exception exception)
            {
                DisplayError($"An error has occurred while processing logic: '{exception.Message}'");

                goto LabelMethodEntry;
            }
            


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                     ");
            Console.WriteLine($"             Postfix term: \u001b[92m{postfixTerm}  ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                     ");
            Console.WriteLine($"             Calculated result: \u001b[92m{postfixResult}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.Write("             Press any key to contiue ...");

            Console.ReadKey();



            goto LabelMethodEntry;
        }

        private static void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                     ");
            Console.WriteLine($"             {errorMessage}                         ");

            Thread.Sleep(3000);
        }
    }
}