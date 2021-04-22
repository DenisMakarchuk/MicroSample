using Common.Helpers.Global;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Common.Extensions
{
    public class DbContextFactory<TContextImplementation> : IDesignTimeDbContextFactory<TContextImplementation> where TContextImplementation : DbContext
    {
        public TContextImplementation CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContextImplementation>();
            optionsBuilder.UseMySql($"Server=localhost;database={DbNameHelper.GetDbName(typeof(TContextImplementation))};user=root;password=test;");
            return (TContextImplementation)Activator.CreateInstance(typeof(TContextImplementation),optionsBuilder.Options);
        }
    }
}
