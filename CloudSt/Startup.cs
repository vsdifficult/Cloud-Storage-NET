using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using CloudST.Services.StorageS3; 
using CloudST.Database; 
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cloud ST API", Version = "v1" });
        });
        services.AddScoped<IS3Service, S3Service>(); 
        services.AddScoped<DBService>(); 
        services.AddCors(
            options => 
            { 
                options.AddPolicy("AllowAll", builder => 
                    { 
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader(); 
                    }
                ); 
            }
        ); 
    }

    public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cloud ST API V1");
            c.RoutePrefix = string.Empty; 
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=User }/{action=Index}/{id?}");
        });
    }
}