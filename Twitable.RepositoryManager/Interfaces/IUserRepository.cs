﻿using Twitable.EntityManager;
using Twitable.EntityManager.Filter;

namespace Twitable.RepositoryManager.Interfaces
{
   public interface IUserRepository:IEntityRepository<User,UserFilter>
    {
    }
}
