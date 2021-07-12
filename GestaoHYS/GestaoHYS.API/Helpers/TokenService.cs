using GestaoHIS.Infrastructure;
using GestaoHYS.Core.Models;
using GestaoHYS.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHYS.API.Helpers
{
    public class TokenServico
    {
        public static async Task<string> GenerateToken(Usuario usuario, IConfigurationSystemRepository systemRepository)
        {
            var configurationSystem = (await systemRepository.FindAll()).FirstOrDefault();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configurationSystem.ClientSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim (
                        ClaimTypes.Name, 
                        usuario.Email.ToString ())
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
