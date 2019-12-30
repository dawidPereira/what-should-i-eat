using Api.Validators;
using Domain.Common.Filters;
using Domain.Common.Mediators;
using Domain.Common.Mediators.Validators;
using Domain.RecipesDetails.Entities;
using Domain.RecipesDetails.Filters.Factories;
using Domain.RecipesDetails.Filters.FiltersCriteria;
using EasyCaching.Core.Configurations;
using Hangfire;
using Infrastructure.Common.Configuration;
using Infrastructure.Common.Constants;
using Infrastructure.DbContexts;
using Infrastructure.Events.EventPublishers;
using Infrastructure.Mappers;
using Infrastructure.Mediator;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private static IConfiguration Configuration { get; set; }

		public static IConfiguration GetConfiguration => Configuration;

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AdministrationDbContext>(options =>
					options.UseSqlServer(Configuration.GetConnectionString(DbContextConstants.WhatShouldIEatDataBaseName),
						b => b.MigrationsAssembly(DbContextConstants.WhatShouldIEatDataBaseMigrationAssembly)
					));
			services.AddEasyCaching(options =>
				{
					options.UseRedis(redisConfig =>
					{
						redisConfig.DBConfig.Endpoints.Add(new ServerEndPoint(RedisConstants.Host, RedisConstants.Port));
						redisConfig.DBConfig.AllowAdmin = true;
					},
						RedisConstants.Name);
				});
			
			services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString(DbContextConstants.HangFireDataBaseName)));
			services.AddHangfireServer();
			services.AddControllers();
			services.AddRepositories();
			services.AddMappers();
			services.AddDomainValidators();
			services.AddRequestValidators();
			services.AddEvents();
			services.AddMediator();
			services.AddFactories();
			services.AddControllers()
				.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
			//services.AddTransient<IRecipeDetailsRepository, RecipeDetailsRepository>();
			services.AddTransient<IFilterFactory<RecipeDetails, RecipeSearchFilterCriteria>, RecipeFiltersFactory>();
		}

		public void Configure(IApplicationBuilder app,
			IWebHostEnvironment env,
			IMediator mediator)
		{
			
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseEndpoints(x => x.MapControllerRoute(
				"Api_Default",
				"api/{controller=Recipe}/{action=GetBasicInfos}/{id?}"));

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthorization();
			app.UseHangfireDashboard();
			//mediator.Command(new BuildAllRecipesDetailsCommand());
		}
	}
}