using Api.Validators;
using Domain.Common.Mediators.Validators;
using Domain.Recipes.Filters.Factories;
using Domain.Recipes.Repositories;
using EasyCaching.Core.Configurations;
using Hangfire;
using Infrastructure.Common;
using Infrastructure.DbContexts;
using Infrastructure.Events.EventPublishers;
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

		private IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddDbContext<AdministrationDbContext>(options =>
					options.UseSqlServer(Configuration.GetConnectionString(Constants.WhatShouldIEatDataBaseName),
						b => b.MigrationsAssembly(Constants.WhatShouldIEatDataBaseMigrationAssembly)
					));
			services
				.AddEasyCaching(options =>
				{
					options.UseRedis(redisConfig =>
					{
						redisConfig.DBConfig.Endpoints.Add(new ServerEndPoint(Constants.RedisHost, Constants.RedisPort));
						redisConfig.DBConfig.AllowAdmin = true;
					},
						Constants.RedisName);
				});
			
			services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString(Constants.HangFireDataBaseName)));
			services.AddHangfireServer();
			
			services.AddMediator();
			services.AddEventPublisher();
			services.AddControllers();
			services.AddRepositories();
			services.AddDomainValidators();
			services.AddRequestValidators();
			services.AddControllers()
				.AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
			services.AddTransient<IRecipeSearchInfoRepository, RecipeSearchInfoRepository>();
			services.AddTransient<IFilterFactory, FilterFactory>();
		}

		public void Configure(IApplicationBuilder app,
			IWebHostEnvironment env,
			IBackgroundJobClient backgroundJobs,
			IRecipeSearchInfoRepository recipeSearchInfoRepository)
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
			backgroundJobs.Enqueue(() => recipeSearchInfoRepository.BuildRecipeSearchInfo() );
		}
	}
}