using EasyCaching.Core.Configurations;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using WhatShouldIEat.Administration.Api.Validators;
using WhatShouldIEat.Administration.Domain.Common.Validators;
using WhatShouldIEat.Administration.Domain.Recipes.Repositories;
using WhatShouldIEat.Administration.Infrastructure.Common;
using WhatShouldIEat.Administration.Infrastructure.DbContexts;
using WhatShouldIEat.Administration.Infrastructure.Events.EventPublishers;
using WhatShouldIEat.Administration.Infrastructure.Mediator;
using WhatShouldIEat.Administration.Infrastructure.Repositories;

namespace WhatShouldIEat.Administration.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
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
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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