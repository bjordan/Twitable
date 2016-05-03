using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitable.RepositoryManager.Interfaces
{
    interface IEntityRepository<T, TFilter>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByFilter(TFilter filter); 
    }
}
