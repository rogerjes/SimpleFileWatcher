using Microsoft.Extensions.Hosting;

namespace SimpleFileWatcher
{
    internal class FileMonitorService: BackgroundService
    {
        private readonly string _directoryToWatch;
        private readonly HashSet<string> _processedFiles = new HashSet<string>();

        public FileMonitorService(string directoryToWatch)
        {
            _directoryToWatch = directoryToWatch;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            Console.WriteLine($"Staring to monitor directory for file additions: {_directoryToWatch}");

            while (!stoppingToken.IsCancellationRequested)
            {
                var files = Directory.GetFiles(_directoryToWatch);

                foreach (var file in files)
                {
                    if (!_processedFiles.Contains(file))
                    {
                        Console.WriteLine($"New file detected: {file}");
                        _processedFiles.Add(file);

                        // add logic here to process the new file as needed
                    }
                }
            }

            // wait a time interval (5 seconds in this example) before checking for new files again
            await Task.Delay(5000, stoppingToken);

        }
    }
}
