using AnadoluParamApi.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnadoluParamApi.Extension
{
    public static class StartupDbContextExtention
    {
        public static void AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            //var dbtype = configuration.GetConnectionString("DbType");
            //if (dbtype == "SQL")
            //{
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            //}
            //else if (dbtype == "PostgreSQL")
            //{
            //    var dbConfig = configuration.GetConnectionString("PostgreSqlConnection");
            //    services.AddDbContext<AppDbContext>(options => options
            //       .UseNpgsql(dbConfig)
            //       );
            //}
        }
    }
}
