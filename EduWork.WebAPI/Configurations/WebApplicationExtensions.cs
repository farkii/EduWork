using EduWork.Data;
using Microsoft.EntityFrameworkCore;

namespace EduWork.WebAPI.Configurations
{
    public static class WebApplicationExtensions
    {
        public static void AllAppConfigurations(this WebApplication app, WebApplicationBuilder builder) {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.OAuthClientId(builder.Configuration["SwaggerAzureAd:ClientId"]);
                    options.OAuthUsePkce();
                });
            }

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
