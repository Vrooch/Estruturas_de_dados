namespace my_array
{
    internal class CapacityException : Exception
    {
        public CapacityException() {}
        public CapacityException(string message) : base(message) {}
    }
}