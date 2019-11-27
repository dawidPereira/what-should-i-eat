using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators;
using WhatShouldIEat.Administration.Domain.Common.Mediator;
using WhatShouldIEat.Administration.Domain.Common.Messages;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Entities;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredient;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredientsBasicInfos;

namespace WhatShouldIEat.Administration.Api.Controllers
{
	[Route("api/ingredient")]
	[ApiController]
	public class IngredientController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IIngredientValidatorsFacade _validators;

		public IngredientController(IMediator mediator, IIngredientValidatorsFacade validators)
		{
			_mediator = mediator;
			_validators = validators;
		}

		/// <summary>
		/// Gets Ingredient by Id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// 	GET api/ingredient{ingredientId}
		/// </remarks>
		/// <param name="query"></param>
		/// <returns></returns>
		/// <response code="200">Ingredient found</response>
		/// <response code="404">Given ingredient was not found</response>
		[HttpGet]
		[Route("/{ingredientId}")]
		[ProducesResponseType(typeof(Ingredient), 200)]
		[ProducesResponseType(404)]
		public IActionResult GetIngredient([FromRoute] GetIngredientQuery query)
		{
			var validationResult = _validators.ValidateGet(query);
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
		/// Gets list of Ingredient basic infos
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// 	GET api/ingredient/basicInfos
		/// </remarks>
		/// <param name="query"></param>
		/// <returns></returns>
		/// <response code="200">BasicInfos found</response>
		[HttpGet]
		[Route("/basicInfos")]
		[ProducesResponseType(typeof(List<IngredientBasicInfo>), 200)]
		public IActionResult GetBasicInfos(GetIngredientsBasicInfosQuery query) => 
			Ok(_mediator.Query(query));


		/// <summary>
		/// Create new Ingredient
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// 	POST api/ingredient/create
		/// </remarks>
		/// <param name="command"></param>
		/// <returns></returns>
		/// <response code="201">Ingredient created</response>
		/// <response code="400">Bad request</response>
		[HttpPost]
		[Route("/create")]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		public IActionResult CreateIngredient([FromBody] CreateIngredientCommand command)
		{
			var validationResult = _validators.ValidateCreate(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			var result = _mediator.Command(command);

			if (result.IsSuccess)
				return Created($"api/ingredient{command.Id.ToString()}", result);

			return BadRequest(result);
		}

		/// <summary>
		/// Update given Ingredient
		/// </summary>
		/// /// <remarks>
		/// Sample request:
		/// 	POST api/ingredient/update
		/// </remarks>
		/// <param name="command"></param>
		/// <returns></returns>
		/// <response code="200">Ingredient updated</response>
		/// <response code="400">Bad request</response>
		/// <response code="404">Ingredient not found</response>
		[HttpPut]
		[Route("/update")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public IActionResult UpdateIngredient([FromBody] UpdateIngredientCommand command)
		{
			var validationResult = _validators.ValidateUpdate(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			var result = _mediator.Command(command);

			if (!result.IsFailure) return Ok(result);
			
			if (result.ResultCode.Equals(ResultCode.NotFound))
				return NotFound(result);
			
			return BadRequest(result);
		}

		/// <summary>
		/// Delete given Ingredient
		/// </summary>
		/// /// <remarks>
		/// Sample request:
		/// 	POST api/ingredient/delete/{ingredientId}
		/// </remarks>
		/// <param name="command"></param>
		/// <returns></returns>
		/// <response code="200">Ingredient deleted</response>
		/// <response code="400">Bad request</response>
		/// <response code="404">Ingredient not found</response>
		[HttpDelete]
		[Route("/delete/{ingredientId}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public IActionResult DeleteIngredient([FromRoute] DeleteIngredientCommand command)
		{
			var validationResult = _validators.ValidateDelete(command);
			if (!validationResult.IsValid)
				return BadRequest(validationResult);

			var result = _mediator.Command(command);

			if (!result.IsFailure) return Ok(result);
			
			if (result.ResultCode.Equals(ResultCode.NotFound))
				return NotFound(result);
			
			return BadRequest(result);
		}
	}
}