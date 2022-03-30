using ShoppingList.Constants;

namespace ShoppingList.Configuration
{
    public class DatabaseOptions
    {
        public const string Section = "Database";

        public DbProvider Provider { get; set; }

        public string ConnectionString { get; set; }
    }
}
