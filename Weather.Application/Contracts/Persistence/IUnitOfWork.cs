using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task Persist();
        Task Reverse();
    }
}
