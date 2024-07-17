using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ScrumTracker.DAL.IDataAccessLayer;
using ScrumTracker.DataObject.Context;
using ScrumTracker.DataObject.Entity;
using ScrumTracker.DataObject.ResponseEntity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.DAL.DataAccessLayer
{
    public class RefreshTokenDal : IRefreshTokenDal
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationDal authenticationDal;

        public RefreshTokenDal(IConfiguration configuration, IAuthenticationDal userRepository, ApplicationDBContext context)
        {
            _configuration = configuration;
            authenticationDal = userRepository;
            _context = context;
        }

        public TokenResponse GenerateTokens(UserTokenEntity user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.Now.AddDays(5);

            var userRole = _context.Roles.SingleOrDefault(r => r.RoleID == user.RoleID);
            var roleName = userRole != null ? userRole.RoleName : string.Empty;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, roleName)
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: creds
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = Guid.NewGuid().ToString();
            user.TokenExpiration = expiration;
            user.IsTokenExpired = expiration <= DateTime.Now;
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            authenticationDal.UpdateUser(user);

            Console.WriteLine($"Generated AccessToken JTI: {claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value}");
            Console.WriteLine($"Generated AccessToken Expiration: {expiration}");

            return new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expiration = expiration
            };
        }

        public TokenResponse RefreshToken(string refreshToken)
        {
            var user = authenticationDal.GetUserByRefreshToken(refreshToken);
            if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;
            }

            return GenerateTokens(user);
        }
    }
}
