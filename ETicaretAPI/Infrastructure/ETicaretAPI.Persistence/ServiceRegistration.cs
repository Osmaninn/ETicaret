using ETicaretAPI.Applicaton.Abstractions.Services;
using ETicaretAPI.Applicaton.Abstractions.Token;
using ETicaretAPI.Applicaton.Repositories.ProductRepository;
using ETicaretAPI.Applicaton.Repositories.UserRepository;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Repositories.ProductRepository;
using ETicaretAPI.Persistence.Repositories.UserRepository;
using ETicaretAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");
            //ConnectionString adlı siteden bak
            services.AddDbContext<Context>(options => options.UseSqlServer(configurationManager.GetConnectionString("SqlServer")));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
           
        }
    }
}
