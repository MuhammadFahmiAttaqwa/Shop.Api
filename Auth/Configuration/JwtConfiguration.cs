using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Auth.Configuration
{
    public class JwtConfiguration
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string PrivateKey { get; set; }

        public string PublicKey { get; set; }

        public double AccessTokenExpirationMinutes { get; set; } = 30;

        public double RefreshTokenExpirationDays { get; set; } = 10;

        public void Validate()
        {
            if (string.IsNullOrEmpty(Issuer))
                throw new InvalidOperationException("JWT Issuer is missing in configuration.");
            if (string.IsNullOrEmpty(Audience))
                throw new InvalidOperationException("JWT Audience is missing in configuration.");
            if (string.IsNullOrEmpty(PrivateKey))
                throw new InvalidOperationException("JWT Private Key is missing in configuration.");
            if (string.IsNullOrEmpty(PublicKey))
                throw new InvalidOperationException("JWT Public Key is missing in configuration.");
            if (AccessTokenExpirationMinutes <= 0)
                throw new InvalidOperationException("Access token expiration must be greater than 0 minutes.");
            if (RefreshTokenExpirationDays <= 0)
                throw new InvalidOperationException("Refresh token expiration must be greater than 0 days.");
            try
            {
                using var rsa = RSA.Create();
                rsa.ImportFromPem(PrivateKey);
                rsa.ImportFromPem(PublicKey);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Invalid RSA key format.", ex);
            }
        }
        public SecurityKey GetPrivateKey()
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(PrivateKey);
            return new RsaSecurityKey(rsa);
        }
        public SecurityKey GetPublicToken()
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(PublicKey);
            return new RsaSecurityKey(rsa);
        }
        public TokenValidationParameters ToTokenValidationParameter()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                IssuerSigningKey = GetPublicToken(),
                ClockSkew = TimeSpan.Zero
            };
        }

    }
}
