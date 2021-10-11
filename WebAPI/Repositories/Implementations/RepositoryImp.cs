using System.Threading.Tasks;
using WebAPI.Models.Context;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Implementations
{
    public class RepositoryImp<T> : IRepository<T> where T : class
    {
        private readonly SQLDBContext _context;

        public RepositoryImp(SQLDBContext context)
        {
            _context = context;
        }

        public async Task<T> GetById(int id) => await Task.Run(() => _context.Set<T>().Find(id));
    }
}
