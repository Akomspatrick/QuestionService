using Railway;

namespace FunctionalTools
{
    public static class RailwayExtensions
    {

        public static Task<Result<TSuccess, TFailure>> AsAsync<TSuccess, TFailure>(this Result<TSuccess, TFailure> result)
        {
            return Task.FromResult(result);
        }



        public static TResult Either<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TSuccess, TResult> succesful, Func<IEnumerable<TFailure>, TResult> failure)
        {
            if (!result.IsSuccess)
            { return failure(result.Failures); }
            return succesful(result.Success);
        }

        public static Result<TSuccess, TResult> SelectFailure<TSuccess, TFailure, TResult>(this Result<TSuccess, TFailure> result, Func<TFailure, TResult> func)
        {
            return result.Either(
                (TSuccess success) => success,
                (IEnumerable<TFailure> failures) => new Result<TSuccess, TResult>(failures.Select(func))
              );
        }

    }
}
