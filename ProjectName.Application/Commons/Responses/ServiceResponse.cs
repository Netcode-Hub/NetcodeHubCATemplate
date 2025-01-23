namespace ProjectName.Application.Commons.Responses
{
    public record ServiceResponse<T>(T Data, bool IsSuccess, string Message = null!)
    {
        public static ServiceResponse<T> Success(T? data, string message = null!) => new(data!, true, message);
        public static ServiceResponse<T> Failure(string message) => new(default!, false, message);
    }
}
