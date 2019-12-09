﻿using System;
using Microsoft.AspNetCore.Mvc;
using WhatShouldIEat.Administration.Api.Validators.IngredientValidators;
using WhatShouldIEat.Administration.Domain.Common.Messages;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Create;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Delete;
using WhatShouldIEat.Administration.Domain.Ingredients.Commands.Update;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredient;
using WhatShouldIEat.Administration.Domain.Ingredients.Queries.GetIngredientsBasicInfos;
using WhatShouldIEat.Administration.Infrastructure.Mediator;

namespace WhatShouldIEat.Administration.Api.Controllers
{
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
		public IActionResult GetIngredient([FromRoute] GetIngredientQuery query)
		{
			var validationResult = _validators.ValidateGet(query);
			if (!validationResult.IsValid)
				return BadRequest(validationResult.Errors.ToString());
			
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
		public IActionResult CreateIngredient([Microsoft.AspNetCore.Mvc.FromBody] CreateIngredientCommand command)
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
		public IActionResult UpdateIngredient([Microsoft.AspNetCore.Mvc.FromBody] UpdateIngredientCommand command)
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