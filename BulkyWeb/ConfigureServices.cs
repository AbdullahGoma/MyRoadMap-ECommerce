using BulkyWeb.Core.Mapping;

namespace BulkyWeb
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //// Connect to database
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            services.AddControllersWithViews();

            

            // Add AutoMapper
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            return services;
        }
    }
    }
