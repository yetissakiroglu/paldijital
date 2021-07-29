using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class MusicListListViewModel
    {
        public string title { get; set; }
        public MusicList MusicList { get; set; }
        public List<MusicList> MusicLists { get; set; }

        public IEnumerable<SelectListItem> TopMusicLists { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Search { get; set; }
        public int Limit { get; set; }
        public int TopMusicListId { get; set; }

        public int SelectedTopMusicListId { get; set; }

        

    }
}
