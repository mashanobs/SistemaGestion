using Microsoft.Extensions.DependencyInjection;
using SistemaGestionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBusiness
{
    public static class ConfigureBusiness
    {
        public static IServiceCollection ConfigureBusinessLayer(this IServiceCollection services)
        {
            services.ConfigureDataLayer();
            services.AddScoped<ProductoBusiness>();
            services.AddScoped<UsuarioBusiness>();
            services.AddScoped<ProductoVendidoBusiness>();
            services.AddScoped<VentaBusiness>();

            return services;
        }
    }

}
