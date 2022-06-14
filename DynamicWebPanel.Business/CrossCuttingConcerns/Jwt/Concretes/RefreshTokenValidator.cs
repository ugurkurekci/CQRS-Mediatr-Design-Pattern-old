﻿using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;
using DynamicWebPanel.Business.Utilities.Constans;
using Microsoft.IdentityModel.Tokens;

namespace DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Concretes;

public class RefreshTokenValidator : IRefreshTokenValidator
{
    private readonly JwtSettings _jwtSettings;

    public RefreshTokenValidator(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public bool Validate(string refreshToken)
    {
        TokenValidationParameters validationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.RefreshTokenSecret)),
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            ClockSkew = TimeSpan.Zero
        };

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        try
        {
            jwtSecurityTokenHandler.ValidateToken(refreshToken, validationParameters,
                out SecurityToken validatedToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}