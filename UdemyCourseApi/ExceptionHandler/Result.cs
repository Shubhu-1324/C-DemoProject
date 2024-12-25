namespace UdemyCourseApi.ExceptionHandler
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        // Success result
        public static Result<T> Success(T data) => new() { IsSuccess = true, Data = data, ErrorMessage = null };

        // Failure result
        public static Result<T> Failure(string errorMessage) => new() { IsSuccess = false, Data = default, ErrorMessage = errorMessage };
    }

}
