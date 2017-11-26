using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
    public class Node<T>
    {
        public T Value { get; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            if (value == null)
                Value = default(T);
            else
                Value = value;

            Next = null;
        }
    }

    public class Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public Node<T> Head { get { return _head; } }
        public Node<T> Tail { get { return _tail; } }

        public Queue()
        {
            _head = null;
            _tail = _head;
        }

        public void Enqueue(T value)
        {
            if (value == null)
                return;

            if (_head == null)
            {
                _head = new Node<T>(value);
                _tail = _head;
            }
            else
            {
                _tail.Next = new Node<T>(value);
                _tail = _tail.Next;
            }

        }

        public T Dequeue()
        {
            if (_head == null)
                throw new Exception("Queue is empty");

            T value = _head.Value;
            _head = _head.Next;

            return value;
        }

        public IEnumerable<T> GetValues()
        {
            if (_head == null)
                yield break;

            var current = _head;
            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
            yield return current.Value;
        }
    }
}