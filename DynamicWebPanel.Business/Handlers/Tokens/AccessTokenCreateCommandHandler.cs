using DynamicWebPanel.Business.Commands.Tokens;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Business.Utilities.Exceptions;
using DynamicWebPanel.Repository.Abstractions;
using MediatR;

namespace DynamicWebPanel.Business.Handlers.Tokens;

public class AccessTokenCreateCommandHandler : IRequestHandler<AccessTokenCommand, AuthenticateResponse>
{
    private readonly IAuthenticateService _authenticateService;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AccessTokenCreateCommandHandler(IAuthenticateService authenticateService, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
    {

        _authenticateService = authenticateService;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<AuthenticateResponse> Handle(AccessTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request._loginUserRequest.Email);

        if (user is null)
            throw new UserNotFoundException();

        var signInResult = await _userRepository.GetCheckEmailPassword(request._loginUserRequest.Email, request._loginUserRequest.Password);
        if (signInResult is null)
            throw new SignInException();


        var checkDevice = await _refreshTokenRepository.GetByDeviceAsync(request._loginUserRequest.Device);

        if (checkDevice is not null)
        {

            return new AuthenticateResponse
            {
                RefreshToken = checkDevice.RefreshToken
            };
        }
        else
        {
            AuthenticateModel authenticate = new AuthenticateModel
            {
                UserID = user.ID,
                Device = request._loginUserRequest.Device,
                IpAdress = request._loginUserRequest.IpAdress,
                Email = request._loginUserRequest.Email,
                Password = request._loginUserRequest.Password
            };
            return await _authenticateService.Authenticate(authenticate, cancellationToken);
        }
    }
}
