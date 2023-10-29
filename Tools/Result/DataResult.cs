namespace Tools.Result;

public readonly struct DataResult<T>
{
    private readonly List<Error> _errors;

    public T Data { get; }
    public IReadOnlyList<Error> Errors => _errors ?? new List<Error>();

    public Boolean IsSuccess => _errors is null || _errors.Count == 0;



    private DataResult(T data, IEnumerable<Error> errors = null)
    {
        Data = data;
        _errors = errors?.ToList() ?? new List<Error>();
    }

    public static DataResult<T> Success(T data) => new(data);
    internal static DataResult<T> Fail(T data, String error) => new(data, new[] { new Error(error) });
    public static DataResult<T> Fail(String error) => new(default, new[] { new Error(error) });
    public static DataResult<T> Fail(IEnumerable<Error> errors) => new(default, errors);

    public void Deconstruct(out Boolean isSuccess, out Error[] errors, out T data)
    {
        isSuccess = IsSuccess;
        errors = Errors.ToArray();
        data = Data;
    }

    public Result ToResult() => IsSuccess ? Result.Success() : Result.Fail(Errors);
}
