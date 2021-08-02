

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret.Core.Wrappers;
using Eticaret.Core.Enums;

namespace Eticaret.Core.Services.FileManager
{
    public interface IFileManager
    {
        IHostingEnvironment Environment { get; }
        IFileSystemWrapper FileSystem { get; }
        Task<string> UploadFileAsync(IFormFile file, List<string> path);
        FileStatus DeleteFile(string fileName, List<string> path);
        void DeleteEditorImages(string bodyText, List<string> path);
        bool ValidateUploadedFile(IFormFile file, UploadFileType fileType, double maxFileSize, ModelStateDictionary modelState);

    }

}
