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
            if (env.IsDevelopment())
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
                app.UseSwagger();
                app.UseSwaggerUI(s =>
                {
                    s.RoutePrefix = "";
                    s.DocumentTitle = "Swagger Documentation";
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "api/v1");
                });
            }
            else if (env.IsProduction())
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(x => x
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders("WWW-Authenticate")
                            .WithOrigins("http://localhost:4200", "https://localhost:4200")
                            .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}