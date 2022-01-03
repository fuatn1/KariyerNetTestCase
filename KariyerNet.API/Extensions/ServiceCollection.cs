using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.API.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services,
           IConfiguration configuration)
        {
            return services.Configure<Data.Configurations.MongoDbSettings>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection(nameof(Data.Configurations.MongoDbSettings) + ":" + Data.Configurations.MongoDbSettings.ConnectionStringValue).Value;
                options.Database = configuration
                    .GetSection(nameof(Data.Configurations.MongoDbSettings) + ":" + Data.Configurations.MongoDbSettings.DatabaseValue).Value;
            });
        }
    }
}
