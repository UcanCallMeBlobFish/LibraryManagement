using Application.Abstractions.Identity;
using Application.Abstractions.Library;
using Application.Models.Identity.JWTModels;
using Application.Models.Identity.LoginModels;
using Application.Models.Identity.RegistrationModels;
using Domain.Models;
using Infrastructure.IdentityData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
        private readonly JWTSettings _jwtSettings;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JWTSettings> jwtSettings, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _unitOfWork = unitOfWork;
            
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

        /// <summary>
        /// Extract Roles of specific ApplicationUser user,
        /// Extract "General" Claims of the same user.
        /// Convert Role to Claim
        /// Create Final Claims array with username, id, email, uid, roles, othet claims.
        /// Create security symmetric key using specified JWTsettings
        /// Hash it using 256
        /// Create JWT object
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Jwt object with issuer, audience claims expiretion date, credentials.</returns>
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            // Retrieve claims and roles associated with the user
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            // Convert roles to claims
            var roleClaims = new List<Claim>(roles.Count);
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Create the initial set of claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(roleClaims)
            .Union(userClaims);

            // Create a symmetric security key from the secret key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            // Create the JWT token
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }


        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            //Check that username exists or not.
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            //if yes throw an exception.
            if (existingUser != null)
            {
                throw new Exception($"UserName {request.UserName} already exists.");

            }
            
            //if not create a user with requested details.
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            //fetch email
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            //if not used then do things below.
            if (existingEmail == null)
            {
                //create user
                var result = await _userManager.CreateAsync(user, request.Password);

                //if ok then add new role to that user Employee.
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");

                    //Create Domain Customer with the same Username
                    Customer domainUser = new Customer
                    {
                        Username = request.UserName,
                        Email = request.Email,
                        Name = request.FirstName,
                        LastName = request.LastName

                    };
                    await _unitOfWork.Customers.Add(domainUser);
                    await _unitOfWork.SaveAsync();

                    return new RegistrationResponse() { UserId = user.Id };



                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email} already exists.");
            }

        }
    }
}
