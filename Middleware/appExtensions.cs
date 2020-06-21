using Lab1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Middleware
{
	public class LogMiddleware
	{
		private readonly RequestDelegate _next;
		public LogMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, ILoggerFactory factory)
		{
			// получить текущее время 
			var time = DateTime.Now;

			// передать управление следующему компоненту в конвейере 
			await _next(context);

			// получить код состояния ответа 
			var statusCode = context.Response.StatusCode;
			if (statusCode != StatusCodes.Status200OK)
			{
				// получить логер 
				var logger = factory.CreateLogger<FileLogger<object>>();
				// записать информацию в лог 
				logger.LogInformation($"{time.ToShortDateString()}-{ time.ToLongTimeString()}: " + $"url: {context.Request.Path}" +
					$"{context.Request.QueryString} returns { statusCode}");
			}
		}
	}
}
