using AutoMapper;
using InventarioAPI.Infraestructura.Database.Contextos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NetCore.AutoRegisterDi;
using System.Reflection;
using System.Text;

namespace InventarioAPI.Configuracion.Container
{
    public class Register
    {
        public static void Configuracion(IServiceCollection services, IConfiguration configuration)
        {
            #region [Inyectar dependencia de AutoMapper]
            var configMapper = new MapperConfiguration(cfg => cfg.AddProfile(new PerfilAutoMapper()));
            var mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region [Inyectar dependencia de contexto de BD]
            services.AddDbContext<InventarioContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLConnection"));
            });
            #endregion

            #region [Configuracion de CORS]
            services.AddCors(options =>
            {
                options.AddPolicy("PoliticaCors", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            #endregion

            #region [Inyeccion de Dependencias]

            var assembliesToScan = new[]
             {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("InventarioAPI.Dominio"),
                Assembly.Load("InventarioAPI.Infraestructura"),
                Assembly.Load("InventarioAPI.Comunes"),
            };
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWith("Repository") ||
                       c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();
            #endregion

            #region [Configuracion de JWT]
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"], // Set your issuer
                    ValidAudience = configuration["Jwt:Audience"], // Set your audience
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            }


            ) ; 


            #endregion
        }
    }
}
