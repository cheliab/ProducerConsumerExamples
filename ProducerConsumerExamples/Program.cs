using System;
using System.Threading;

namespace ProducerConsumerExamples
{
    /// <summary>
    /// Примеры реализации паттерна producer / consumer
    ///
    /// https://michaelscodingspot.com/c-job-queues/
    /// </summary>
    class Program
    {
        public static void NaiveQueueStart()
        {
            var naiveQueue = new NaiveQueue();
            
            naiveQueue.Enqueue("Привет");
            naiveQueue.Enqueue("Пока");
            naiveQueue.Enqueue("Че как?");
            
            // Ждем 5 сек.
            Thread.Sleep(5000);
            
            naiveQueue.Enqueue("Ни как!");
        }

        public static void BitBetterQueueStart()
        {
            var queue = new BitBetterQueue();
            
            queue.Enqueue("Рас");
            queue.Enqueue("Два");
            queue.Enqueue("Три");
            
            // Ждем 5 сек.
            Thread.Sleep(5000);
            
            queue.Enqueue("Четыре");
        }

        public static void BlockingCollectionQueueStart()
        {
            var queue = new BlockingCollectionQueue();
            
            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            
            // Ждем 5 сек.
            Thread.Sleep(5000);
            
            queue.Enqueue("4");
        }

        public static void MultiThreadQueueStart()
        {
            var queue = new MultiThreadQueue(2);
            
            queue.Enqueue("aaa");
            queue.Enqueue("bbb");
            queue.Enqueue("ccc");
            
            // Ждем 5 сек.
            Thread.Sleep(5000);
            
            queue.Enqueue("ddd");
        }
        
        static void Main(string[] args)
        {
            // NaiveQueueStart();
            // BitBetterQueueStart();
            // BlockingCollectionQueueStart();
            
            MultiThreadQueueStart();
            
            Console.ReadLine();
        }
    }
}
