using AutoMapper;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Business.Mappings;

public class TokenProfile : Profile
{
    public TokenProfile()
    {
        CreateMap<RefreshTokens, AuthenticateModel>();

    }
}
