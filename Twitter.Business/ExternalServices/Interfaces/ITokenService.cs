using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.DTOs.AuthDTOs;
using Twitter.Core.Entities;

namespace Twitter.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        public TokenDTO GenerateJWT(TokenParamsDTO dto);
    }
}
