using Domain.Recipes.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Recipes.Services
{
	public static class ServicesDiConfiguration
	{
		public static IServiceCollection AddDomainServices(this IServiceCollection services)
		{
			services.AddScoped<IImageUploader, ImageUploader>();
			return services;
		}
	}
}