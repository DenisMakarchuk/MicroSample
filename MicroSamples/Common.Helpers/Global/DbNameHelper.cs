using System;

namespace Common.Helpers.Global
{
    public static class DbNameHelper
    {
        public static string GetDbName(Type type)
        {
            return type.Name.Replace("Context", "");
        }
    }
}
