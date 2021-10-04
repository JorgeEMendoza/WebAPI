using System.Threading.Tasks;

namespace WebAPI.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetById(int ID);
    }
}
