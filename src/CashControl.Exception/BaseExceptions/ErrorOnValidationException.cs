namespace CashControl.Exception.BaseExceptions;
public class ErrorOnValidationException : CashControlBaseException
{
    public List<string> Errors { get; set; }
    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
