using MHP.Books.API.Extensions;
using MHP.Books.Business.Interfaces;
using MHP.Books.Business.Notificacoes;
using MHP.Books.Business.Services;
using MHP.Books.Data.Context;
using MHP.Books.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MHP.Books.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

           


            services.AddScoped<INotificador, Notificador>();
          

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

          //  services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}