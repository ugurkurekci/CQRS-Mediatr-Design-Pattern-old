using System.Security.Claims;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Business.Utilities.Constans;
using DynamicWebPanel.Entity;
using static DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts.ITokenService;

namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Concretes;

public class AccessTokenService : IAccessTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly JwtSettings _jwtSettings;

    public AccessTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings)
    {
        _tokenGenerator = tokenGenerator;
        _jwtSettings = jwtSettings;
    }

    public string Generate(AuthenticateModel authenticateModel)
    {
        List<Claim> claims = new()
        {
            new Claim("userID", authenticateModel.UserID.ToString()),                   
            
        };
        return _tokenGenerator.Generate(_jwtSettings.AccessTokenSecret, _jwtSettings.Issuer, _jwtSettings.Audience,
            _jwtSettings.AccessTokenExpirationMinutes, claims);
    }
}
