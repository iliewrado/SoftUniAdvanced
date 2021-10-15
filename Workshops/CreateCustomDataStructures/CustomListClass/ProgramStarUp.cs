using System;

namespace CustomStructuresClass
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomList myList = new CustomList();

            myList.Add(10);

            myList.Contains(20);

            myList.Insert(1, 30);

            myList.RemoveAt(0);

            myList.Swap(0, 1);

            CustomStack myStack = new CustomStack();

            myStack.Push(10);

            myStack.Peek();

            myStack.Pop();

            myStack.ForEach(x => Console.WriteLine(x));
        }
    }
}
