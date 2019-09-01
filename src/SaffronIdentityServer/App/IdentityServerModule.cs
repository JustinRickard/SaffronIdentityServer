using System;
using System.Reflection;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RedRiver.Saffron.AspNetCore;
using SaffronIdentityServer.Auth;
using SaffronIdentityServer.Database.Models;
using RedRiver.Saffron.Autofac;

namespace SaffronIdentityServer.App
{
    public class IdentityServerModule : ISaffronWebApiModule
    {
        public void ConfigureBuilder(IApplicationBuilder builder)
        {
            SetUpIdentityServerDb(builder);
            builder.UseIdentityServer();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Figure out how to move into settings and grab
            var connectionString = @"Data Source=localhost;Initial Catalog=SaffronIdentityServerDemo;Integrated Security=True";
            var migrationAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

            // Register Identity
            services.AddIdentity<User, Role>()
                .AddUserStore<UserStore<User>>()
                .AddRoleStore<RoleStore<Role>>()
                .AddUserManager<UserManager<User>>()
                .AddRoleManager<RoleManager<Role>>();

            // Register IdentityServer
            services.AddIdentityServer()
                .AddOperationalStore(opts =>
                    opts.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOpts =>
                            sqlOpts.MigrationsAssembly(migrationAssembly)))
                .AddConfigurationStore(opts =>
                    opts.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOpts =>
                            sqlOpts.MigrationsAssembly(migrationAssembly)))
                .AddAspNetIdentity<User>()
                .AddDeveloperSigningCredential();
        }

        public void ConfigureMvcOptions(MvcOptions options)
        {
           
        }

        private void SetUpIdentityServerDb(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                // TODO: Tables are not being created
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
            }
        }

        public BuilderConfigurationPriority ConfigureBuilderPriority => BuilderConfigurationPriority.AfterMvc;
        public ServiceConfigurationPriority ConfigureServicesPriority => ServiceConfigurationPriority.AfterMvc;

        public MvcOptionsConfigurationPriority ConfigureMvcOptionsPriority =>
            MvcOptionsConfigurationPriority.BeforeValidationFilters;
    }
}
