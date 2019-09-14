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
    public class SaffronIdentityServerPersistedGrantContext : PersistedGrantDbContext
    {
        public SaffronIdentityServerPersistedGrantContext(
            DbContextOptions<PersistedGrantDbContext> options,
            OperationalStoreOptions operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
            
        }
    }
}
