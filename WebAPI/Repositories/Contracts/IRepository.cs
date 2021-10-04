using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int ID);
    }
}
