using InventarioAPI.Comunes.Clases.Contratos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventarioAPI.Dominio.Services.Comunes
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetJWT(ClienteContract clienteContract)
        {
            string id = clienteContract.id_cliente.ToString();
            // Generate a list of claims for the payload of our token
            List<Claim> claims = new List<Claim>()
            {                        
                // Default claims
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
        
                // Custom claims
                new Claim("IdUser", id)
            };

            // Create a symmetric security key using the secret key from configuration
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            // Create credentials using the key and the HmacSha512Signature algorithm
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Create a new JWT token
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],           // Issuer
                _configuration["Jwt:Audience"],         // Audience
                claims: claims,                         // Claims in the payload
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpireTime"])), // Expiry time
                signingCredentials: credential);        // Signing credentials

            // Write the token as a string
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            // Return the generated JWT token
            return jwt;
        }

        public JwtSecurityToken VerifyJWT(string jwt)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = false, // Set to true if you want to validate the issuer
                ValidateAudience = false, // Set to true if you want to validate the audience
                ClockSkew = TimeSpan.Zero // This controls the tolerance for the token's expiration
            };

            try
            {
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(jwt, validationParameters, out validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    return jwtSecurityToken;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
