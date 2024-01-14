using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.ExternalServices.Interfaces;
using Twitter.Business.Profiles;
using Twitter.Business.Repositories.Implements;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Implements;
using Twitter.Business.Services.Interfaces;
using FluentValidation.AspNetCore;
using Twitter.Business.DTOs.AuthDTOs;
using Twitter.Business.ExternalServices.Implements;
using Twitter.Business.DTOs.TopicDTOs;

namespace Twitter.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddScoped<ITopicRepository, TopicRepository>();
			services.AddScoped<IBlogFileRepository, BlogFileRepository>();
			services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
			return services;
        }
        public static IServiceCollection AddServices (this IServiceCollection services)
        {
            services.AddScoped<ITopicService, TopicService>();
		    services.AddScoped<IBlogFileService, BlogFileService>();
			services.AddScoped<IBlogService, BlogService>();
			services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICommentService, CommentService>();
            return services;
        }
        public static IServiceCollection AddBusinessLayer (this IServiceCollection services)
        {
			services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterDTOValidator>());
			services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
			return services;
        }
    }
}
