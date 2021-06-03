using System;
using Domain.Common.Mediators.Queries;

namespace Domain.Recipes.Queries.GetById
{
	public class GetByIdQuery : IQuery<RecipeDto>
	{
		public GetByIdQuery()
		{

		}
		public GetByIdQuery(Guid id)
		{
			Id = id;
		}

		public GetByIdQuery(string id)
		{
			Id = Guid.Parse(id);
		}

		public Guid Id
		{
			get;
			set;
		}
	}
}
