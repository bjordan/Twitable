using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Twitable.EntityManager;
using Twitable.EntityManager.Filter;
using Twitable.RepositoryManager.Interfaces;

namespace Twitable.RepositoryManager
{
    public class UserRepository : IUserRepository
    {
        private readonly string _userFilePath;


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
            var allUserList = new List<User>();
            //load all users and the people they follow
            using (var reader = new StreamReader(_userFilePath))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var user = (UserMapper(line));
                    //add the user
                    allUserList.Add(user);
                    //then the people followed
                    allUserList.AddRange(user.Following.Select(leader => new User {UserName = leader}));
                }
            }
            //ensure distinct users in the list
            var distinctUserList = SetDistinctUsers(allUserList);
            //update followers per user
            var userList = UpdateUserFollowers(distinctUserList);
            return userList.AsEnumerable();
        }

        /// <summary>
        /// Search by filter.
        /// </summary>
        /// <param name="filter">User filter</param>
        /// <returns>a filtered list</returns>
        public IEnumerable<User> GetByFilter(UserFilter filter)
        {
            var query = GetAll();
            if (!string.IsNullOrEmpty(filter.UserName))
                query = query.Where(x => x.UserName.Equals(filter.UserName));
            if (!string.IsNullOrEmpty(filter.Following))
                query = query.Where(x => x.Following.Any(y => y.Equals(filter.Following)));
            return query;
        }

        private IQueryable<User> SetDistinctUsers(IEnumerable<User> list)
        {
            var distinctList = new List<User>();
            foreach (var user in list)
            {
                var username = user.UserName;
                //Add the user if not already on the list
                if (!distinctList.Any(x => x.UserName.Equals(username)))
                {
                    distinctList.Add(user);
                }
                else
                {
                    //if already on the list, combine the list of people that the user follows.
                    var tempUser = distinctList.FirstOrDefault(x => x.UserName.Equals(username));

                    var index = distinctList.IndexOf(tempUser);
                    var followingList = new List<string>();
                    if (tempUser.Following != null)
                        followingList.AddRange(tempUser.Following);
                    if (user.Following != null)
                        followingList.AddRange(user.Following);
                    tempUser.Following = followingList.Distinct().AsQueryable();
                    distinctList[index] = tempUser;

                }
            }
            return distinctList.AsQueryable();
        }

        private IEnumerable<User> UpdateUserFollowers(IQueryable<User> tempUserList)
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
                var names = line.Split(new[] {"follows"}, StringSplitOptions.None);
                user.UserName = names[0].Trim();
                user.Following = names[1].Split(',').Select(s => s.Trim()).AsQueryable(); //trim names  
            }
            else
            {
                throw new InvalidDataException("Unable to process the user file, due to an invalid format.");
            }
            return user;
        }

    }
}
