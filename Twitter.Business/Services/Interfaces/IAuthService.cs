using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.AuthDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<TokenDTO> Login(LoginDTO dto);
        public Task<bool> ConfirmEmail(string token, string email);
        public Task<string> GetConfirmationToken(AppUser user);
    }
}
