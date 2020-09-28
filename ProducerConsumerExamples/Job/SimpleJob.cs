using System;
using System.Threading;

namespace ProducerConsumerExamples
{
    public class SimpleJob
    {
        public JobState State { get; set; }

        public void Start(string stringToParse)
        {
            State = JobState.One;
            
            Thread.Sleep(5000);

            State = JobState.Two;
            
            Thread.Sleep(5000);

            State = JobState.Three;
            
            bool haveFourState = new Random().Next(100) <= 50;

            if (haveFourState)
            {
                State = JobState.Four;
            }
            
            Console.WriteLine(stringToParse);
        }
    }
}