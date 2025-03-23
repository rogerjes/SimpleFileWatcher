using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SimpleFileWatcher
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // specify the directory to monitor (could be read from configuration for more flexibility)
            string directoryToWatch = @"C:\temp\";

            // create a new host to run the background service FileMonitorService
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<FileMonitorService>(provider => new FileMonitorService(directoryToWatch));
                }).
                Build();

            await host.RunAsync();
        }
    }
}
