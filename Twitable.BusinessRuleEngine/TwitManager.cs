using System.Collections.Generic;
using System.Linq;
using Twitable.EntityManager;
using Twitable.Repository.Interfaces;
using Twitable.Utils;

namespace Twitable.BusinessRuleEngine
{
    public class TwitManager
    {
        private readonly string _userFile, _twitFile;
        private IUserRepository UserRepository { get; set; }
        private ITwitRepository TwitRepository { get; set; }

 
        public TwitManager(string userFilePath,string twitFilePath)
        {
            _userFile = userFilePath;
            _twitFile = twitFilePath;
        }


        public IEnumerable<UserTwits> LoadTweets()
        {
            InstantiateRepositories();
            var users = UserRepository.GetAll().OrderBy(x=>x.UserName);//loads all twitter users
            return users.Select(user => new UserTwits
            {
                Username = user.UserName, Twits = GetAssociatedTwits(user)
            }).ToList();
        }

        private IEnumerable<Twit> GetAssociatedTwits(User user)
        {
            var twitList = TwitRepository.GetAll();//loads all the tweets to be displayed

            return twitList.Where(twit => twit.UserName == user.UserName || user.Following.Contains(twit.UserName))
                .ToList();
        }


        private void InstantiateRepositories()
        {
            UserRepository = RepositoryFactory.GetUserRepository(_userFile);
            TwitRepository = RepositoryFactory.GetTwitRepository(_twitFile);
        }
    }
}
