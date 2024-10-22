using System.Text;
using System.Runtime.InteropServices;





namespace InfixToPostfix
{
    internal class Program
    {
        private const int STD_OUTPUT_HANDLE = -11;
        private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;



#pragma warning disable SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
#pragma warning restore SYSLIB1054 // Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time



        static void Main()
        {
            try
            {
                EnableAnsiEscapeSequences();
            }
            catch (Exception exception)
            {
                DisplayError($"Failed to initialize ANSI color coding: {exception.Message}");
                
                Environment.Exit(0);
            }
            


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

        private static bool EnableAnsiEscapeSequences()
        {
            /*
                Thanks to 'John Leidegren' on StackOverflow!
                Used their solution for enabling the ANSI color coding
                for consoles under windows.

                - References
                Question: https://stackoverflow.com/questions/61779942/
                Answer: https://stackoverflow.com/a/75958239
            */

            IntPtr handle = GetStdHandle(STD_OUTPUT_HANDLE);

            if (handle == IntPtr.Zero)
            {
                throw new Exception("Cannot get standard output handle!");
            }

            if (!GetConsoleMode(handle, out uint mode))
            {
                throw new Exception("Cannot get console mode!");
            }

            mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;

            if (!SetConsoleMode(handle, mode))
            {
                throw new Exception("Cannot set console mode!");
            }

            return true;
        }
    }
}