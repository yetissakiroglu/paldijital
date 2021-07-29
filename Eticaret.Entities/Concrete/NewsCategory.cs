using Eticaret.Core.Entities;
using Eticaret.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class NewsCategory : IEntity
    {
        [Key]
        public int categoryId { get; set; }

        [Display(Name = "Başlık : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string title { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public string imgPath { get; set; }
        public string url { get; set; }
        public int row { get; set; }
        public bool status { get; set; }

        public virtual List<News> News { get; set; }
        public virtual List<NewsDetail> NewsDetail { get; set; }

        public NewsCategory()
        {
            NewsDetail = new List<NewsDetail>();
            News = new List<News>();
        }
    }
}
