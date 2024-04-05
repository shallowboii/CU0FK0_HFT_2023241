using CU0FK0_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_SZTGUI_2023242.WpfClient.Services
{
    internal class AlbumServiceViaWindow : IAlbumService
    {
        public void Open(RestCollection<Album> albums )
        {
            new AlbumWindow(albums).Show();
        }
    }
}
