using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Core.Wrappers
{
    public interface IFileSystemWrapper
    {
        IFileWrapper File { get; set; }
        IDirectoryWrapper Directory { get; set; }
        IPathWrapper Path { get; set; }
    }

}
