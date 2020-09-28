using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ProducerConsumerExamples
{
    
    /// <summary>
    /// Немного лучшая реализация очереди
    ///
    /// Используется Thread (лучше для длительной работы отдельного потока)
    /// Используется ConcurrentQueue <T>, безопасна при работе с несколькими потоками
    /// У ConcurrentQueue имеются методы Enqueue и Dequeue
    /// </summary>
    public class BitBetterQueue
    {
        private ConcurrentQueue<string> jobQueue = new ConcurrentQueue<string>();

        public BitBetterQueue()
        {
            var thread = new Thread(new ThreadStart(OnStart));
            thread.IsBackground = true;
            thread.Start();
        }

        public void Enqueue(string job)
        {
            jobQueue.Enqueue(job);
        }

        private void OnStart()
        {
            while (true)
            {
                if (jobQueue.TryDequeue(out string result))
                {
                    // Consume
                    Console.WriteLine(result);
                }
            }
        }
    }
}