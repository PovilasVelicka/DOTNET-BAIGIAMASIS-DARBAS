using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteBook.AccessData.Repositories;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Entity.Models;

namespace NoteBook.AccessData.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NoteBookDb")));


            services.AddScoped<IAccountsRepository, AccountsRepository>( );
            services.AddScoped<INotesRepository, NotesRepository>( );
            return services;
        }
    }
}
