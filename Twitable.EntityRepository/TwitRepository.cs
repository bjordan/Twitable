using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                    var validationResult = ValidateFileContent(line);
                    if (string.IsNullOrEmpty(validationResult))
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
                        throw new Exception("Error - "+validationResult);
                    }
                }
            }
            return twitList.AsQueryable();
        }

        private string ValidateFileContent(string line)
        {
            var result = string.Empty;
            if (!line.Contains(">"))
              result = string.Format("Line missing separator '>': {0};{1}", line,Environment.NewLine);
            else if (line.Split('>')[1].Length > 140)
                result = string.Format("twit more than 140 characters long: {0};{1}", line, Environment.NewLine);
            return result;
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
