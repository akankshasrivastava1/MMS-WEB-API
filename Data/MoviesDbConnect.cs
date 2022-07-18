using Microsoft.EntityFrameworkCore;
using MMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Data
{
    public class MoviesDbConnect : DbContext
    {
        public MoviesDbConnect(DbContextOptions<MoviesDbConnect> options) : base(options)
        {

        }
        public DbSet<Movies> movies { get; set; }
        public object Movies { get; internal set; }
    }
}
