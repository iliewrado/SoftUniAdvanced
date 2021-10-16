using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public int Count { get; private set; }
        public ListNode<T> Head { get; set; }
        public ListNode<T> Tail { get; set; }
        public DoublyLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }
        public DoublyLinkedList(T value)
            : this()
        {
            Head = Tail = new ListNode<T>()
            {
                Value = value,
                Next = null,
                Previous = null
            };
            Count++;
        }
        public DoublyLinkedList(IEnumerable<T> list)
            : this(list.First())
        {
            bool isFirst = true;

            foreach (var item in list)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    ListNode<T> currentNode = new ListNode<T>()
                    {
                        Value = item,
                        Previous = Tail,
                        Next = null
                    };

                    Tail.Next = currentNode;
                    Tail = currentNode;
                    Count++;
                }
            }
        }
        public void AddFirst(T element)
        {
            ListNode<T> newNode = new ListNode<T>() { Value = element };
            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }
            Count++;
        }
        public void AddLast(T element)
        {
            ListNode<T> newNode = new ListNode<T>() { Value = element };
            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is EMPTY");
            }
            T element = Head.Value;
            Head = Head.Next;
            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }
            Count--;
            return element;
        }
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is EMPTY");
            }
            T element = Tail.Value;
            Tail = Tail.Previous;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }
            Count--;
            return element;
        }
        public void ForEach(Action<T> action)
        {
            ListNode<T> current = Head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
        public T[] ToArray()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Empty list");
            }
            T[] result = new T[Count];
            int index = 0;
            ListNode<T> current = Head;
            while (current != null)
            {
                result[index] = current.Value;
                index++;
                current = current.Next;
            }
            return result;
        }
    }
}
