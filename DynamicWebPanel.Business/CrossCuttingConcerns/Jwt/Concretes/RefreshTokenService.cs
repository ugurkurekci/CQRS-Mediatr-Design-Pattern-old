using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Business.Utilities.Constans;
using static DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts.ITokenService;

namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Concretes;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly JwtSettings _jwtSettings;

    public RefreshTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings)
        =>
        (_tokenGenerator, _jwtSettings) = (tokenGenerator, jwtSettings);

    public string Generate(AuthenticateModel authenticateModel)
        =>

        _tokenGenerator.Generate(_jwtSettings.RefreshTokenSecret,
        _jwtSettings.Issuer, _jwtSettings.Audience,
        _jwtSettings.RefreshTokenExpirationMinutes);
}
