using Common.Constants;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static string GetDbConnection(this IConfiguration configuration, string dbName)
        {
            return configuration.GetValue(
                ConfigurationExtentionConstants.DbConnection, 
                $"Server=localhost;database={dbName};user=root;password=test;");
        }
    }
}
