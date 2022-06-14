using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;

public interface ITokenService
{
    string Generate(AuthenticateModel authenticateModel);
    public interface IAccessTokenService : ITokenService { }
    public interface IRefreshTokenService : ITokenService { }
}
