using Twitable.EntityManager;
using Twitable.EntityManager.Filter;

namespace Twitable.Repository.Interfaces
{
   public interface IUserRepository:IEntityRepository<User,UserFilter>
    {
    }
}
