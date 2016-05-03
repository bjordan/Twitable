using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitable.RepositoryManager.Mappers
{
   internal class UserMapper
    {
       public string UserName { get; set; }
       public IEnumerable<string> Following { get; set; }
    }
}
