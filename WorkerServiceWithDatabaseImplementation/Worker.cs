using WorkerServiceWithDatabaseImplementation.Models;
using WorkerServiceWithDatabaseImplementation.Services;

namespace WorkerServiceWithDatabaseImplementation
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly TimeSpan _time = TimeSpan.FromSeconds(5);
        private readonly IService _service;

        public Worker(ILogger<Worker> logger,IService service)
        {
            _logger = logger;
            _service = service;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_time);
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                Random random = new Random();
                Details detail = new Details()
                {
                    ID = random.Next(0, 1000000),
                    DateTime = DateTime.Now
                };
                bool k = _service.AddDetails(detail);
                if (k)
                {
                    _logger.LogInformation("Data Inserted");
                }
                else
                {
                    _logger.LogInformation("Data Not Inserted");

                }
            }
        }
    }
}