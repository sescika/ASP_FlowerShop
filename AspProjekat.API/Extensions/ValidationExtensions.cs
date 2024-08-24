﻿using AspProjekat.API.Dto;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace AspProjekat.API.Extensions
{
	public static class ValidationExtensions	
	{
		public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
		{
			var errors = result.Errors.Select(x => new ValidationError
			{
				Error = x.ErrorMessage,
				Property = x.PropertyName
			});

			return new UnprocessableEntityObjectResult(errors);
		}
	}
}
