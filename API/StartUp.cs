using API.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API;

public static class StartUp
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

        String? secretKey = configuration.GetSection("JWTSettings:SecretKey").Value;

        var jwtSettings = new
        {
            Issuer = configuration.GetSection("JWTSettings:Issuer").Value,
            Audience = configuration.GetSection("JWTSettings:Audience").Value,
            SigningKey = JWTTools.FormSingingKey(secretKey!)
        };

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = jwtSettings.SigningKey,
                ValidateLifetime = true,
            };
        });
    }

    public static void Initialize(this WebApplicationBuilder builder, Action<IServiceCollection>? action = null)
    {
        Initialize(builder.Services, builder.Configuration);

        if (action is not null)
            action(builder.Services);
    }
}
