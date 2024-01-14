using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.AuthDTOs;

namespace Twitter.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(RegisterDTO dto);
    }
}
