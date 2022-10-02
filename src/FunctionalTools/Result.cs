namespace Railway
{

    public class Result<TSuccess, TFailure> //A Result that has two generic return values 
    {
        private readonly TSuccess _success; // a suucces value 

        private readonly IEnumerable<TFailure> _failures;// an enumurable failures


        public bool IsSuccess { get; private set; }  // a boolean value to check if the success path is true
        public TSuccess Success
        {
            get
            { // To get the success values
                if (!IsSuccess)
                {
                    throw new InvalidOperationException();
                }
                return _success;
            }
        }


        public IEnumerable<TFailure> Failures // to get the failures
        {
            get
            {
                if (IsSuccess)
                {
                    throw new InvalidOperationException();
                }
                return _failures;
            }

        }

        public Result(TSuccess success) // constructor for success
        {
            IsSuccess = true;
            _success = success;

            _failures = Enumerable.Empty<TFailure>();
        }

        public Result(TFailure failure) // constructor for failure
             : this((IEnumerable<TFailure>)new List<TFailure> { failure })
        {


        }

        public Result(IEnumerable<TFailure> failures)
        {
            IsSuccess = false;

            _success = default(TSuccess);
            _failures = failures.ToList();

        }
        public static implicit operator Result<TSuccess, TFailure>(TSuccess success) // To cast a SuccessType Result from a success
        {
            return new Result<TSuccess, TFailure>(success);
        }

        public static implicit operator Result<TSuccess, TFailure>(TFailure failure) // To cast a SuccessType Result from a success
        {
            return new Result<TSuccess, TFailure>(failure);
        }

    }
}
