﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.AuthDTOs;
using Twitter.Business.Exceptions.Auth;
using Twitter.Business.ExternalServices.Interfaces;
using Twitter.Business.Services.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<TokenDTO> Login(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail) ?? await _userManager.FindByNameAsync(dto.UsernameOrEmail);   /*await userManager.FindByNameAsync(credentials.Username);*/
            if (user == null) throw new LoginFailedException("Login failed. Check your credentials!");

            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed) throw new LoginFailedException("Login failed. Check your credentials!");
            if (!await _signInManager.CanSignInAsync(user)) throw new LoginFailedException("Login failed. Account is not confirmed!");

            return _tokenService.GenerateJWT(user);
        }

        public async Task<bool> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded ? true : false;
        }

        public async Task<string> GetConfirmationToken(AppUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }
    }
}
