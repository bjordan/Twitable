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
        private readonly string _userFilePath;

        public UserRepository() : this(Path.Combine(Config.SourceDirectory, Config.UserFile))
        {

        }

        public UserRepository(string userFilePath)
        {
            _userFilePath = userFilePath;
        }
        /// <summary>
        /// Loads all files from the pre-defined user File
        /// </summary>
        /// <returns>A list of twitter users with followers and those they follow</returns>
        public IEnumerable<User> GetAll()
        {
            var tempUserList = new List<User>();
            //first load all users in the file and assign the users they follow
            using (var reader = new StreamReader(_userFilePath))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var user = (UserMapper(line));
                    //add the user
                    tempUserList.Add(user);
                    //add the followed users
                    tempUserList.AddRange(user.Following.Select(leader => new User {UserName = leader}));
                }
            }
            //merge duplicate usernames and the people followed
            var mergedUserList = SetDistinctUsers(tempUserList);

            var userList = UpdateUserFollowers(mergedUserList.ToList());
            return userList.AsEnumerable();
        }

        private IQueryable<User> SetDistinctUsers(IEnumerable<User> list)
        {
            var distinctList = new List<User>();
            foreach (var user in list)
            {
                var username = user.UserName;
                if (!distinctList.Any(x => x.UserName.Equals(username)))
                {
                    distinctList.Add(user);
                }
                else
                {
                    var tempUser = distinctList.FirstOrDefault(x => x.UserName.Equals(username));
                    if (tempUser != null)
                    {
                        var index = distinctList.IndexOf(tempUser);
                        List<string> followingList = new List<string>();
                        if (tempUser.Following != null)
                            followingList.AddRange(tempUser.Following);
                        if (user.Following != null)
                            followingList.AddRange(user.Following);
                        tempUser.Following = followingList.Distinct().AsQueryable();
                        distinctList[index] = tempUser;
                    }
                }
            }
            return distinctList.AsQueryable();
        }


        private IEnumerable<User> UpdateUserFollowers(List<User> tempUserList)
        {   
            foreach (var user in tempUserList)
            {
                var username = user.UserName;
                var followers = tempUserList.Where(x => x.Following.Contains(username));
                user.Followers = followers.Select(follower => follower.UserName).Distinct().AsQueryable();
            }
            return tempUserList;
        }

        /// <summary>
        /// Sets the users and the people that they follow
        /// </summary>
        /// <param name="line">a string of the format User1 follows User2, User3 ...</param>
        /// <returns>A user object with the username set and list of usernames that are followed</returns>
        private User UserMapper(string line)
        {
            var user = new User();
            if (line.IndexOf("follows", StringComparison.CurrentCultureIgnoreCase) >= 0)
            {
                var names = line.Split(new string[] {"follows"}, StringSplitOptions.None);
                user.UserName = names[0].Trim(); 
                user.Following = names[1].Split(',').Select(s => s.Trim()).AsQueryable();//trim names  
            }
            return user;
        }




        public IEnumerable<User> GetByFilter(UserFilter filter)
        {
            throw new NotImplementedException();
        }
    }

}
