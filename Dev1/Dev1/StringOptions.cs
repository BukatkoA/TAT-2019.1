using System;

namespace Dev1
{
    class StringOptions
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a argument.");
            }
            else if(args[0].Length < 2)
            {
                Console.WriteLine("Please enter more than two symbols.");
            }
            else
            {
                SequenceCheck sequencesFinder = new SequenceCheck(args);
                sequencesFinder.CheckSequence();
            }
        }
    }
}
