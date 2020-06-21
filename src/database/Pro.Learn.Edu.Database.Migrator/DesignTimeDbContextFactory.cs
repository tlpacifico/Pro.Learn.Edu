using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pro.Learn.Edu.Database.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseNpgsql(
                    "Server=127.0.0.1; Port=5432; Database=learnEdu;Uid=postgres;Pwd=1234;",
                    o => o.MigrationsAssembly(GetType().Assembly.FullName))
                .Options;
            return new DatabaseContext(options);
        }
    }
}
