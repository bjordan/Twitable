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
    public class UserRepository : IUserRepository
    {
        private string _userFilePath;

        public UserRepository() : this(Path.Combine(Config.SourceDirectory, Config.UserFile))
        {

        }

        public UserRepository(string userFilePath)
        {
            _userFilePath = userFilePath;
        }

        public IEnumerable<User> GetAll()
        {
            var tempUserList = new List<User>();
            using (var reader = new StreamReader(_userFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tempUserList.Add(UserMapper(line));
                }
            }
            var userList = UpdateUserFollowers(tempUserList);
            return userList.AsEnumerable();
        }

        private IEnumerable<User> UpdateUserFollowers(List<User> tempUserList)
        {
            foreach (var user in tempUserList)
            {
                user.Followers
            }
        }


        private User UserMapper(string line)
        {
            var user = new User();
            if (line.IndexOf("follows", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                var names = line.Split(new string[] {"follows"}, StringSplitOptions.None);
                user.UserName = names[0].Trim();
                user.Following = names[1].Split(',').AsQueryable();
            }
            return user;
        }




        public IEnumerable<User> GetByFilter(UserFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
