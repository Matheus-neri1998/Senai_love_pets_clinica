using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using senai_lovePets_webApi.Repositories;
using senai_lovePets_webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _login { get; set; }

        public LoginController()
        {
            _login = new UsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpPost]

        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                Usuario NovoUsuario = _login.Login(login.Email, login.Senha);

                if (NovoUsuario == null)
                {
                    return NotFound("Email e senhas inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, NovoUsuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, NovoUsuario.IdUsuario.ToString()), // Jti representa o id do usuário, e precisa ser uma string usando o método de conversão "ToString"
                    new Claim(ClaimTypes.Role, NovoUsuario.IdTipoUsuario.ToString()),   // Role é a permissão do usuário
                    new Claim("role", NovoUsuario.IdTipoUsuario.ToString())             // Claim usada para acessar via FrontEnd
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("lpets-chave-autenticacao")); // Palavra chave que será codificada e armazenada na variável "key"

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Nessa variável é armazenada os valores de "key" e será criptografada

                var token = new JwtSecurityToken(
                    issuer: "lovePets.webApi", // Emissor do token
                    audience: "lovePets.webApi", // validação do token
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30), // Tempo de expiração do token
                    signingCredentials: creds  // Credenciais de assinatura definidas na variável "creds"
                    ); // Fim do token

                return Ok(new // Montando uma estrutura em JSON
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
                
            } 
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        } // Fim do método Logar
    }
}
