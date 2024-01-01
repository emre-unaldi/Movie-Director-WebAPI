using DataAccess.Contexts;
using DataAccess.Repositories.Abstracts;
using DataAccess.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("MovieDirectorDB")));
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();

        return services;
    }
}