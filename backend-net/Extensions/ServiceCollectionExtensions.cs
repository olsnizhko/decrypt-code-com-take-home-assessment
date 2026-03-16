using Backend.Data;
using Backend.Services;

namespace Backend.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        services.AddSingleton(MockStore.Load());
        services.AddSingleton<IDashboardService, DashboardService>();
        services.AddSingleton<IOrganizationService, OrganizationService>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IProjectService, ProjectService>();
        services.AddSingleton<ITimeEntryService, TimeEntryService>();
        services.AddSingleton<IInvoiceService, InvoiceService>();

        return services;
    }
}
