using System;
using System.Collections.Generic;
using System.Linq;

namespace BrainTrainer.Collections
{
    class BtQueue<T>
    {
        private List<T> _list = new List<T>();
        public EventHandler MinNumberReached;


        public BtQueue(IEnumerable<T> collection)
        {
            _list.AddRange(collection);
            MinNumberOfElements = 20;
        }

        public int MinNumberOfElements { get; set; }

        public void Queue(T item)
        {
            _list.Add(item);
        }

        public T Dequeue()
        {
            var item = _list.FirstOrDefault();
            _list.RemoveAt(0);
            if (_list.Count < MinNumberOfElements)
            {
                if (MinNumberReached != null)
                {
                    MinNumberReached.Invoke(this, EventArgs.Empty);
                }
            }
            return item;
        }
    }
}