using AdventureManagement.BUS.Service.Implement;
using AdventureManagement.BUS.Service.Interface;
using AdventureManagement.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace AdventureManagement.Winform
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Khởi tạo DI container
            var host = CreateHostBuilder().Build();

            // Khởi tạo Application
            ApplicationConfiguration.Initialize();

            // Lấy instance của Form1 từ DI container và chạy ứng dụng
            var form1 = host.Services.GetRequiredService<Form1>();
            Application.Run(form1);
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                       .ConfigureServices((context, services) =>
                       {
                           // Đăng ký DbContext
                           services.AddDbContext<AppDbContext>();

                           // Đăng ký các services
                           services.AddScoped<IParticipantService, ParticipantService>();

                           // Đăng ký Form1
                           services.AddTransient<Form1>();
                       });
        }
    }
}
