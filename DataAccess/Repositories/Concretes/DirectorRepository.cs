using Core.DataAccess.Concretes;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstracts;
using Entity.Entities;

namespace DataAccess.Repositories.Concretes;

public class DirectorRepository : EfRepositoryBase<Director, int, BaseDbContext>, IDirectorRepository
{
    public DirectorRepository(BaseDbContext context) : base(context)
    {
    }
}
