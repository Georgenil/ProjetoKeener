using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentity.Conifg
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddAuthorizarionConfig(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("podeExcluir", policy => policy.RequireClaim("podeExcluir"));
                options.AddPolicy("podeExcluir2", policy => policy.RequireClaim("podeExcluir2"));
            });

            return services;
        }
    }
}
