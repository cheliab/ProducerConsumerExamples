using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProducerConsumerExamples
{
    /// <summary>
    /// Наиваня реализация очереди
    /// 
    /// В ней есть ряд проблем:
    /// Очередь не является потокобезопасной (List <T>)
    /// Коллекция List <T> обеспечит ужасную производительность при таком использовании
    /// </summary>
    public class NaiveQueue
    {
        private List<string> _jobs = new List<string>();

        public NaiveQueue()
        {
            Task.Run(() => { OnStart(); });
        }

        public void Enqueue(string job)
        {
            _jobs.Add(job);
        }

        private void OnStart()
        {
            while (true)
            {
                if (_jobs.Count > 0)
                {
                    var job = _jobs.First();
                    
                    // Consume
                    Console.WriteLine(job);
                    
                    _jobs.RemoveAt(0);
                }
            }
        }
    }
}