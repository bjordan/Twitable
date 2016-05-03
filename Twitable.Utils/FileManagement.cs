using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitable.Utils
{
    public class FileManagement
    {
        public static void EnsureDirectoryExists(DirectoryInfo oDirInfo)
        {
            if (oDirInfo.Parent != null)
                EnsureDirectoryExists(oDirInfo.Parent);
            if (!oDirInfo.Exists)
            {
                oDirInfo.Create();
            }
        }
    }
}
