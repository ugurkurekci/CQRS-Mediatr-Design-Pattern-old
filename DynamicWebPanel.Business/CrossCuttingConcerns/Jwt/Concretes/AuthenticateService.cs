using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Entity;
using DynamicWebPanel.Repository.Abstractions;
using static DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts.ITokenService;

namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Concretes;

public class AuthenticateService : IAuthenticateService
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;


    public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService, IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository)
    {
        _accessTokenService = accessTokenService;
        _refreshTokenService = refreshTokenService;
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateModel authenticateModel, CancellationToken cancellationToken)
    {
        var accessToken = _accessTokenService.Generate(authenticateModel);
        var refreshToken = _refreshTokenService.Generate(authenticateModel);

        await _refreshTokenRepository.AddAsync(new RefreshTokens()
        {
            UserID = authenticateModel.UserID,
            RefreshToken = refreshToken,
            Device = authenticateModel.Device,
            IpAdress = authenticateModel.IpAdress,

        });
        return new AuthenticateResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}

