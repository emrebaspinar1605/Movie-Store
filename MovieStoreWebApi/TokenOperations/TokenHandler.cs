using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.TokenOperations.Model;

namespace WebApi.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }

        public TokenHandler(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public Token CreateAccesToken(Customer customer)
        {
            var tokenModel = new Token();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(15);

            var securityToken = new JwtSecurityToken(
                issuer : Configuration["Token:Issuer"],
                audience : Configuration["Token:Audience"],
                expires : tokenModel.Expiration,
                notBefore : DateTime.Now,
                signingCredentials : credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            //Creating Token
            tokenModel.AccesToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}