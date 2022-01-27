#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Data
{
    public class MVCTestContext : DbContext
    {
        public MVCTestContext (DbContextOptions<MVCTestContext> options)
            : base(options)
        {
        }
        public DbSet<MVCTest.Models.Pernilla> Pernilla { get; set; }

        
    }
}
