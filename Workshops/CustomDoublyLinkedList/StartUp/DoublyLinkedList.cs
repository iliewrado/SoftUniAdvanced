using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedList
{
    /// <summary>
    /// Custom Double Linked List
    /// </summary>
    public class DoublyLinkedList
    {
        /// <summary>
        /// Count of elements in the List
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// First element of the List
        /// </summary>
        public ListNode Head { get; set; }
        /// <summary>
        /// Last element of the List
        /// </summary>
        public ListNode Tail { get; set; }
        /// <summary>
        /// Initialize Default/Empty Constructor
        /// </summary>
        public DoublyLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }
        /// <summary>
        /// Initialize Constuctor with Single/First Value
        /// </summary>
        /// <param name="value">Element Value</param>
        public DoublyLinkedList(int value)
            : this()
        {
            Head = Tail = new ListNode()
            {
                Value = value,
                Next = null,
                Previous = null
            };
            Count++;
        }
        /// <summary>
        /// Create a List collection of elements
        /// </summary>
        /// <param name="list">Elements to append in collection</param>
        public DoublyLinkedList(IEnumerable<int> list)
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
                    ListNode currentNode = new ListNode()
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
        /// <summary>
        /// Inserts an element in the beginning of the sequence
        /// </summary>
        /// <param name="element">Element Value</param>
        public void AddFirst(int element)
        {
            ListNode newNode = new ListNode() { Value = element };
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
        /// <summary>
        /// Append an element at the end of the sequence
        /// </summary>
        /// <param name="element">Element value</param>
        public void AddLast(int element)
        {
            ListNode newNode = new ListNode() { Value = element };
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
        /// <summary>
        /// Removes First element of the sequence
        /// </summary>
        /// <returns>Returns the value of the removed item</returns>
        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is EMPTY");
            }
            int element = Head.Value;
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
        /// <summary>
        /// Removes Last element of the sequence
        /// </summary>
        /// <returns>Returns the value of the removed item</returns>
        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is EMPTY");
            }
            int element = Tail.Value;
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
        /// <summary>
        /// Performs an action on each element of the collection
        /// </summary>
        /// <param name="action">Action to perform</param>
        public void ForEach(Action<int> action)
        {
            ListNode current = Head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
        /// <summary>
        /// Convert elements of list to array
        /// </summary>
        /// <returns>Array of elements</returns>
        public int[] ToArray()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("Empty list");
            }
            int[] result = new int[Count];
            int index = 0;
            ListNode current = Head;
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
