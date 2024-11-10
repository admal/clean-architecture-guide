namespace MyProject.Application.Common;

public class ServiceResult<TResult> : ServiceResult
{
    public TResult? Result { get; set; }

    private ServiceResult(TResult result): base()
    {
        Result = result;
    }

    private ServiceResult(string errorMessage) : base(errorMessage)
    {
    }

    public static ServiceResult<TResult> ForSuccess(TResult result)
    {
        return new ServiceResult<TResult>(result);
    }

    public static new ServiceResult<TResult> ForError(string errorMessage)
    {
        return new ServiceResult<TResult>(errorMessage);
    }
}

public class ServiceResult
{
    public bool IsSuccessful => ErrorMessage.Length == 0;
    public string ErrorMessage { get; set; } = "";

    protected ServiceResult()
    {
    }

    protected ServiceResult(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public static ServiceResult ForSuccess()
    {
        return new ServiceResult();
    }

    public static ServiceResult ForError(string errorMessage)
    {
        return new ServiceResult(errorMessage);
    }
}
