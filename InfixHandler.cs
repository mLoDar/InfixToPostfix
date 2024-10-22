using System.Text;





namespace InfixToPostfix
{
    class InfixHandler
    {
        private static readonly string _validOperators = "+-*/";

        private static readonly Dictionary<char, int> _operatorRanking = new()
        {
            { '*', 1 },
            { '/', 1 },
            { '+', 0 },
            { '-', 0 }
        };



        internal static bool InfixTermIsValid(string inputInfixTerm)
        {
            bool lastTokenWasOperator = false;
            Stack<char> openedParantheses = new();

            foreach (char token in inputInfixTerm)
            {
                switch (token)
                {
                    case ' ':
                        continue;

                    case '(':
                        openedParantheses.Push(token);
                        lastTokenWasOperator = true;

                        continue;

                    case ')':
                        if (openedParantheses.Count == 0 || lastTokenWasOperator == true)
                        {
                            return false;
                        }

                        openedParantheses.Pop();
                        lastTokenWasOperator = false;

                        continue;

                    default:
                        break;
                }



                if (char.IsDigit(token))
                {
                    lastTokenWasOperator = false;
                    continue;
                }

                if (_validOperators.Contains(token))
                {
                    if (lastTokenWasOperator == true)
                    {
                        return false;
                    }

                    lastTokenWasOperator = true;
                    continue;
                }

                return false;
            }

            if (openedParantheses.Count > 0 || lastTokenWasOperator == true)
            {
                return false;
            }

            return true;
        }

        public static string InfixTermToPostfix(string inputInfixTerm)
        {
            List<string> postfixTerm = [];
            Stack<char> operators = new();
            StringBuilder numberBuilder = new();



            for (int i = 0; i < inputInfixTerm.Length; i++)
            {
                char token = Convert.ToChar(inputInfixTerm[i]);

                switch (token)
                {
                    case ' ':
                        continue;
                        
                    case '(':
                        operators.Push(token);
                        continue;

                    case ')':
                        while (operators.Count > 0 && operators.Peek() != '(')
                        {
                            postfixTerm.Add(operators.Pop().ToString());
                        }
                            
                        operators.Pop();
                        continue;
                }



                if (char.IsDigit(token))
                {
                    numberBuilder.Clear();

                    // Allow for multi digits like 15, 260 and so on
                    while (i < inputInfixTerm.Length && char.IsDigit(inputInfixTerm[i]))
                    {
                        numberBuilder.Append(inputInfixTerm[i]);
                        i++;
                    }

                    i--;
                    postfixTerm.Add(numberBuilder.ToString());

                    continue;
                }

                if (_operatorRanking.TryGetValue(token, out int value))
                {
                    while (operators.Count > 0 && _operatorRanking.ContainsKey(operators.Peek()) && _operatorRanking[operators.Peek()] >= value)
                    {
                        postfixTerm.Add(operators.Pop().ToString());
                    }

                    operators.Push(token);
                }
            }



            while (operators.Count > 0)
            {
                postfixTerm.Add(operators.Pop().ToString());
            }

            return string.Join(" ", postfixTerm);
        }
    }
}