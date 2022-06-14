using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using MediatR;

namespace DynamicWebPanel.Business.Commands.Tokens;

public class AccessTokenCommand : IRequest<AuthenticateResponse>
{
    public AccessTokenRequest _loginUserRequest;

    public AccessTokenCommand(AccessTokenRequest loginUserRequest)
    {
        _loginUserRequest = loginUserRequest;
    }
}