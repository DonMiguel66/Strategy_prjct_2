namespace SimpleStrategy3D.Utils
{
    public interface IAwaitable<T>
    {
        IAwaiter<T> GetAwaiter();
    }
}
