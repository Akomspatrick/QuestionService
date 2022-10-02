using Railway;

namespace FunctionalTools
{
    public static class RailwayExtensionsAsync
    {
        public static Task<Result<TResult, TFailure>> SelectMany<TSuccess, TFailure, TResult>
                                                    (this Task<Result<TSuccess, TFailure>> result,
                                                                 Func<TSuccess, Task<Result<TResult, TFailure>>> func)
        {
            return
                result.SelectMany((Result<TSuccess, TFailure> r) => r.Either(func, (IEnumerable<TFailure> failures) => new Result<TResult, TFailure>(failures).AsAsync()));

        }
        //Bind Method takes in an Option and a function that returns an Option
        //Here the result is an option and func is a function that returns an option
        public static Task<Result<TResult, TFailure>> Bind<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result,
                                                                                         Func<TSuccess, Task<Result<TResult, TFailure>>> func)
        {
            return result.SelectMany(func);

        }

        public static Task<Result<TSuccess, TResult>> SelectFailure<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result,
                                                                                 Func<TFailure, TResult> func)
        {
            return result.Select((Result<TSuccess, TFailure> r) => r.SelectFailure(func));

        }
        public static Task<Result<TSuccess, TResult>> MapFailure<TSuccess, TFailure, TResult>(this Task<Result<TSuccess, TFailure>> result,
                                                                         Func<TFailure, TResult> func)
        {
            return result.SelectFailure(func);

        }








    }
}
