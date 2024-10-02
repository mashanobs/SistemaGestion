using Microsoft.Extensions.DependencyInjection;
using SistemaGestionData.Contexts;
using SistemaGestionData.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class ConfigureData
    {
        public static IServiceCollection ConfigureDataLayer(this IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>();
            services.AddScoped<ProductosDataAccess>();
            services.AddScoped<UsuariosDataAccess>(); // Agregado
            services.AddScoped<ProductoVendidoDataAccess>(); // Agregado
            services.AddScoped<VentaDataAccess>(); // Agregado
            services.AddScoped<MyDbContext>();
            return services;
        }
    }
}