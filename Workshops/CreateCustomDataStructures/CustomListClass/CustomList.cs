using System;
namespace CustomStructuresClass
{
    /// <summary>
    /// Custom List Structure
    /// </summary>
    public class CustomList
    {
        /// <summary>
        /// Internal Initial Capacity
        /// </summary>
        private const int InitialCapacity = 2;
        /// <summary>
        /// Internal Array
        /// </summary>
        private int[] itemsArray;
        /// <summary>
        /// Constructor initializes the capacity of the inner array
        /// </summary>
        public CustomList()
        {
            this.itemsArray = new int[InitialCapacity];
        }
        /// <summary>
        /// Count of the elements in the list
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Local variable representing the location of a value in an array
        /// </summary>
        /// <param name="index">Index parameter/value</param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return itemsArray[index];
            }
            set
            {
                ValidateIndex(index);
                itemsArray[index] = value;
            }
        }
        /// <summary>
        /// Method to add an element to the end of the sequence
        /// </summary>
        /// <param name="number">Element value</param>
        public void Add(int number)
        {
            if (this.Count == this.itemsArray.Length)
            {
                this.Resize();
            }
            this.itemsArray[Count] = number;
            Count++;
        }
        /// <summary>
        /// Method which removes an element/value at given index
        /// </summary>
        /// <param name="index">Given index to remove the item</param>
        /// <returns></returns>
        public int RemoveAt(int index)
        {
            ValidateIndex(index);
            int number = itemsArray[index];
            itemsArray[index] = default(int);
            ShiftLeft(index);
            Count--;
            if (Count == itemsArray.Length / 4)
            {
                Shrink();
            }
            return number;
        }
        /// <summary>
        /// Iserts element to given index of the list
        /// </summary>
        /// <param name="index">Given index</param>
        /// <param name="item">Given element</param>
        public void Insert(int index, int item)
        {
            if (index > Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
            if (Count == itemsArray.Length)
            {
                Resize();
            }
            ShiftRight(index);
            itemsArray[index] = item;
            Count++;
        }
        /// <summary>
        /// Checks if given element exists in colection
        /// </summary>
        /// <param name="number">Wanted item</param>
        /// <returns></returns>
        public bool Contains(int number)
        {
            for (int i = 0; i < Count; i++)
            {
                if (itemsArray[i] == number)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Changes the positions between two elements of a given indexes
        /// </summary>
        /// <param name="firstIndex">First index</param>
        /// <param name="secondIndex">Second index</param>
        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);
            
            int number = itemsArray[firstIndex];
            itemsArray[firstIndex] = itemsArray[secondIndex];
            itemsArray[secondIndex] = number;
        }
        /// <summary>
        /// Private method which shifts the locations/indexes of the elements backwards to open a spot to insert an element
        /// </summary>
        /// <param name="index">Stasting/Inserting index</param>
        private void ShiftRight(int index)
        {
            for (int i = Count - 1; i > index; i--)
            {
                itemsArray[i] = itemsArray[i - 1];
            }
        }
        /// <summary>
        /// Method that confirms that this index is inside an array
        /// </summary>
        /// <param name="index">Parameter value</param>
        private void ValidateIndex(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
        }
        /// <summary>
        /// Method which doubles the size of list
        /// </summary>
        private void Resize()
        {
            int[] copyArray = new int[itemsArray.Length * 2];
            for (int i = 0; i < itemsArray.Length; i++)
            {
                copyArray[i] = itemsArray[i];
            }
            itemsArray = copyArray;
        }
        /// <summary>
        /// Method which reduces the size of the list by half
        /// </summary>
        private void Shrink()
        {
            int[] arrayCopy = new int[itemsArray.Length / 2];
            Array.Copy(itemsArray, arrayCopy, Count);
            itemsArray = arrayCopy;
        }
        /// <summary>
        /// Private method which shifts the locations/indexes of the elements forward afrer removing of element
        /// </summary>
        /// <param name="index">Starting index</param>
        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                itemsArray[i] = itemsArray[i + 1];
            }
            itemsArray[Count - 1] = default(int);
        }
    }
}
