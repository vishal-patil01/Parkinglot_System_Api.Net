// <copyright file="SecurityService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ApplicationServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using ApplicationModelLayer;
    using ApplicationRepositoryLayer;
    using ApplicationRepositoryLayer.Interface;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.JsonWebTokens;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// Service Layer for Owner.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IMSMQService mSMQService;

        private IConfiguration _config;

        public UserService(IConfiguration config,IUserRepository userRepository, IMSMQService mSMQService)
        {
            _config = config;
            this.userRepository = userRepository;
            this.mSMQService = mSMQService;
        }

        public string Login(UserLogin user)
        {
            try
            {
                string RoleName = userRepository.Login(user);
                return GenerateJSONWebToken(user, RoleName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Boolean AddUser(Users userDetails)
        {
            try
            {
                return userRepository.AddUser(userDetails);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private string GenerateJSONWebToken(UserLogin userInfo, string Role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claim = new[] {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email,userInfo.Email),
                new Claim(ClaimTypes.Role,Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claim,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
