using Application.Interface.MenuItem;
using Application.Interface.Order;
using Application.Interface.Reports;
using Application.Interface.Restaurant;
using Application.Interface.Roles;
using Application.Interface.Rservation;
using Application.Interface.RservationStatus;
using Application.Interface.TableSettings;
using Application.Interface.User;
using Application.Reporting;
using Application.Reporting.IReport;
using Application.Repository.Dashboard;
using Application.Repository.MenuItem;
using Application.Repository.OrderRepository;
using Application.Repository.Reservation;
using Application.Repository.ReservationStatus;
using Application.Repository.Restaurant;
using Application.Repository.TableSettings;
using Application.Repository.User;
using Application.Repository.UserRoles;
using Microsoft.Extensions.DependencyInjection;

namespace Application.WebApi.Dependancy_Injection
{
    public static class ServiceExtension
    {
        public static void ConfigureTransient(this IServiceCollection services)
        {
            services.AddTransient<IExternalUser, ExternalUserRepository>();
            services.AddTransient<IExternalUserRole, ExternalUserRoleRepository>();
            services.AddTransient<IRole, RoleRepository>();
            services.AddTransient<IOrder, OrderRepository>();
            services.AddTransient<IReservation, ReservationRepository>();
            services.AddTransient<IRestaurant, RestaurantRepository>();
            services.AddTransient<ITableSettings, TableSettingsRepository>();
            services.AddTransient<IReservationStatus, ReservationStatusRepository>();
            services.AddTransient<IMenuItem, MenuItemRepository>();
            services.AddTransient<IDashboard, DashboardRepository>();
            services.AddTransient<IReport, ReportService>();
        }
    }
}
