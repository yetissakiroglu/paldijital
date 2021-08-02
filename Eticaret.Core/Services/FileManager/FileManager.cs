
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Eticaret.Core.Wrappers;
using Eticaret.Core.Enums;

namespace Eticaret.Core.Services.FileManager
{
    public class FileManager : IFileManager
    {
        public IHostingEnvironment Environment { get; }
        public IFileSystemWrapper FileSystem { get; }
        public IUrlHelper UrlHelper { get; }

        [Obsolete]
        public FileManager(IHostingEnvironment environment, IFileSystemWrapper fileSystem)
        {
            Environment = environment;
            FileSystem = fileSystem;
        }

        [Obsolete]
        public FileManager(IHostingEnvironment environment, IFileSystemWrapper fileSystem, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        {
            Environment = environment;
            FileSystem = fileSystem;
            UrlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
        public void DeleteEditorImages(string bodyText, List<string> path)
        {
            path.Insert(0, Environment.WebRootPath);

            Regex findImages = new Regex(@"<img.*?src=""(.*?)""", RegexOptions.IgnoreCase);

            var result = findImages.Matches(bodyText).Cast<Match>().Select(r => r.Groups[1].Value).ToList();

            if (result.Count != 0)
            {
                var resultFileNames = result.Select(r => r.Split('/').Last());

                foreach (var image in resultFileNames)
                {
                    path.Add(image);

                    var fullPath = FileSystem.Path.Combine(path.ToArray());

                    if (FileSystem.File.Exists(fullPath))
                    {
                        FileSystem.File.Delete(fullPath);
                    }

                    path.Remove(path.Last());
                }
            }
        }

        [Obsolete]
        public FileStatus DeleteFile(string fileName, List<string> path)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "The fileName argument cannot be null, empty or whitespace.");
            }

            if (path == null || path.Count == 0)
            {
                throw new ArgumentException("The path argument cannot be null or empty.", nameof(path));
            }

            path.Insert(0, Environment.WebRootPath);

            path.Add(fileName);

            var fullPath = FileSystem.Path.Combine(path.ToArray());

            if (!FileSystem.File.Exists(fullPath))
            {
                return FileStatus.FileNotExist;
            }

            FileSystem.File.Delete(fullPath);

            if (!FileSystem.File.Exists(fullPath))
            {
                return FileStatus.DeleteSuccess;
            }

            return FileStatus.DeleteFailed;
        }

        public async Task<string> UploadFileAsync(IFormFile file, List<string> path)
        {

            if (file == null) throw new ArgumentNullException(nameof(file), "The file argument cannot be null.");

            if (path == null || path.Count == 0) throw new ArgumentException("The path argument cannot be null or empty.", nameof(path));

            if (file.Length <= 0) return null;

            var fileName = FileSystem.Path.GetFileNameWithoutExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"'));

            var extension = FileSystem.Path.GetExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"'));

            var fullFileName = fileName.Replace(" ", "-") + "-" + DateTime.Now.ToString("yyyyMMdd-HHMMssff") + extension;

            path.Insert(0, Environment.WebRootPath);

            var folderPath = FileSystem.Path.Combine(path.ToArray());

            if (!FileSystem.Directory.Exists(folderPath)) FileSystem.Directory.CreateDirectory(folderPath);

            var fullPath = FileSystem.Path.Combine(folderPath, fullFileName);

            await FileSystem.File.SaveAsAsync(file, fullPath);

            return fullFileName;
        }

        public bool ValidateUploadedFile(IFormFile file, UploadFileType fileType, double maxFileSize, ModelStateDictionary modelState)
        {
            var extension = FileSystem.Path.GetExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"'));

            if (file.Length > (maxFileSize * (1024 * 1024)))
            {
                modelState.AddModelError(string.Empty, "Seçilen dosya boyutu kabul edilemez, izin verilen maksimum boyut " + maxFileSize + " MB");
                return false;
            }

            if (fileType == UploadFileType.Image)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".JPG", ".JPEG", ".PNG", ".GIF", ".BMP" };

                if (!allowedExtensions.Contains(extension))
                {
                    modelState.AddModelError(string.Empty, "Seçilen dosya formatı uygun değil, kabul edilebilir formatlar (jpg, jpeg, png, gif, bmp) var.");
                }

                return allowedExtensions.Contains(extension);
            }

            if (fileType == UploadFileType.DocumentFile)
            {
                var allowedExtensions = new[] { ".doc", ".docx", ".txt", ".xlsx", ".DOC", ".DOCX", ".TXT", ".XLSX" };

                return allowedExtensions.Contains(extension);
            }

            if (fileType == UploadFileType.VideoFile)
            {
                var allowedExtensions = new[] { ".avi", ".mkv", ".flv", ".mp4", ".wmv", ".AVI", ".MKV", ".FLV", ".MP4", ".WMV" };

                return allowedExtensions.Contains(extension);
            }

            if (fileType == UploadFileType.CompressedFile)
            {
                var allowedExtensions = new[] { ".rar", ".zip", ".7zip", ".RAR", ".ZIP", ".7ZIP" };

                return allowedExtensions.Contains(extension);
            }

            return false;
        }
    }
}
