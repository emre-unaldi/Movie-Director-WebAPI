using Core.DataAccess.Abstracts;
using Entity.Entities;

namespace DataAccess.Repositories.Abstracts;

public interface IMovieRepository : IAsyncRepository<Movie, int>
{
}
