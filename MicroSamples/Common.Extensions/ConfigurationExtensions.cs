using Common.Constants;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static string GetDbConnection(this IConfiguration configuration)
        {
            return configuration.GetValue<string>(ConfigurationExtentionConstants.DbConnection);
        }
    }
}
