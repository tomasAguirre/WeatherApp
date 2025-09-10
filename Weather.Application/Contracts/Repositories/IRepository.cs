using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Application.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> save(T Entity);
        Task<bool> checkIfAlreadyExists(DateTime date);
    }
}
