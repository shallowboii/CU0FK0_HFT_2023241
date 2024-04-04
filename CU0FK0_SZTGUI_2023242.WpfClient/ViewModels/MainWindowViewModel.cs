using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using CU0FK0_HFT_2023241.Models;
using CU0FK0_SZTGUI_2023242.WpfClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CU0FK0_SZTGUI_2023242.WpfClient.ViewModels
{
    public class MainWindowViewModel
    {
        ISongService songservice;
        IAlbumService albumService;
        IArtistService artistService;
        public ICommand SongOpenerCommand { get; set; }
        public ICommand AlbumOpenerCommand { get; set; }
        public ICommand ArtistOpenerCommand { get; set; }

        public RestCollection<Song> SongCollection { get; set; }
        public RestCollection<Album> AlbumCollection { get; set; }
        public RestCollection<Artist> ArtistCollection { get; set; }

        public MainWindowViewModel()
        {
            songservice = Ioc.Default.GetRequiredService<ISongService>();
            albumService = Ioc.Default.GetRequiredService<IAlbumService>();
            artistService = Ioc.Default.GetRequiredService<IArtistService>();
            SongCollection = new RestCollection<Song>("http://localhost:17161/", "song", "hub");
            AlbumCollection = new RestCollection<Album>("http://localhost:17161/", "album", "hub");
            ArtistCollection = new RestCollection<Artist>("http://localhost:17161/", "artist","hub");
            SongOpenerCommand = new RelayCommand(() =>
            {
                songservice.Open(SongCollection);
            },
            ()=> true);
            AlbumOpenerCommand = new RelayCommand(() =>
            {
                albumService.Open(AlbumCollection);
            },
            () => true);
            ArtistOpenerCommand = new RelayCommand(() =>
            {
                artistService.Open(ArtistCollection);
            },
            () => true);

        }
        
    }
}
