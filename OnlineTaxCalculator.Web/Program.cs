using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OnlineTaxCalculator.Domain.Builders;
using OnlineTaxCalculator.Domain.Models;

namespace OnlineTaxCalculator.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var employee = new Employee
            {
                Id = 8001185051083,
                FirstName = "Stuart",
                Surname = "Green",
                Age = 40
            };

            var paySlipBuilder = new PaySlipBuilder(employee);

            paySlipBuilder.AddGrossSalary(40000);
            paySlipBuilder.AddMedicalAid(2500);
            paySlipBuilder.AddPension(5000);
            paySlipBuilder.AddParking(150);
            paySlipBuilder.AddVitality(250);

            var paySlip = paySlipBuilder.Build();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
