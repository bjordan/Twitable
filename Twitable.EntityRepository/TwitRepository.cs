using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Twitable.EntityManager;
using Twitable.EntityManager.Filter;
using Twitable.Repository.Interfaces;

namespace Twitable.EntityRepository
{
    public class TwitRepository:ITwitRepository
    {
        private readonly string _twitFilePath;

        public TwitRepository(string filePath)
        {
            _twitFilePath = filePath;
        }

        /// <summary>
        /// Retrieves all twits from the specified file path into a list of Twit objects
        /// </summary>
        /// <returns>The list of twit objects.</returns>
        public IQueryable<Twit> GetAll()
        {
            var twitList = new List<Twit>();
            using (var reader = new StreamReader(_twitFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    bool isValid = line.Contains(">") && line.Split('>')[1].Length <= 140;
                    if (isValid)
                    {
                        var parts = line.Split('>');
                        var username = parts[0].Trim();
                        var text = parts[1].Trim();
                        twitList.Add(new Twit
                        {
                            UserName = username,Text = text
                        });
                    }
                    else
                    {
                        throw new Exception("The file provided, does not contain valid twits.");
                    }
                }
            }
            return twitList.AsQueryable();
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
