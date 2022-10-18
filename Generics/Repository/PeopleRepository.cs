using Generics.Data;
using Generics.Models;

namespace Generics.Repository
{
    public class PeopleRepository : Repository<People>, IRepository<People>
    {
        public PeopleRepository(AppDb appDb) : base(appDb)
        {
        }
    }
}
