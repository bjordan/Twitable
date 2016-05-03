using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitable.EntityManager;
using Twitable.EntityManager.Filter;

namespace Twitable.RepositoryManager.Interfaces
{
    interface ITwitRepository:IEntityRepository<Twit,TwitFilter>
    {
    }
}
