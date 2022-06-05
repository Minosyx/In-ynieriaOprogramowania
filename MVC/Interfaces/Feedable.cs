namespace Interfaces
{
    public class Feedable<T>
    {
        public class Item<T>
        {
            public string Text { get; set; }
            public Action<T> Action { get; set; }
        }

        public Dictionary<int, Item<T>> Data { get; set; }
    }
}