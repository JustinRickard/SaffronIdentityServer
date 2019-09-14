using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using SaffronIdentityServer.Database.Models;

namespace SaffronIdentityServer.Saffron.EntityFramework
{
    public class SaffronIdentityServerConfigurationContext : ConfigurationDbContext
    {
        public SaffronIdentityServerConfigurationContext(
            DbContextOptions<ConfigurationDbContext> options,
            ConfigurationStoreOptions configOptions)
            : base(options, configOptions)
        {
            
        }
    }
}
