using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Healthcheck.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            :base(options)
        {

        }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Api> Apies { get; set; }
    }
}
