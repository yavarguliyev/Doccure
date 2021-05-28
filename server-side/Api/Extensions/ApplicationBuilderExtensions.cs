using Api.Hubs;
using Api.Hubs.ChatUsers;
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

      if (env.IsDevelopment())
      {
        app.UseSwaggerDocumentation();
      }
      else
      {
        app.Use(async (context, next) =>
        {
          context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000");
          await next.Invoke();
        });
      }

      app.UseHttpsRedirection();

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
        endpoints.MapHub<PresenceHub>("hubs/presence");
        endpoints.MapHub<ChatHub>("hubs/chat");
        endpoints.MapHub<ReviewHub>("hubs/review");
        endpoints.MapHub<CommentHub>("hubs/comment");
        endpoints.MapFallbackToController("index", "fallback");
      });

      return app;
    }
  }
}