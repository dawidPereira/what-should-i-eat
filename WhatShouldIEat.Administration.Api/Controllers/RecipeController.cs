using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WhatShouldIEat.Administration.Api.Validators.RecipeValidators;
using WhatShouldIEat.Administration.Api.Validators.RecipeValidators.QueryValidators;
using WhatShouldIEat.Administration.Domain.Common.Mediator;
using WhatShouldIEat.Administration.Domain.Recipes.Commands;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Create;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Recipes.Commands.Update;
using WhatShouldIEat.Administration.Domain.Recipes.Entities;
using WhatShouldIEat.Administration.Domain.Recipes.Queries;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecipe;
using WhatShouldIEat.Administration.Domain.Recipes.Queries.GetRecuoesBasisInfos;

namespace WhatShouldIEat.Administration.Api.Controllers
{
	[Route("api/recipe")]
	[ApiController]
	public class RecipeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RecipeController(IMediator mediator)
		{
			_mediator = mediator;
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
		[Route("/{recipeId")]
		[ProducesResponseType(typeof(Recipe), 200)]
		[ProducesResponseType(404)]
		public IActionResult GetRecipe([FromRoute] GetRecipeQuery query)
		{
			var validationResult = new GetRecipeQueryValidator().Validate(query);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			try
			{
				var result = _mediator.Query(query);
				return Ok(result);
			}
			catch (ArgumentNullException e)
			{
				return NotFound(e.Message);
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
		[Route("/basicInfos")]
		[ProducesResponseType(typeof(List<RecipeBasicInfo>), 200)]
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
		[Route("/create")]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		public IActionResult CreateRecipe([FromBody] CreateRecipeCommand command)
		{
			var validationResult = new CreateRecipeCommandValidator().Validate(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			var result = _mediator.Command(command);

			if (!result.IsFailure)
				return Created($"api/recipe{command.Id.ToString()}", result);

			if (result.HttpCode.Equals("404"))
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
		[Route("/update")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public IActionResult UpdateRecipe([FromBody] UpdateRecipeCommand command)
		{
			var validationResult = new UpdateRecipeCommandValidator().Validate(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			var result = _mediator.Command(command);

			if (!result.IsFailure) return Ok(result);

			if (result.HttpCode.Equals("404"))
				return NotFound(result);

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
		[Route("/delete/{recipeId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public IActionResult DeleteRecipe([FromRoute] DeleteRecipeCommand command)
		{
			var validationResult = new DeleteRecipeCommandValidator().Validate(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			var result = _mediator.Command(command);

			if (!result.IsFailure) return Ok(result);
			
			return NotFound(result);
		}
	}
}