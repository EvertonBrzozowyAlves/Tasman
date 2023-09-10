namespace Tasman.Shared.Library.Models;

public class ApiResponse<T>
{
    public bool Succeeded { get; private set; }
    public T? Data { get; init; }
    public List<string>? Errors { get; init; } = new List<string>();

    public ApiResponse()
    {
        Data = default;
        Succeeded = true;
    }

    public ApiResponse(T? data)
    {
        Data = data;
        Succeeded = true;
    }

    public ApiResponse(string error)
    {
        Data = default;
        Succeeded = false;
        Errors.Add(error);
    }

    public ApiResponse(List<string> errors)
    {
        Data = default;
        Succeeded = false;
        Errors = errors;
    }
}
