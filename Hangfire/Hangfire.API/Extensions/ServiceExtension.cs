using Hangfire.AspNetCore;
using HangfireBasicAuthenticationFilter;

namespace Hangfire.API.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureHangfireDashboard(this IApplicationBuilder app,
       WebApplicationBuilder webApplicationBuilder, IConfiguration configuration)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {
                DashboardTitle = "Hangfire Dashboard",

                Authorization = new[]{
                new HangfireCustomBasicAuthenticationFilter{
                    User = configuration.GetSection("HangfireCredentials:UserName").Value,
                    Pass = configuration.GetSection("HangfireCredentials:Password").Value
                }
            }
            });
        }
    }
}
