using Common.Constants.Global;
using Common.Helpers.Global;
using System;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static string GetDbConnection(this IConfiguration configuration, Type type)
        {
            return configuration.GetValue(
                ConfigurationExtentionConstants.DB_CONNECTION, 
                $"Server=localhost;database={DbNameHelper.GetDbName(type)};user=root;password=test;");
        }
    }
}
