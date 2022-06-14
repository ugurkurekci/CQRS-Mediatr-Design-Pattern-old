using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;

public interface IAuthenticateService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateModel authenticateModel, CancellationToken cancellationToken);
  
}


