using Microsoft.Extensions.DependencyInjection;
using WhatShouldIEat.Administration.Domain.Common.Command;
using WhatShouldIEat.Administration.Domain.Common.Query;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;

namespace WhatShouldIEat.Administration.Infrastructure.Mediator
{
	public static class MediatorDiConfiguration
	{
		public static IServiceCollection AddMediator(this IServiceCollection services)
		{
			services.AddScoped<IMediator, Mediator>();

			services.Scan(scan =>
				scan
					.FromAssemblyOf<CreateIngredientCommand>()
					.AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime()
					.AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
					.AsImplementedInterfaces()
					.WithTransientLifetime());

			return services;
		}
	}
}