﻿namespace UpdateQ.Data.Utils
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UpdateQContext>
    {
        public UpdateQContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

            var builder = new DbContextOptionsBuilder<UpdateQContext>();

            var connStr = configuration.GetConnectionString("UpdateQContext");

            builder.UseSqlServer(connStr);
            
            return new UpdateQContext(builder.Options);
        }
    }
}
