namespace Tasman.Shared.Library.MessageBus;

public class ErrorMessage
{
    public string Description { get; set; } = string.Empty;
    public string? StackTrace { get; set; }
    public string Message { get; set; } = string.Empty;
}