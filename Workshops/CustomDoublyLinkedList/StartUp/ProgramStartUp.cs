using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList myLinkedList = new DoublyLinkedList(new int[] { 1, 2, 3, 4 });

            myLinkedList.AddFirst(0);

            myLinkedList.AddLast(5);

            Console.WriteLine($"First removed item is: {myLinkedList.RemoveFirst()}");

            Console.WriteLine($"Last removed item is: {myLinkedList.RemoveLast()}");

            int[] array = myLinkedList.ToArray();

            myLinkedList.ForEach(x => Console.WriteLine(x));
        }
    }
}
