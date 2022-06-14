using System.Security.Claims;

namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;

public interface ITokenGenerator
{
    string Generate(string secretKey, string issuer, string audience, double expires,
        IEnumerable<Claim> claims = null);
}
