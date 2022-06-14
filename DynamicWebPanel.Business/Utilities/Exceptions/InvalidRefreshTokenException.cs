namespace DynamicWebPanel.Business.Utilities.Exceptions;

public class InvalidRefreshTokenException : Exception
{
    public InvalidRefreshTokenException() : base("Refresh Token geçersiz.") { }
}
