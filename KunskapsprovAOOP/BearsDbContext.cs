using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KunskapsprovAOOP.Context
{
    public class BearsDbContext : DbContext
    {

        private const string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=KunskapsprovDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Bear> favouritebears { get; set; }

    }
}
