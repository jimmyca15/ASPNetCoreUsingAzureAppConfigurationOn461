using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Logging;

namespace AzureAppConfigurationAspNetCore461
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder => {

                    IConfiguration intermediateConfig = builder.Build();

                    string appConfigUri = intermediateConfig["AzureAppConfigurationUri"];

                    if (!string.IsNullOrEmpty(appConfigUri))
                    {
                        builder.AddAzureAppConfiguration(o => o.ConnectWithManagedIdentity(appConfigUri));
                    }

                })
                .UseStartup<Startup>();
    }
}
