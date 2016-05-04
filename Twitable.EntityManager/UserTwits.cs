using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitable.EntityManager
{
    public class UserTwits
    {
        public string Username { get; set; }
        public IEnumerable<Twit> Twits { get; set; }
    }
}
