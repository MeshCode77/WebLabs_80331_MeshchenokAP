using Microsoft.AspNetCore.Builder;
using Lab1.Middleware;

namespace Lab1.Extensions
{
	public static class AppExtensions
	{
		public static IApplicationBuilder UseLogging(this IApplicationBuilder app)
		{
			return app.UseMiddleware<LogMiddleware>();
		}
	}
}
