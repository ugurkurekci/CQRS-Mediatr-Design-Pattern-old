namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;

public interface IRefreshTokenValidator
{
    bool Validate(string refreshToken);
}