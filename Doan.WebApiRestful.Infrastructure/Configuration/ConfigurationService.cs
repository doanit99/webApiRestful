using Microsoft.Extensions.DependencyInjection;
using Doan.WebApiRestful.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Doan.WebApiRestful.Data.Abstract;
using Doan.WebApiRestful.Service;

namespace Doan.WebApiRestful.Infrastructure.Configuration
{
	public static class ConfigurationService
	{
		public static void RegisterContextDb(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddDbContext<WebApiContext>(options => options
				.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
				options => options.MigrationsAssembly(typeof(WebApiContext).Assembly.FullName)));
		}
		public static void RegisterDI(this IServiceCollection service)
		{
			service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			service.AddScoped<IDapperHelper, DapperHelper>();

			service.AddScoped<ICategoryService, CategoryService>();
		}
	}
}
