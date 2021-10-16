﻿namespace CustomDoublyLinkedList
{
    public class ListNode<T>
    {
        public T Value { get; set; }
        public ListNode<T> Previous { get; set; }
        public ListNode<T> Next { get; set; }
    }
}
