using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CoursSoutien.Application.Interfaces;
using CoursSoutien.Application.DTOs;
using CoursSoutien.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursSoutien.Infrastructure.Services
{
    public class AuthService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration) 
        : IAuthService
    {
        public async Task<string> RegisterAsync(RegisterDto request)
        {
            var userExists = await userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
                throw new Exception("L'utilisateur existe déjà !");

            ApplicationUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                CreatedAt = DateTime.UtcNow 
            };

            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new Exception("La création a échoué : " + string.Join(", ", result.Errors.Select(e => e.Description)));

            await userManager.AddToRoleAsync(user, request.Role);

            return "Utilisateur créé avec succès !";
        }

        public async Task<string> LoginAsync(LoginDto request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
                throw new UnauthorizedAccessException("Email ou mot de passe incorrect.");

            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<List<string>> GetAvailableRolesAsync()
        {
            return await roleManager.Roles
                .Select(r => r.Name!)
                .ToListAsync();
        }
    }
}