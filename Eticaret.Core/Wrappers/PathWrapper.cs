﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Core.Wrappers
{
    public class PathWrapper : IPathWrapper
    {
        public string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }

        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }
    }
}
