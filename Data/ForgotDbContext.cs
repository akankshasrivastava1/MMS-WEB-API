using Microsoft.EntityFrameworkCore;
using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Data
{
    public class ForgotDbContext : DbContext
    {
        public ForgotDbContext(DbContextOptions<ForgotDbContext> options) : base(options)
        {

        }
        public DbSet<Forgot> forgot { get; set; }
    }
}
