using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eticaret.Core.Wrappers
{
    public interface IFileWrapper
    {
        bool Exists(string path);
        void Delete(string path);
        Task SaveAsAsync(IFormFile formFile, string filename, CancellationToken cancellationToken = default(CancellationToken));

    }
}
