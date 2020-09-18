using Microsoft.Extensions.DependencyInjection;
using SimpleNotes.DAL.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace SimpleNotes.BLL.Helpers
{
    public static class DataInitializer
    {
        public static void DataInit(this IServiceCollection services, IConfiguration configuration)
        {
            /* To use real repositoory */

            //services.AddTransient<INotesRepository, NotesRepository>();
            //var connectingString = configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(connectingString));


            /* To use mocked repositoory */
            services.AddSingleton<INotesRepository, MockedNotesRepository>();
        }
    }
}
