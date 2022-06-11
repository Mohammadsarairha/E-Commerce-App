﻿using Bazar_App.Auth.Models.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bazar_App.Auth.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> Register(RegisterDto registerDto, ModelStateDictionary modelstate);
        public Task<UserDto> Authenticate(string username, string password);
        public Task<UserDto> GetUser(ClaimsPrincipal principal);

    }
}