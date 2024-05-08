using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using BusinessLogic;
using DataAccessLayer;
using Microsoft.Extensions.Logging;
using DataAccessLayer.UnitTestInterfaces;

namespace DesktopApp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            Application.Run(ServiceProvider.GetRequiredService<Login>());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddScoped<UserManager>();
            services.AddScoped<Login>();

            services.AddLogging(configure => configure.AddConsole());

            services.AddScoped<DoctorDAL>();
            services.AddScoped<DoctorManager>();
            services.AddScoped<AdministratorDAL>();
            services.AddScoped<AdministratorManager>();
            services.AddScoped<SearchPatients>();
            services.AddLogging();
        }
    }
}