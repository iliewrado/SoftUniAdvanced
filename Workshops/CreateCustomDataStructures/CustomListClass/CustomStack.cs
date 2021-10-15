using System;
namespace CustomStructuresClass
{
    /// <summary>
    /// Custom Stack Structure
    /// </summary>
    public class CustomStack
    {
        /// <summary>
        /// Internal Initial Capacity
        /// </summary>
        private const int InitialCapacity = 4;
        /// <summary>
        /// Internal Array
        /// </summary>
        private int[] itemsArray;
        /// <summary>
        /// Constructor initializes the capacity of the inner array
        /// </summary>
        public CustomStack()
        {
            itemsArray = new int[InitialCapacity];
        }
        /// <summary>
        /// Count of the elements in the stack
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Adds element to the stak
        /// </summary>
        /// <param name="item">Given element</param>
        public void Push(int item)
        {
            if (itemsArray.Length == Count)
            {
                Resize();
            }
            itemsArray[Count] = item;
            Count++;
        }
        /// <summary>
        /// Return and removes the last added element in stack
        /// </summary>
        /// <returns>Last item of the stack</returns>
        public int Pop()
        {
            IsEmpty();
            int element = itemsArray[Count - 1];
            itemsArray[Count - 1] = default(int);
            Count--;
            if (Count == itemsArray.Length / 4)
            {
                Shrink();
            }
            return element;
        }
        /// <summary>
        /// Return last element added to the stack without removing it
        /// </summary>
        /// <returns>Last item of the stack</returns>
        public int Peek()
        {
            IsEmpty();
            return itemsArray[Count - 1];
        }
        /// <summary>
        ///Performs an given Action for each element in collection
        /// </summary>
        /// <param name="action">Given Action</param>
        public void ForEach(Action<int> action)
        {
            foreach (var item in itemsArray)
            {
                action(item);
            }
        }
        /// <summary>
        /// Validate if stack has elements / Throws exception if it isn't
        /// </summary>
        private void IsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
        /// <summary>
        /// Resizes capacity of the stack by half
        /// </summary>
        /// 
        private void Shrink()
        {
            int[] copyArray = new int[itemsArray.Length / 2];
            Array.Copy(itemsArray, copyArray, Count);
            itemsArray = copyArray;
        }

        /// <summary>
        /// Doubles the capacity of the stack
        /// </summary>
        private void Resize()
        {
            int[] copyArray = new int[itemsArray.Length * 2];
            Array.Copy(itemsArray, copyArray, Count);
            itemsArray = copyArray;
        }
    }
}
