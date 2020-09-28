using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ProducerConsumerExamples
{
    public class MultiThreadQueue
    {
        BlockingCollection<string> _jobs = new BlockingCollection<string>();

        /// <summary>
        /// Много поточная очередь
        /// </summary>
        /// <param name="numThreads">количество потоков</param>
        public MultiThreadQueue(int numThreads)
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
            foreach (var job in _jobs.GetConsumingEnumerable(CancellationToken.None))
            {
                Console.WriteLine(job);
                
                // Ждем 1 сек.
                Thread.Sleep(1000);
            }
        }

        public void Enqueue(string job)
        {
            _jobs.Add(job);
        }
    }
}