﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string? ImageUrl { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
