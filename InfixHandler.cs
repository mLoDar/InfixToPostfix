namespace InfixToPostfix
{
    class InfixHandler
    {
        private static readonly string validOperators = "+-*/";



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

                if (validOperators.Contains(token))
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
    }
}