using Core.DataAccess.Abstracts;
using Entity.Entities;

namespace DataAccess.Repositories.Abstracts;

public interface IDirectorRepository : IAsyncRepository<Director, int>
{
}
