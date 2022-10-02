using Railway;

namespace FunctionalTools
{
    public static class ProcessValidationExtensions
    {


        public static Result<TSuccess, TFailure> EnsureInputIsNotNull<TSuccess, TFailure>(this TSuccess theinput, TFailure errorType)
        {
            if (theinput == null)
                //   return new Result<InputType, PossibleError>( new PossibleError(){  RailwayApp.PossibleError.NotVeryGood);
                return new Result<TSuccess, TFailure>(errorType);
            return theinput;
        }
    }
}
