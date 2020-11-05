using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Pro.Learn.Edu.Database.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                 .UseMySql(
                    "Server=localhost;Port=52320;Database=LearnEdu;Uid=learn-edu-user;Pwd=47pwzg9T6pdUeAzF;",
                    o => o.MigrationsAssembly(GetType().Assembly.FullName))
                .Options;
            return new DatabaseContext(options);
        }
    }
}
