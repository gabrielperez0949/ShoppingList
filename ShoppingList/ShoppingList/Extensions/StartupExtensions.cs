using Microsoft.EntityFrameworkCore;
using ShoppingList.Configuration;
using ShoppingList.Constants;
using ShoppingList.Data;
using ShoppingList.Services;
using ShoppingList.Services.Abstractions;

namespace ShoppingList.Extensions
{
    public static class StartupExtensions
    {
        
        public static void RegisterServices(this IServiceCollection Services, IConfiguration configuration)
        {
            // DbContext
            var databaseOptions = new DatabaseOptions();
            configuration.GetSection(DatabaseOptions.Section).Bind(databaseOptions);

            switch (databaseOptions.Provider)
            {
                case DbProvider.MySql:
                    // TODO : Need to test connection
                    Services.AddDbContext<ShoppingListContext>(options => options.UseMySQL(databaseOptions.ConnectionString));
                    break;
                // SqLite should only be used for development purposes. Sql providers above should be used in production environments.
                case DbProvider.SqlLite:
                    var dbPath = Path.Join(Environment.CurrentDirectory, "SqLite", databaseOptions.ConnectionString);
                    Services.AddDbContext<ShoppingListContext>(options => options.UseSqlite($"Data Source={dbPath}").EnableSensitiveDataLogging());
                    break;
            }

            // CRUD Services
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IListItemService, ListItemService>();
            Services.AddScoped<IProductService, ProductService>();

            // Mappers - Generic mapper is registered, but a mapper factory can be created to serve custom mappers from any TView to TEntity if necessary.
            Services.AddScoped<IMapper, Mapper>();
        }
    }
}
