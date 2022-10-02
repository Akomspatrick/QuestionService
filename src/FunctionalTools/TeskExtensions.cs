namespace FunctionalTools
{
    public static class TeskExtensions
    {
        public static async Task<TResult> SelectMany<T, TResult>(this Task<T> task, Func<T, Task<TResult>> func)
        {
            return await func(await task);
        }

        public static async Task<TResult> Select<T, TResult>(this Task<T> task, Func<T, TResult> func)
        {
            return func(await task);
        }
    }
}
