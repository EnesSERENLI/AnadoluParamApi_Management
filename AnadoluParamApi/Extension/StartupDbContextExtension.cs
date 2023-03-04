using AnadoluParamApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace AnadoluParamApi.Extension
{
    public static class StartupDbContextExtension
    {
        public static void AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            var dbtype = configuration.GetConnectionString("DbType");
            if (dbtype == "SQL")
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });
            }
            else if (dbtype == "Mongo")
            {
                var connectionString = configuration.GetConnectionString("MongoConnection");
                string databaseName = configuration.GetConnectionString("DatabaseName");
                MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionString);
                MongoClient mongoClient = new MongoClient(settings);
                IMongoDatabase database = mongoClient.GetDatabase(databaseName);

                services.AddSingleton(database);
            }
        }
    }
}
