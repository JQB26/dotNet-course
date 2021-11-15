using System;
using System.Collections;

namespace Cw03
{
    public class Queues
    {
        // 3.2
        //=== INCORRECT IMPLEMENTATION ===
        /*
        public class Queue : ArrayList
        {
            public void Enqueue(Object value)
            {
                Add(value);
            }

            public Object Dequeue()
            {
                object o = this[0];
                RemoveAt(0);
                return o;
            }
        }*/

        public class Queue
        {
            private ArrayList list;

            public Queue()
            {
                list = new ArrayList();
            }

            public void Enqueue(Object value)
            {
                list.Add(value);
            }
            public Object Dequeue()
            {
                object o = list[0];
                list.RemoveAt(0);
                return o;
            }

            public void PrintQueue()
            {
                foreach (var l in list)
                {
                    Console.Write(l);
                }
                Console.WriteLine();
            }

        }

        // 3.3
        public class TableBasedQueue
        {
            private static Object[] _queue;
            private static int _front, _rear;
            private readonly int _capacity;

            public TableBasedQueue(int capacity)
            {
                _queue = new object[capacity];
                _front = _rear = 0;
                _capacity = capacity;
            }

            public void Enqueue(Object value)
            {
                if (_capacity == _rear)
                {
                    Console.WriteLine("Queue is full");
                    return;
                }

                _queue[_rear] = value;
                _rear++;
            }

            public Object Dequeue()
            {
                if (_front == _rear)
                {
                    Console.WriteLine("Queue is empty");
                    return null;
                }

                object result = _queue[0];
                for (int i = 0; i < _rear - 1; i++)
                {
                    _queue[i] = _queue[i + 1];
                }
                _rear--;

                return result;
            }

            public void PrintQueue()
            {
                for (int i = _front; i < _rear; i++)
                {
                    Console.Write(_queue[i]);
                }
                Console.WriteLine();
            }
        }


    }
}