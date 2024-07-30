using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Data;
using Template.Data.Database;
using Template.Data.Models;
using Template.Services;
using Template.Services.Interfaces;
using Template.Services.Options;

namespace Template
{
    public static class DepInj
    {
        public static void RegisterServices(
            this IServiceCollection services,
            DatabaseOption dbOption,
            Action<TemplateOptions> templateOptions)
        {
            #region Miscellaneous
            services.ConfigureServiceOptions<TemplateOptions>((_, opt) => templateOptions(opt));
            services.AddDatabaseContext<TemplateContext>(dbOption);
            services.AddHttpRequestBodyMapper();
            services.AddFluentValidator<Request>();
            #endregion

            #region Services
            services.AddTransient<ITemplateService, TemplateService>();
            #endregion
        }
        
        private static void ConfigureServiceOptions<TOptions>(
            this IServiceCollection services,
            Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            services
                .AddOptions<TOptions>()
                .Configure<IServiceProvider>((options, resolver) => configure(resolver, options));
        }
        
        private static void AddDatabaseContext<TContext>(
            this IServiceCollection services, DatabaseOption dbConnectionsOptions)
            where TContext : DbContext
        {
            
            services.AddDbContext<TContext>(
                options =>
                {
                    if (!options.IsConfigured)
                    {
                        options.UseSqlServer(dbConnectionsOptions.ConnectionString, opt =>
                        {
                            opt.EnableRetryOnFailure(
                                maxRetryCount: 5,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null);
                        });
                    }
                });
        }
        
        private static void AddHttpRequestBodyMapper(this IServiceCollection services)
        {
            services.AddTransient(typeof(IHttpRequestBodyMapper<>), typeof(HttpRequestBodyMapper<>));
        }

        private static void AddFluentValidator<T>(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(T).Assembly);
        }
    }
}