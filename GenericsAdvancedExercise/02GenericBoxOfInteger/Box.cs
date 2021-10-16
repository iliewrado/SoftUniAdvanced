namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        private readonly T Value;
        public Box(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value}";
        }
    }
}
