namespace my_array
{
    internal class ArrayEmptyException : Exception
    {
        public ArrayEmptyException() {}
        public ArrayEmptyException(string message) : base(message) {}
    }
}