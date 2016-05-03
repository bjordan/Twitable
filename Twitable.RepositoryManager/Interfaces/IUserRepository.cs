using Twitable.EntityManager;
using Twitable.EntityManager.Filter;

namespace Twitable.RepositoryManager.Interfaces
{
    interface IUserRepository:IEntityRepository<User,UserFilter>
    {
    }
}
