using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Eticaret.Core.Wrappers
{
    public interface IDirectoryWrapper
    {
        bool Exists(string path);
        DirectoryInfo CreateDirectory(string path);
    }
}
