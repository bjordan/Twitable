using System;
using System.Linq;
using Twitable.EntityManager;
using Twitable.EntityManager.Filter;
using Twitable.Repository.Interfaces;

namespace Twitable.FileRepository
{
    public class TwitRepository:ITwitRepository
    {

        private readonly string _twitFilePath;

        public TwitRepository(string filePath)
        {
            _twitFilePath = filePath;
        }
        public IQueryable<Twit> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Twit> GetByFilter(TwitFilter filter)
        {
            var query = GetAll();
            if (!string.IsNullOrEmpty(filter.UserName))
                query = query.Where(x => x.UserName.Equals(filter.UserName)); 
            return query;
        }
    }
}
