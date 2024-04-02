using EMS.Services.Implementation;
using EMS.Services.Interface;

namespace EMS.Dependency
{
     public static class DependencyInjection
    {
       /* public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeInfoService, EmployeeInfoService>();
            services.AddScoped<ISetUpDepertmentInfoService, SetUpDepertmentInfoService>();
        }*/
       public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeInfoService, EmployeeInfoService>();
            services.AddScoped<ISetUpDepertmentInfoService, SetUpDepertmentInfoService>();
            return services;
        }
    }
}
