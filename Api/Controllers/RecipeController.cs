using System;
using Api.Validators.RecipeValidators;
using Domain.Common.Messages;
using Domain.Recipes.Commands.Create;
using Domain.Recipes.Commands.Delete;
using Domain.Recipes.Commands.Update;
using Domain.Recipes.Queries.GetRecipe;
using Domain.Recipes.Queries.GetRecipesBasicInfos;
using Infrastructure.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	public class RecipeController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IRecipeValidatorsFacade _validators;

		public RecipeController(IMediator mediator, IRecipeValidatorsFacade validators)
		{
			_mediator = mediator;
			_validators = validators;
		}

		/// <summary>
		/// Gets Recipe by Id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// 	GET api/recipe{recipeId}
		/// </remarks>
		/// <param name="query"></param>
		/// <returns></returns>
		/// <response code="200">Recipe found</response>
		/// <response code="404">Given recipe was not found</response>
		[HttpGet]
		public IActionResult GetRecipe([FromRoute] GetRecipeQuery query)
		{
			var validationResult = _validators.ValidateGet(query);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			try
			{
				var result = _mediator.Query(query);
				return Ok(result);
			}
			catch (Exception ex) when (ex.InnerException is ArgumentNullException)
			{
				return NotFound(ex.InnerException.Message);
			}
		}

		/// <summary>
		/// Gets list of Recipe basic infos
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// 	GET api/recipe/basicInfos
		/// </remarks>
		/// <param name="query"></param>
		/// <returns></returns>
		/// <response code="200">BasicInfos found</response>
		[HttpGet]
		public IActionResult GetBasicInfos(GetRecipesBasicInfosQuery query) =>
			Ok(_mediator.Query(query));

		/// <summary>
		/// Create new Recipe
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// 	POST api/recipe/create
		/// </remarks>
		/// <param name="command"></param>
		/// <returns></returns>
		/// <response code="201">Recipe created</response>
		/// <response code="400">Bad request</response>
		[HttpPost]
		public IActionResult CreateRecipe([FromBody] CreateRecipeCommand command)
		{
			var validationResult = _validators.ValidateCreate(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			var result = _mediator.Command(command);

			if (!result.IsFailure)
				return Created($"api/recipe{command.Id.ToString()}", result);

			if (result.ResultCode.Equals(ResultCode.NotFound))
				return NotFound(result);

			return BadRequest(result);
		}

		/// <summary>
		/// Update given Recipe
		/// </summary>
		/// /// <remarks>
		/// Sample request:
		/// 	POST api/recipe/update
		/// </remarks>
		/// <param name="command"></param>
		/// <returns></returns>
		/// <response code="200">Recipe updated</response>
		/// <response code="400">Bad request</response>
		/// <response code="404">Recipe not found</response>
		[HttpPut]
		public IActionResult UpdateRecipe([FromBody] UpdateRecipeCommand command)
		{
			var validationResult = _validators.ValidateUpdate(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			var result = _mediator.Command(command);

			if (!result.IsFailure) return Ok(result);

			if (result.ResultCode.Equals(ResultCode.NotFound))
				return NotFound();

			return BadRequest(result);
		}
		
		/// <summary>
		/// Delete given Recipe
		/// </summary>
		/// /// <remarks>
		/// Sample request:
		/// 	POST api/recipe/delete/{recipeId}
		/// </remarks>
		/// <param name="command"></param>
		/// <returns></returns>
		/// <response code="200">Recipe deleted</response>
		/// <response code="400">Bad request</response>
		/// <response code="404">Ingredient not found</response>
		[HttpDelete]
		public IActionResult DeleteRecipe([FromRoute] DeleteRecipeCommand command)
		{
			var validationResult = _validators.ValidateDelete(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult.Errors.ToString());

			var result = _mediator.Command(command);

			if (!result.IsFailure) return Ok(result);
			
			return NotFound();
		}
	}
}