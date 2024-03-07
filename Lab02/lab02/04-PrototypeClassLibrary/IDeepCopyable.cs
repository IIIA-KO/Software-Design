namespace _04_PrototypeClassLibrary
{
    public interface IDeepCopyable<T> where T : new()
    {
        void CopyTo(T obj);

        public T DeepCopy()
        {
            T t = new();
            CopyTo(t);
            return t;
        }
    }
}
