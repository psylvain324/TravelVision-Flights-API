using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using TravelVision_Flights_API.Controllers;
using TravelVision_Flights_API.Data;
using TravelVision_Flights_API.Interfaces;
using TravelVision_Flights_API.Services;

namespace TravelVision_Flights_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(databaseName: "TravelVisionFlightsDb"));

            services.TryAddTransient(s =>
            {
                return s.GetRequiredService<IHttpClientFactory>().CreateClient(string.Empty);
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("https://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowAnyOrigin());
            });

            services.AddControllers();
            services.AddMvc();
            services.AddResponseCaching();

            services.AddTransient<IWeatherService, WeatherService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddHttpClient<BookingController>();
            services.AddHttpClient<FlightsController>();
            services.AddHttpClient<WeatherController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Travel Vision - Flights");
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseResponseCaching();
        }
    }
}
