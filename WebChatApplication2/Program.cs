using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WebChatApplication2.Data;

namespace WebChatApplication2
{
    /// <summary>
    /// Entry point for web host.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method of program. Builds a web host for application,
        /// initializes DB with data if necessary and runs web application.
        /// </summary>
        /// <param name="args">Array of arguments</param>
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ChatContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        /// <summary>
        /// Builds web host.
        /// </summary>
        /// <param name="args">Array of arguments</param>
        /// <returns>Web host for application</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
