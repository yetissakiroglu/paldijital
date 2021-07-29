using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class PodcastMusicListListViewModel
    {
        public string title { get; set; }
        public PodcastMusicList PodcastMusicList { get; set; }
        public List<PodcastMusicList> PodcastMusicLists { get; set; }

        public IEnumerable<SelectListItem> Programs { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Search { get; set; }
        public int Limit { get; set; }
        public int ProgramId { get; set; }

        public int SelectedProgramId { get; set; }

        public DateTime SDate { get; set; }
        public DateTime FDate { get; set; }

    }
}
