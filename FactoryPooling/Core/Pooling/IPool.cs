namespace TinyTools.Pooling
{
    /// <summary>
    /// Represents a collection that pools objects of T.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the pool</typeparam>
    public interface IPool<T>
    {
        void Prewarm(int num);
        T Request();
        void Return(T member);
    }
}
