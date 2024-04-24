using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CU0FK0_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace CU0FK0_SZTGUI_2023242.WpfClient.ViewModels
{
    public class AlbumWindowViewModel : ObservableRecipient
    {
        public bool IsSelected { get; set; } = false;
        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        AlbumID = value.AlbumID,
                        AlbumTitle = value.AlbumTitle
                    };
                    IsSelected = true;
                    OnPropertyChanged();

                }
                else
                {
                    IsSelected = false;
                    selectedAlbum = new Album();
                }
                
                (DeleteAlbumCommand as RelayCommand)?.NotifyCanExecuteChanged();
                (UpdateAlbumCommand as RelayCommand)?.NotifyCanExecuteChanged();
            }
        }
        private List<Album> femaleAlbums;

        public List<Album> FemaleAlbums
        {
            get { return femaleAlbums; }
            set
            {
                if (value != null)
                {
                    femaleAlbums = value;
                    OnPropertyChanged();
                    
                }
            }
        }

        private List<Song> everySongFrom;

        public List<Song> EverySongFrom
        {
            get { return everySongFrom; }
            set
            {
                if (value != null)
                {
                    everySongFrom = value;
                    OnPropertyChanged();

                }
            }
        }

        private double better;

        public double Better
        {
            get { return better; }
            set
            {
                if (value != null)
                {
                    better = value;
                    OnPropertyChanged();
                }
            }
        }



        public RestCollection<Album> Albums { get; set; }
        public RestCollection<Song> Songs { get; set; }

        public ICommand CreateAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }

        public ICommand DeleteAlbumCommand { get; set; }

        public ICommand FemaleAlbumsLaterThan2012 { get; set; }

        public ICommand EverySongFromAlbumBetterThanCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AlbumWindowViewModel()
        {

        }
        public AlbumWindowViewModel(RestCollection<Album> albums,RestCollection<Song> songs)
        {

            if (!IsInDesignMode)
            {
                this.Albums = albums;
                this.Songs = songs;
                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        AlbumTitle = SelectedAlbum.AlbumTitle,
                        ArtistID = SelectedAlbum.ArtistID
                    }) ;
                });

                DeleteAlbumCommand = new RelayCommand(async() =>
                {
                    await Albums.Delete(SelectedAlbum.AlbumID);
                    await Albums.Refresh();
                    await Songs.Refresh();
                    IsSelected = false;
                    
                },
                () =>
                {
                    return IsSelected == true;
                });

                UpdateAlbumCommand = new RelayCommand(async () =>
                {
                    await Albums.Update(SelectedAlbum);
                    await Albums.Refresh();
                },
                () =>
                {
                    return IsSelected == true;
                });
                
                FemaleAlbumsLaterThan2012 = new RelayCommand(() =>
                {
                    FemaleAlbums = Albums.GetFemaleAlbumsLaterThan2012<Album>();
                },
                () =>
                {
                    return FemaleAlbums != null;
                });
                EverySongFromAlbumBetterThanCommand = new RelayCommand(() =>
                {
                    EverySongFrom = Albums.GetEverySongFromAlbumBetterThan<Song>(Better);
                },
                () =>
                {
                    return EverySongFrom != null;
                });
                FemaleAlbums = new List<Album>();
                EverySongFrom = new List<Song>();
            }
        }

    }
}
