using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using MediatR;

namespace DynamicWebPanel.Business.Commands.Tokens;

public class RefreshTokenCommand : IRequest<AuthenticateResponse>
{
    public RefreshTokenRequest _refreshTokenRequest;

    public RefreshTokenCommand(RefreshTokenRequest refreshTokenRequest)
    {
        _refreshTokenRequest = refreshTokenRequest;
    }
}

