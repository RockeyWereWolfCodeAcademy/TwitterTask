using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Repositories.Implements;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Business.Services.Implements;
using Twitter.Business.Services.Interfaces;

namespace Twitter.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            services.AddScoped<ITopicRepository, TopicRepository>();
            return services;
        }
        public static IServiceCollection AddServices (this IServiceCollection services)
        {
            services.AddScoped<ITopicService, TopicService>();
            return services;
        }
    }
}
