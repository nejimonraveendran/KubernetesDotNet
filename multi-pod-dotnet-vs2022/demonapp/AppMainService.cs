using dal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonapp
{
    public class AppMainService : IHostedService
    {
        private readonly ILogger<AppMainService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly MyAppDbContext _myAppDbContext;

        public AppMainService(ILogger<AppMainService> logger, IConfiguration configuration,
        IHostApplicationLifetime appLifetime, MyAppDbContext myAppDbContext)
        {
            _logger = logger;
            _configuration = configuration;
            _appLifetime = appLifetime;
            _myAppDbContext = myAppDbContext;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("App starting...");
            _logger.LogInformation("Getting products from DB...");

            try
            {
                var products = _myAppDbContext.Products?.ToList();

                foreach (var item in products)
                {
                    Console.WriteLine($"{item.Id} - {item.ProductName}");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            string? productsApiUrl = Environment.GetEnvironmentVariable("PRODUCTSAPIURL");
            
            if (string.IsNullOrEmpty(productsApiUrl))
            {
                Console.WriteLine("PRODUCTSAPIURL missing in environment variable, trying to retrieve from appsettings.json");
                productsApiUrl = _configuration.GetValue<string>("ProductsApiUrl") ?? string.Empty;
            }

            _logger.LogInformation($"Getting products from Products API at {productsApiUrl}:");

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(productsApiUrl);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                _logger.LogInformation(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }


        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("App stopping...");
            return Task.CompletedTask;
        }
    }
}
