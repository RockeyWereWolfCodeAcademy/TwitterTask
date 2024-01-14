using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.Business.DTOs.AuthDTOs
{
    public class TokenParamsDTO
    {
        public AppUser User { get; set; }
        public string Role { get; set; }
    }
}
