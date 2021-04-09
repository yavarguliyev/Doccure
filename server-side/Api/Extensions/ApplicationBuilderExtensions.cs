using System;
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
        app.UseSwaggerDocumentation();
      }

      app.UseHsts(options => options.MaxAge(days: 30)); 
      app.UseHttpsRedirection();

      app.UseXContentTypeOptions();
      app.UseReferrerPolicy(opt => opt.NoReferrer());
      app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
      app.UseXfo(opt => opt.Deny());
      app.UseCsp(opt => opt
         .BlockAllMixedContent()
         //.StyleSources(s => s.Self().CustomSources())
         //.FontSources(s => s.Self().CustomSources())
         //.FormActions(s => s.Self().CustomSources())
         //.FrameAncestors(s => s.Self().CustomSources())
         //.ImageSources(s => s.Self().CustomSources())
         //.ScriptSources(s => s.Self().CustomSources())
         );

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