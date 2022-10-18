using Generics.Data;
using Generics.Models;

namespace Generics.Repository
{
    public class DirectorRepository : Repository<Director>, IRepository<Director>
    {
        public DirectorRepository(AppDb appDb) : base(appDb)
        {
        }
    }
}
