using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using edu.VuttraApp.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace edu.VuttraApp.Api.Core.Context
{
    public class VuttraDbContext : DbContext
    {
        public VuttraDbContext(DbContextOptions<VuttraDbContext> options) : base(options)
        {
        }


        public DbSet<Tool> Tools { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}