using CU0FK0_HFT_2023241.Models;
using CU0FK0_SZTGUI_2023242.WpfClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_SZTGUI_2023242.WpfClient.Services
{
    public class SongServiceViaWindow : ISongService
    {
        public void Open(RestCollection<Song> songs)
        {
            new SongWindow(songs).Show();
        }
    }
}
