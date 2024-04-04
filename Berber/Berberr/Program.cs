using Barber.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Barber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<BarberDbContext>();
                    
                    var newBarber = new Barbers
                    {
                        UserName = "Example Barber",
                        WorkPlaceName = "Example Workplace"
                    };
                    context.Barbers.Add(newBarber);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Veritabaný seedleme hatasý: " + ex.Message);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
