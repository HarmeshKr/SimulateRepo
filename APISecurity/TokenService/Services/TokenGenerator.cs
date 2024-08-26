using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TokenService.Models;

namespace TokenService.Services
{
    public interface ITokenGenerator
    {
        TokenResponseData GenerateToken(AppUser user, IEnumerable<string> roles);
    }
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly JwtOptions options;
        public JwtTokenGenerator(JwtOptions options)
        {
            this.options = options;
        }
        public TokenResponseData GenerateToken(AppUser user, IEnumerable<string> roles)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes(options.Secret);

            var claimList = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim (JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(JwtRegisteredClaimNames.Name,user.UserName)
            };

            claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = options.Audience,
                Issuer = options.Issuer,
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenhandler.CreateToken(tokenDescriptor);

            var token = new TokenResponseData();
            token.Role = roles.ToArray();
            token.Token = tokenhandler.WriteToken(securityToken);

            return token;
        }
    }
}
