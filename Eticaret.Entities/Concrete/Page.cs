using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Page : IEntity
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Web_Url { get; set; }
        public string Short_Detail { get; set; }
        public string Detail { get; set; }
        public string Big_Img { get; set; }
        public string Small_Img { get; set; }
        public string Video_Url { get; set; }
        public string File_Url { get; set; }
        public string Sound_Url { get; set; }
        public int GalleryId { get; set; }
        public int CategoryId { get; set; }
        public string Category_Name { get; set; }
        public int ModulId { get; set; }
        public string Modul_Name { get; set; }
        public int Row { get; set; }
        public string Target { get; set; }
        public string Date_Start { get; set; }
        public string Date_End { get; set; }
        public string Date_Save { get; set; }
        public string Date_Update { get; set; }
        public string Lang { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string HeadLine_Status { get; set; }
        public string Home_Status { get; set; }
        public int Hit { get; set; }
        public string UrlRoute { get; set; }
        public string UrlSite { get; set; }

    }
}
