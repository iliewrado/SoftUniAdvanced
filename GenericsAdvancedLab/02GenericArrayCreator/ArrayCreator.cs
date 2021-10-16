namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] itemArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                itemArray[i] = item;
            }
            //Array.Fill(itemArray, item);
            return itemArray;
        }
    }
}
