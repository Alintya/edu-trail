﻿using Microsoft.Extensions.DependencyInjection;

namespace EduTrail.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services
            //services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
