﻿using Domain.Ingredients.Commands.Create;
using Domain.Mediators.Command;
using Domain.Mediators.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mediator
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