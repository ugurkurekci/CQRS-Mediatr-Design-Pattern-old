using AutoMapper;
using DynamicWebPanel.Business.Commands.Tokens;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Business.Utilities.Exceptions;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Tokens;

public class RefreshTokenCreateCommandHandler : IRequestHandler<RefreshTokenCommand, AuthenticateResponse>
{
    private readonly IAuthenticateService _authenticateService;
    private readonly IRefreshTokenValidator _refreshTokenValidator;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IMapper _mapper;
    public RefreshTokenCreateCommandHandler(
        IAuthenticateService authenticateService,
        IRefreshTokenValidator refreshTokenValidator,
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IMapper mapper)
    {
        _authenticateService = authenticateService;
        _refreshTokenValidator = refreshTokenValidator;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticateResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        RefreshTokenRequest refreshRequest = request._refreshTokenRequest;
        bool isValidRefreshToken = _refreshTokenValidator.Validate(refreshRequest.RefreshToken);
        if (!isValidRefreshToken)
        {
            throw new InvalidRefreshTokenException();
        }
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(refreshRequest.RefreshToken);

        if (refreshToken is null)
        {
            throw new InvalidRefreshTokenException();
        }


        var user = await _refreshTokenRepository.GetByUserIDAsync(refreshToken.UserID);
        if (user is not null)
        {
            await _refreshTokenRepository.DeleteAsync(refreshToken.ID);

            AuthenticateModel users = _mapper.Map<AuthenticateModel>(user);

            return await _authenticateService.Authenticate(users, cancellationToken);
        }

        throw new UserNotFoundException();
    }
}


