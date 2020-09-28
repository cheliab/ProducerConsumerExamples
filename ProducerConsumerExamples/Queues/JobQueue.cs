using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumerExamples
{
    public class JobQueue
    {
        BlockingCollection<string> parseList = new BlockingCollection<string>();
        List<SimpleJob> jobs = new List<SimpleJob>();

        public JobQueue(int numThreads)
        {
            for (int i = 0; i < numThreads; i++)
            {
                var thread = new Thread(OnHandleStart)
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        private void OnHandleStart()
        {
            foreach (var parseString in parseList.GetConsumingEnumerable(CancellationToken.None))
            {
                var job = new SimpleJob();
                job.Start(parseString);
                
                jobs.Add(job);
            }
        }

        public void SetJobsState()
        {
            foreach (var job in jobs)
            {
                Console.WriteLine(job.State);
            }
        }

        public void Enqueue(string parseString)
        {
            parseList.Add(parseString);
        }
    }
}