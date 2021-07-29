using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Core.Extensions
{
    public static class DosyaCreateExtensions
    {
        //Pdf Yükleme
        public static async Task<string> PdfCreate(IFormFile file, string dosyaadi, string sayfaadi)
        {
            if (file != null)
            {

                string ext = Path.GetExtension(file.FileName);
                if (ext == ".pdf")//resim tür kontrolü
                {
                    var newtitle = Replace.UrlAndTitleReplace(sayfaadi);
                    string uniqnumber = Guid.NewGuid().ToString();
                    var FileName = newtitle + "-" + uniqnumber + ext;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\dosya", FileName);
                    using (var stream = new FileStream(path, FileMode.CreateNew))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return FileName;
                }

                else
                {
                    return "pdf";
                }

            }
            else
            {
                return "dosya.pdf";
            }
        }
        //Image Yükleme
        public static async Task<string> ImgCreate(IFormFile file, string dosyaadi, string sayfaadi)
        {
            if (file != null)
            {

                string ext = Path.GetExtension(file.FileName);
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".jpg.webp" || ext == ".tiff" || ext == ".gif" || ext == ".psd" || ext == ".eps" || ext == ".ai" || ext == ".webp")//resim tür kontrolü
                {
                    var newtitle = Replace.UrlAndTitleReplace(sayfaadi);

                    string uniqnumber = Guid.NewGuid().ToString();
                    var FileName = newtitle + "-" + uniqnumber + ext;

                    if (!System.IO.Directory.Exists("wwwroot\\upload"))
                        System.IO.Directory.CreateDirectory("wwwroot\\upload");

                    if (!System.IO.Directory.Exists("wwwroot\\upload\\" + dosyaadi))
                        System.IO.Directory.CreateDirectory("wwwroot\\upload\\" + dosyaadi);


                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload\\" + dosyaadi, FileName);
                    using (var stream = new FileStream(path, FileMode.CreateNew))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return "/upload/" + dosyaadi + "/" + FileName;
                }

                else
                {
                    return "null";
                }

            }
            else
            {
                return "/upload/img.jpg";
            }
        }
        public static async Task<string> Mp3Create(IFormFile file, string dosyaadi, string sayfaadi)
        {
            if (file != null)
            {

                string ext = Path.GetExtension(file.FileName);
                if (ext == ".mp3")//mp3 tür kontrolü
                {
                    var newtitle = Replace.UrlAndTitleReplace(sayfaadi);

                    string uniqnumber = Guid.NewGuid().ToString();
                    var FileName = newtitle + "-" + uniqnumber + ext;


                    if (!System.IO.Directory.Exists("wwwroot\\upload"))
                        System.IO.Directory.CreateDirectory("wwwroot\\upload");

                    if (!System.IO.Directory.Exists("wwwroot\\upload\\" + dosyaadi))
                        System.IO.Directory.CreateDirectory("wwwroot\\upload\\" + dosyaadi);


                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\upload\\" + dosyaadi, FileName);

                    using (var stream = new FileStream(path, FileMode.CreateNew))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return "/upload/" + dosyaadi + "/" + FileName;
                }

                else
                {
                    return "null";
                }

            }
            else
            {
                return "demo.mp3";
            }
        }


        //Yukarıda dosyalar sadece kod içerisindeki uzantıları ile yükleme yapar.


    }
}
