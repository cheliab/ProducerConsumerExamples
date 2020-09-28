using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ProducerConsumerExamples
{
    
    /// <summary>
    /// Оптимизирован для паттерна "Producer / Consumer" 
    /// </summary>
    public class BlockingCollectionQueue
    {
        private BlockingCollection<string> _jobs = new BlockingCollection<string>();

        public BlockingCollectionQueue()
        {
            var thread = new Thread(new ThreadStart(OnStart));
            thread.IsBackground = true;
            thread.Start();
        }

        private void OnStart()
        {
            foreach (var job in _jobs.GetConsumingEnumerable(CancellationToken.None))
            {
                Console.WriteLine(job);
            }
        }

        public void Enqueue(string job)
        {
            _jobs.Add(job);
        }
    }
}