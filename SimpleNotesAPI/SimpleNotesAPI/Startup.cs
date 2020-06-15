using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleNotes.API.Data;

namespace SimpleNotes.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();           

            var connectingString = _configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectingString));

            services.AddCors(
                opt =>
                {
                    opt.AddPolicy("CorsPolicy", policy => {
                        policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(new string[] {
                            "http://localhost:4200",
                            "http://localhost:3000"
                        })
                        .AllowCredentials();
                    });
                }
            );

            services.AddTransient<INotesRepository, NotesRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
