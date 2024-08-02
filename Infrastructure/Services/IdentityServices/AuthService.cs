using Application.Abstractions.Identity;
using Application.Models.Identity.JWTModels;
using Application.Models.Identity.LoginModels;
using Application.Models.Identity.RegistrationModels;
using Infrastructure.IdentityData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.IdentityServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOptions<JWTSettings> _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
            
        }
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user == null)
            {
                throw new Exception($"User with email {request.Email} does not exist");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            
            if (!result.Succeeded) 
            {
                throw new Exception($"password for email: {request.Email} is not valid");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;

        }


        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)    {

            throw new Exception("not implemented");
        }

        public Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
