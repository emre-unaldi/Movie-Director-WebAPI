using Core.DataAccess.Concretes;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstracts;
using Entity.Entities;

namespace DataAccess.Repositories.Concretes;

public class MovieRepository : EfRepositoryBase<Movie, int, BaseDbContext>, IMovieRepository
{
    public MovieRepository(BaseDbContext context) : base(context)
    {
    }
}
