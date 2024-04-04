using CommunityToolkit.Mvvm.DependencyInjection;
using CU0FK0_SZTGUI_2023242.WpfClient.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CU0FK0_SZTGUI_2023242.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<ISongService, SongServiceViaWindow>()
                .AddSingleton<IAlbumService,AlbumServiceViaWindow>()
                .AddSingleton<IArtistService, ArtistServiceViaWindow>()
                .BuildServiceProvider()
                );
        }
    }
}
