using WebAPI.Models.Context;

namespace WebAPI.Repositories.Implementations
{
    public class RepositoryImp<T>
    {
        private readonly SQLDBContext _context;

        public RepositoryImp(SQLDBContext context)
        {
            _context = context;
        }
    }
}
