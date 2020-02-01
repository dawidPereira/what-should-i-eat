using Domain.Common.Mediators;
using Domain.RecipesDetails.Queries.Find;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	public class RecipeDetailsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RecipeDetailsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public IActionResult FindRecipeDetails([FromBody] FindRecipeDetailsQuery query)
		{
			var result = _mediator.Query(query);
			return Ok(result);
		}
	}
}