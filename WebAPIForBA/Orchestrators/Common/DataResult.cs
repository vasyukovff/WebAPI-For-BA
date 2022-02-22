namespace WebAPIForBA.Orchestrators.Common
{
    public class DataResult <T>
    {
        public DataResult(bool isSuccess, string msg = "", IEnumerable<T>? results = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = msg;
            Results = results;
        }

        public DataResult(bool isSuccess, T result)
        {
            IsSuccess = isSuccess;
            Results = new List<T> { result };
        }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<T>? Results { get; set; }
    }
}
