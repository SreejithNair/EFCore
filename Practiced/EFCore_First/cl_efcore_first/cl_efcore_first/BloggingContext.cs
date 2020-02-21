using cl_efcore_first.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


//Trusted_Connection=True, Integrated Security =SSPI, Integrated Security = True all these three property hold same meaning and state that whether or not use windows integrated / windows credentials to log into the database
//If windows credentials are out of scope, then database user name and password must be used explicitly defined in the connection string.
//If connection string include both user name & password and Integrated (Trusted_Connection=True or Integrated Security =SSPI Or Integrated Security = True ) then windows credential will be used and user name & pwd combination is ignored.

namespace cl_efcore_first
{
    public class BloggingContext:DbContext
    {
        //public static readonly ILoggerFactory MyLoggerFactory= LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        //The providerName setting is not required on EF Core connection strings stored in App.config because the database provider is configured via code.
        //You can then read the connection string using the ConfigurationManager API in your context's OnConfiguring method. 
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)            
        {
            //if we were to log details of context

            //It is very important that applications do not create a new ILoggerFactory instance for each context instance. Doing so will result in a memory leak and poor performance.

            //Thats following logic is commented and wanted to find a better method to implement logging for the project.

            //optionBuilder.UseLoggerFactory(MyLoggerFactory); // Warning: Do not create a new ILoggerFactory instance each time





            //Setting connection resilience (EnableRetryOnFailure())

            //Connection resiliency automatically retries failed database commands.
            //The feature can be used with any database by supplying an "execution strategy", which encapsulates the logic necessary to detect failures and retry commands.
            //EF Core providers can supply execution strategies tailored to their specific database failure conditions and optimal retry policies.
              

            // Setting the provider instance
            var connectionString = ConfigurationManager.GetSection("DatabaseLocations:ConnectionStringWin").ToString();
            //set provider as sql or any other data ase you wanted to connect to
            optionBuilder.UseSqlServer(connectionString, options=>options.EnableRetryOnFailure());


            //see EFCore notes for more informations

        }
    }
}
