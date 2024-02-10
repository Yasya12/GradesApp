using Grades.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Grades.Application.IRepositories;
using Grades.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Grades.Persistence
{
	public static class DependencyInjection
	{
		public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string is null or empty.");
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			services.AddScoped<IFacultyRepository, FacultyRepository>();
			services.AddScoped<ISemesterRepository, SemesterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            /*services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();*/

        }
    }
}
