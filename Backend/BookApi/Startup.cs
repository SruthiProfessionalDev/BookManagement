public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Allow CORS
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp", builder =>
            {
                builder.WithOrigins("http://localhost:4200")  // Angular app's URL
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Use CORS middleware
        app.UseCors("AllowAngularApp");

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
