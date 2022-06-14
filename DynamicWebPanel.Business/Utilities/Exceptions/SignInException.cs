namespace DynamicWebPanel.Business.Utilities.Exceptions;

public class SignInException:Exception
{
    public SignInException() : base("Error occured while signing in user")
    {
    }

}
