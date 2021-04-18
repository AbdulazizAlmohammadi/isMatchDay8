using System;

namespace isMatch
{
    class Program
    {
        class MatchOutput
        {
            public bool isMatched;
            public int maxDepth = 0;
            public String errMsg;
            public int lastPosition = 0;

            public void printResult()
            {
                Console.WriteLine($"Is matched: {isMatched}");
                if (isMatched)
                    Console.WriteLine($"Max depth: {maxDepth}");
                else
                {
                    Console.WriteLine($"error message: {errMsg}");

                    Console.WriteLine($"last position: {lastPosition}");
                }
            }
        }
        class MatchInput
        {
            public String source;
            public char start;
            public char end;

            public MatchOutput match()
            {
                int stack = 0;
                MatchOutput result = new MatchOutput();

                foreach (char c in this.source)
                {
                    if (c == this.start)
                    {
                        stack++;
                        if (stack > result.maxDepth) result.maxDepth = stack;
                    }
                    else if (c == this.end) stack--;

                    if (stack < 0)
                    {
                        result.isMatched = false;
                        result.errMsg = "Not Matched";
                        return result;
                    }
                    result.lastPosition++;

                }

                if (stack == 0)
                {
                    result.isMatched = true;
                }
                else
                {
                    result.isMatched = false;
                    result.errMsg = "Not Matched";
                };

                return result;
            }
        }

        static void Main(string[] args)
        {
            MatchInput input = new MatchInput();
            input.source = "{{{}{{}}{{{}}}}}}";
            input.start = '{';
            input.end = '}';
            MatchOutput result = input.match();
            result.printResult();
        }
    }
}
