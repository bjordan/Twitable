using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Twitable.EntityManager
{
    public class User
    {
        public IQueryable<string> Following { get; set; }
        public IQueryable<string> Followers { get; set; }
        public string UserName { get; set; }
        public Lazy<string> Twits { get; set; }
    }
}
