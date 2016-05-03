using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitable.EntityManager;
using Twitable.EntityManager.Filter;
using Twitable.RepositoryManager.Interfaces;
using Twitable.RepositoryManager.Mappers;
using Twitable.Utils;

namespace Twitable.RepositoryManager
{
    public class UserRepository:IUserRepository
    {
        private string _userFilePath;

        public UserRepository():this(Path.Combine(Config.SourceDirectory,Config.UserFile))
        {
            
        }
        public UserRepository(string userFilePath)
        {
            _userFilePath = userFilePath;
        }
        public IEnumerable<User> GetAll()
        {
            var list = new List<User>();
            using (var reader = new StreamReader(_userFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(UserMapper(line));
                }
            }
            return list.AsEnumerable();
        }

        private User UserMapper(string line)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByFilter(UserFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
