using System.Net.Http;
using BusinessLayer.Helpers;
using CommonLayer;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace BackOffice.Web.MVC.Configurations
{
    public static class ServiceConfigurations
    {
        public static void AppServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database

            services.AddDbContextPool<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UTM_Notification")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            #region Http Clients

            services.AddHttpClient(Constants.FetchDataHttpClientName).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                //handler.ClientCertificates.Add(CertificateHelper.LoadPrivateCertificate(
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePath"),
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePassword")));
                return handler;
            });

            #endregion

            #region App Services

            services.AddScoped<IFetchDataService, FetchDataService>();
            services.AddScoped<IFetchDataClient, FetchDataHttpClient>();
            services.AddScoped<ISenderService, SenderService>();

            #endregion

            #region Helpers

            services.AddScoped<SenderHelper>();
            services.AddScoped<ReceiverHelper>();

            #endregion

            services.AddControllersWithViews();
        }
    }
}
