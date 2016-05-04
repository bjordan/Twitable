using System;
using Twitable.Repository.Interfaces;
using Twitable.Utils;

namespace Twitable.BusinessRuleEngine
{
    /// <summary>
    /// Returns the classes that implement the IEntityRepository interface.
    /// </summary>
    static class RepositoryFactory
    {
        /// <summary>
        /// Gets the implementation user repository interface
        /// </summary>
        /// <param name="source">the location of the repository</param>
        /// <returns>The derived repository class</returns>
        public static IUserRepository GetUserRepository(string source)
        {
                var objAppProvider = (IUserRepository)Activator.CreateInstance(Type.GetType(Config.UserRepositoryProvider), source);
                return objAppProvider;
           
        }
        /// <summary>
        /// Gets the implementation twit repository interface
        /// </summary> 
        /// <param name="source">the location of the repository</param>
        /// <returns>The derived repository class</returns>
        public static ITwitRepository GetTwitRepository( string source)
        {
              var objAppProvider = (ITwitRepository)Activator.CreateInstance(Type.GetType(Config.TweetRepositoryProvider), source);
                return objAppProvider;
          
        }
    }
}
