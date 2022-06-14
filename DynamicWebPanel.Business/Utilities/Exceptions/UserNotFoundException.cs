namespace DynamicWebPanel.Business.Utilities.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Kullanıcı Bulunamadı") { }
}
