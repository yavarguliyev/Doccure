using Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api.Extensions
{
  public static class ApplicationBuilderExtensions
  {
    public static IApplicationBuilder AddApplicationBuilders(this IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseMiddleware<ErrorHandlingMiddleware>();

      if (env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(s =>
        {
          s.RoutePrefix = "";
          s.DocumentTitle = "Swagger Documentation";
          s.SwaggerEndpoint("/swagger/v1/swagger.json", "api/v1");
        });

        app.UseHttpsRedirection();
      }

      app.UseRouting();

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseCors("CorsPolicy");

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapFallbackToController("index", "fallback");
      });

      return app;
    }
  }
}