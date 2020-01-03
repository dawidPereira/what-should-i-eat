using System;
using Api.Validators.IngredientValidators;
using Domain.Common.Mediators;
using Domain.Common.Messages;
using Domain.Events;
using Domain.Ingredients.Commands.Create;
using Domain.Ingredients.Commands.Delete;
using Domain.Ingredients.Commands.Update;
using Domain.Ingredients.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	public class IngredientController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IEventPublisher _eventPublisher;
		private readonly IIngredientValidatorsFacade _validators;

		public IngredientController(IMediator mediator, IIngredientValidatorsFacade validators, IEventPublisher eventPublisher)
		{
			_mediator = mediator;
			_validators = validators;
			_eventPublisher = eventPublisher;
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
		public IActionResult CreateIngredient([FromBody] CreateIngredientCommand command)
		{
			_eventPublisher.Rise();
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