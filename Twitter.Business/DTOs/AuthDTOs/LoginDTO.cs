﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.DTOs.AuthDTOs
{
	public class LoginDTO
	{
		public string UsernameOrEmail { get; set; }
		public string Password { get; set; }
	}
}
